using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Users.Authentication.Commands
{
    public class SignInCommand : ICommand
    {
        public string Email { get; }
        public string Password { get; }

        public SignInCommand(string email,string password)
        {
            Email = email;
            Password = password;
        }

    }
}
