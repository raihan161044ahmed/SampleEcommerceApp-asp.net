using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Models
{
    public class CustomerEdit
    {
        public int Id { get; set; } // Add the Id property for storing the product identifier
        [Required(ErrorMessage = "Please provide name.")]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
