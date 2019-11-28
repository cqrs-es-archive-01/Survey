using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Identity.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
