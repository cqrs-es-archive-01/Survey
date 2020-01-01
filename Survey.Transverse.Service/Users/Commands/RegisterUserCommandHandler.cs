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
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly TransverseContext _context;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(TransverseContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public Result Handle(RegisterUserCommand command)
        {
            var user = new User(command.FirstName, command.LastName, command.Email, command.Password, command.Permissions);
            _userRepository.Insert(user);
            if (!_userRepository.Save())
            {
                return Result.Failure("User could not be saved");
            }
            return Result.Ok();
        }
    }
}
