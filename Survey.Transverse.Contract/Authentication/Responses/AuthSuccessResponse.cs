using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Identity.Responses
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
