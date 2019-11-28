using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Users.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
