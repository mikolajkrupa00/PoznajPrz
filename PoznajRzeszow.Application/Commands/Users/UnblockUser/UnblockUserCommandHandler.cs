using MediatR;
using PoznajRzeszow.Domain.Enums;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Users.UnblockUser
{
    public class UnblockUserCommandHandler : IRequestHandler<UnblockUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UnblockUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UnblockUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Username);
            user.Role = Roles.User;
            await _userRepository.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
