using ErenBaba_Hafta2.Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenBaba_Hafta2.Domain
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}
