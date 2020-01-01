using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using Survey.Transverse.Infrastracture.Data;

namespace Survey.Transverse.Service.Users.Commands
{
    public sealed class EditUserCommandHandler : ICommandHandler<EditUserCommand>
    {
        private readonly TransverseContext _context;
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(TransverseContext context,
                                      IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public Result Handle(EditUserCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Result.Failure($"No user found for Id= {command.Id}");
            user.EditUser(command.FirstName, command.LastName, command.Email, command?.Permissions, command.DeleteExistingPermission);
            _userRepository.UpdatePermissions(user, command.DeleteExistingPermission);
            if (!_userRepository.Save())
                return Result.Failure($"No user found for Id= {command.Id}");
            return Result.Ok();
        }
    }
}
