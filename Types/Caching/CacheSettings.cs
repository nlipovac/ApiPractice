using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types.Caching
{
    public class CacheSettings
    {
        public bool Local { get; set; }
        public bool Shared { get; set; }
        public Duration Duration { get; set; } = new Duration();
    }
}
