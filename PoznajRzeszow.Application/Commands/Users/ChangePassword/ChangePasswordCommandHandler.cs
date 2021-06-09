using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Users.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            if (request.NewPassword != request.NewPasswordRepeat) throw new Exception("New passwords mismatch");

            var user = await _userRepository.GetAsync(request.UserId);
            if (user == null) throw new Exception("User not found");

            if (!_passwordHasher.Validate(request.CurrentPassword, user.Salt, user.Password)) throw new Exception("Wrong password");

            user.Password = _passwordHasher.GenerateHash(request.NewPassword, user.Salt);
            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
