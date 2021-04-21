using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure
{
    public class PoznajRzeszowContext : DbContext
    {
        public PoznajRzeszowContext(DbContextOptions<PoznajRzeszowContext> options) : base(options)
        {

        }

        public PoznajRzeszowContext()
        {

        }

        public DbSet<DbEvent> Events { get; set; }
        public DbSet<DbFriend> Friends { get; set; }
        public DbSet<DbPlace> Places { get; set; }
        public DbSet<DbPlaceCategory> Categories { get; set; }
        public DbSet<DbRating> Ratings { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbVisit> Visits { get; set; }
        public DbSet<DbCategoryType> CategoryTypes { get; set; }

        protected override void  OnModelCreating(ModelBuilder builder)
        {
            // CategoryType
            builder
                .Entity<DbCategoryType>()
                .HasKey(x => x.CategoryTypeId);
            builder
                .Entity<DbCategoryType>()
                .HasMany(x => x.Categories)
                .WithOne(x => x.CategoryType)
                .HasForeignKey(x => x.CategoryTypeId);


            // Event
            builder
                .Entity<DbEvent>()
                .HasKey(x => x.EventId);
            builder
                .Entity<DbEvent>()
                .HasOne(x => x.Place)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.PlaceId);

            // Place
            builder
                .Entity<DbPlace>()
                .HasKey(x => x.PlaceId);
            builder
                .Entity<DbPlace>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Places)
                .HasForeignKey(x => x.CategoryId);
            builder
                .Entity<DbPlace>()
                .HasMany(x => x.Visits)
                .WithOne(x => x.Place)
                .HasForeignKey(x => x.PlaceId);
            builder
                .Entity<DbPlace>()
                .HasMany(x => x.Events)
                .WithOne(x => x.Place)
                .HasForeignKey(x => x.PlaceId);
            builder
                .Entity<DbPlace>()
                .HasMany(x => x.Ratings)
                .WithOne(x => x.Place)
                .HasForeignKey(x => x.PlaceId);


            // Category
            builder
                .Entity<DbPlaceCategory>()
                .HasKey(x => x.PlaceCategoryId);
            builder
                .Entity<DbPlaceCategory>()
                .HasMany(x => x.Places)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
            builder
                .Entity<DbPlaceCategory>()
                .HasOne(x => x.CategoryType)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.CategoryTypeId);

            // Rating
            builder
                .Entity<DbRating>()
                .HasKey(x => x.RatingId);
            builder
                .Entity<DbRating>()
                .HasOne(x => x.Place)
                .WithMany(x => x.Ratings);
            builder
                .Entity<DbRating>()
                .HasOne(x => x.User)
                .WithMany(x => x.Ratings);


            // User
            builder
                .Entity<DbUser>()
                .HasKey(x => x.UserId);
            builder
                .Entity<DbUser>()
                .HasMany(x => x.Visits)
                .WithOne(x => x.VisitedBy)
                .HasForeignKey(x => x.VisitedById);
            builder
                .Entity<DbUser>()
                .HasMany(x => x.Ratings)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            builder
                .Entity<DbUser>()
                .HasMany(x => x.MainUserFriends)
                .WithOne(x => x.User1)
                .HasForeignKey(x => x.User1Id);
            builder
                .Entity<DbUser>()
                .HasMany(x => x.Friends)
                .WithOne(x => x.User2)
                .HasForeignKey(x => x.User2Id);

            // Visit
            builder
                .Entity<DbVisit>()
                .HasKey(x => x.VisitId);
            builder
                .Entity<DbVisit>()
                .HasOne(x => x.VisitedBy)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.VisitedById);
            builder
                .Entity<DbVisit>()
                .HasOne(x => x.Place)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.PlaceId);

            // Friends
            builder.Entity<DbFriend>()
                .HasKey(x => new { x.User1Id, x.User2Id });
            builder.Entity<DbFriend>()
                .HasOne(x => x.User1)
                .WithMany(x => x.MainUserFriends)
                .HasForeignKey(x => x.User1Id);
            builder.Entity<DbFriend>()
                .HasOne(x => x.User2)
                .WithMany(x => x.Friends)
                .HasForeignKey(x => x.User2Id);
        }
    }
}
