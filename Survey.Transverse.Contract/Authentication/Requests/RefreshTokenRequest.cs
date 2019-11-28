using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Identity.Requests
{
   public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
