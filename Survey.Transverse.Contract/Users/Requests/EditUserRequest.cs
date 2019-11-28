using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Users.Requests
{
    public class EditUserRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<Guid> Permissions { get; set; }
        public bool DeleteExistingPermissions { get; set; }
        public EditUserRequest()
        {
            Permissions = new List<Guid>();
            DeleteExistingPermissions = false;
        }
    }
}
