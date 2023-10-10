using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Models
{
    public class ProductEdit
    {
        public int Id { get; set; } // Add the Id property for storing the product identifier
        [Required(ErrorMessage = "Please provide name.")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public string Description { get; set; }
    }
}
