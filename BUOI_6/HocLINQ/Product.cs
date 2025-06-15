using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HocLINQ
{
    public class Product
    {
        public int ProductID { get; set; }
        public int ProductId { get; internal set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public string? colors { get; set; }
        public string[] Colors { get; internal set; }
        public int BrandID { get; set; }
        public int BrandId { get; internal set; }
    }
}
