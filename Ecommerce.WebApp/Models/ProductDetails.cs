namespace Ecommerce.WebApp.Models
{
    public class ProductDetails
    {
        public int Id { get; set; } // Add the Id property for storing the product identifier
 
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
    }
}
