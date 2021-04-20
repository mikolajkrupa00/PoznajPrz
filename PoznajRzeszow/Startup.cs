using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using PoznajRzeszow.API.Configuration;
using PoznajRzeszow.Application.Commands.Users.RegisterUser;
using PoznajRzeszow.Application.Services;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Interfaces.Services;
using PoznajRzeszow.Infrastructure;
using PoznajRzeszow.Infrastructure.QueryHandlers.Users;
using PoznajRzeszow.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
                                  });
            });
            services.AddMvc(x => x.EnableEndpointRouting = false);
            var _connectionString = Configuration.GetConnectionString("PoznajRzeszowConnectionString");
            services.AddDbContext<PoznajRzeszowContext>(options => 
            options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));
            services.AddMediatR(typeof(GetUserQueryHandler), typeof(RegisterUserCommandHandler));

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings").GetSection("Secret").Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });



            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IPlaceRepository, PlaceRepository>();
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IJwtGenerator, JwtGenerator>();
            services.AddTransient<IVisitRepository, VisitRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();


            services.AddControllers();

            services.ConfigureSwaggerGen(options => { options.CustomSchemaIds(x => x.FullName); });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PoznajRzeszow API", Version = "v1" });

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "PoznajRzeszow API V1"); });
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
