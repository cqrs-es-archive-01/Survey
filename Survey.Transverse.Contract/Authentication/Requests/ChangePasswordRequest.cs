using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Authentication.Requests
{
   public sealed  class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
