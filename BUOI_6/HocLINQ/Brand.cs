using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HocLINQ
{
    public class Brand
    {
        public int BrandID { get; set; }
        public int BrandId { get; internal set; }
        public string? BrandName { get; set; }
    }
}
