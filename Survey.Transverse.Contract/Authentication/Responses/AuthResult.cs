using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Identity.Responses
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Successed { get; set; }
        public IEnumerable<string>  Errors { get; set; }
    }
}
