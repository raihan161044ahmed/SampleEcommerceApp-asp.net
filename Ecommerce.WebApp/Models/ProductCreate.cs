using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models
{
    public class ProductCreate
    {
        [Required(ErrorMessage = "Please provide name.")]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
