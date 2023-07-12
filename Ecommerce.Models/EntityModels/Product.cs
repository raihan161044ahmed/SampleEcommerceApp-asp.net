using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.EntityModels
{
    public class Product
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string? Description { get; set; }
        
    }
}
