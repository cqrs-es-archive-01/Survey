using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract.Users.Requests
{
    public class UnregisterRequest
    {
        public Guid By { get; set; }
        public string Reason { get; set; }
    }
}
