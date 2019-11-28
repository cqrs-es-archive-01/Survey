using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Users.Requests
{
    public class UserRegistrationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Guid> Permissions { get; set; }

        public UserRegistrationRequest()
        {
            Permissions = new List<Guid>();
        }

    }
}
