using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users.Authentication.Commands;
using System;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Infrastracture.Data;


namespace Survey.Transverse.Service.Authentication.Commands
{
    public sealed class SignOutCommandHandler : ICommandHandler<SignOutCommand>
    {
        private readonly TransverseContext _context;
        private readonly IUserRepository _userRepository;

        public SignOutCommandHandler(TransverseContext context,
                                    IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        public Result Handle(SignOutCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Result.Failure($"No user found for {command.Id}");
            user.SetLastConnexionDate();
            _userRepository.Save();
            return Result.Ok();
        }
    }
}
