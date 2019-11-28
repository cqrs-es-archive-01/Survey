using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using Survey.Transverse.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Service.Users.Commands
{
    public sealed class UnregisterCommandHandler : ICommandHandler<UnregisterUserCommand>
    {
        private readonly TransverseContext _context;
        private readonly IUserRepository _userRepository;

        public UnregisterCommandHandler(TransverseContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public Result Handle(UnregisterUserCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Result.Failure($"No user found for Id= {command.Id}");
            user.Unregister(command.By,command.Reason);
            _userRepository.Save();
            return Result.Ok();
        }
    }
}
