using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users.Authentication.Commands;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Infrastracture.Data;


namespace Survey.Transverse.Service.Authentication.Commands
{
    public sealed class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly TransverseContext _context;
        private readonly IUserRepository _userRepository;


        public ChangePasswordCommandHandler(TransverseContext context,
                                            IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public Result Handle(ChangePasswordCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Result.Failure($"No user found for Id={command.Id}");

            if (!user.VerifyPassword(command.OldPassword))
                return Result.Failure("Incorrect password");
            else
                user.SetPassword(command.NewPassword);

            if (!_userRepository.Save())
            {
                return Result.Failure("Cound not update user password");
            }
            return Result.Ok();
        }
    }
}
