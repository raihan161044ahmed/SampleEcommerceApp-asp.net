using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.EntityModels
{
    public class Category
    {
        [Key]
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
