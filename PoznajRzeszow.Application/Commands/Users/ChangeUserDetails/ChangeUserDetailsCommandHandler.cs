using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Users.ChangeUserDetails
{
    public class ChangeUserDetailsCommandHandler : IRequestHandler<ChangeUserDetailsCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public ChangeUserDetailsCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher,
            IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<Unit> Handle(ChangeUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var requestingUser = await _userRepository.GetAsync(request.UserId);
            if (requestingUser == null) throw new Exception("User not found");

            if (request.Username != requestingUser.Username)
            {
                var otherUser = await _userRepository.GetAsync(request.Username);
                if (otherUser != null) throw new Exception("Username taken");
            }

            if (request.Email != requestingUser.Email)
            {
                var otherUser = await _userRepository.GetByEmailAsync(request.Email);
                if (otherUser != null) throw new Exception("Email taken");
            }

            requestingUser.Username = request.Username;
            requestingUser.Email = request.Email;
            await _userRepository.UpdateAsync(requestingUser);

            return Unit.Value;
        }
    }
}
