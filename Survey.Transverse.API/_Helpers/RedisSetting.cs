using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.API._Helpers
{
    public class RedisSetting
    {
        public bool Enabled { get; set; }

        public string ConnectionString { get; set; }
    }
}
