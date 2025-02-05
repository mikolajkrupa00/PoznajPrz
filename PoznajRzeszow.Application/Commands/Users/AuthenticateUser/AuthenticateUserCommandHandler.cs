﻿using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Users.AutheticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher,
            IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<UserDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Username);
            if (user != null && _passwordHasher.Validate(request.Password, user.Salt, user.Password))
                return new UserDto(user.UserId, user.Username, user.Role, _jwtGenerator.Generate(user.UserId, user.Role));
            throw new Exception();
        }
    }
}
