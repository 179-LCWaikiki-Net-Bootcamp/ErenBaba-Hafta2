using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErenBaba_Hafta2.API.Models
{
    public class ProductQueryDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
    }
}
