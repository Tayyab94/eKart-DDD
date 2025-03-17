using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Infrastructure.Options
{
    public class DatabaseOptions
    {
        public string? ConnectionString { get; set; } = string.Empty;

        public int MaxRetryCount { get; set; }
        public int CommandTimeout { get; set; }
            public int MaxrRetryDelay { get; set; }
    }
}
