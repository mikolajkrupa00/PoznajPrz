using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PoznajRzeszow.Domain.Models;
using PoznajRzeszow.Domain.Interfaces.Services;

namespace PoznajRzeszow.Application.Commands.Users.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IUserRepository userRepository, IJwtGenerator jwtGenerator, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtGenerator = jwtGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword) throw new Exception("Passwords mismatch");
            var existingUser = await _userRepository.GetAsync(request.Username);
            if (existingUser != null) throw new Exception("Username taken");
            existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null) throw new Exception("Email taken");

            var salt = _passwordHasher.GenerateSalt();
            var password = _passwordHasher.GenerateHash(request.Password, salt);
            var user = User.Create(request.Email, request.Username, password, salt, Domain.Enums.Roles.User);
            await _userRepository.CreateAsync(user);
            var token = _jwtGenerator.Generate(user.UserId, Domain.Enums.Roles.User);
            return new UserDto(user.UserId, user.Username, token, user.Role);
        }
    }
}
