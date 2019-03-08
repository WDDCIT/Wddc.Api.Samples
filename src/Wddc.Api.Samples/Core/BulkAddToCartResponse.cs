using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wddc.Api.Samples.Core
{
    public class BulkAddToCartResponse
    {
        public bool Success { get; set; }
        public List<string> Products { get; set; }
        public string Error { get; set; }
    }
}
