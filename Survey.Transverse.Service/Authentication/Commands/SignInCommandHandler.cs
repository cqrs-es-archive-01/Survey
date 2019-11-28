using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Authentication.Commands;
using System.Linq;
using Survey.Transverse.Infrastracture.Data;

namespace Survey.Transverse.Service.Authentication.Commands
{
    public sealed class SignInCommandHandler : ICommandHandler<SignInCommand>
    {
        private readonly TransverseContext _context;
        private readonly IUserRepository _userRepository;

        public SignInCommandHandler(TransverseContext context,
                                    IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public Result Handle(SignInCommand command)
        {
            var user = _userRepository.FindBy(a => a.Email == command.Email).FirstOrDefault();
            if (user == null)
                return Result.Failure("No user found for Email/Password");
            else
            {
                if (!user.VerifyPassword(command.Password))
                    return Result.Failure("Incorrect password");
            }
            return Result.Ok();
        }
    }
}
