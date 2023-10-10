using Ecommerce.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private List<ShoppingCartItem> cartItems = new List<ShoppingCartItem>();

        // Endpoint to add items to the shopping cart
        [HttpPost("add")]
        public IActionResult AddToCart(ShoppingCartItem item)
        {        
            cartItems.Add(item);

            return Ok();
        }

        // Endpoint to get the contents of the shopping cart
        [HttpGet("items")]
        public IActionResult GetCartItems()
        {
            // Return the list of items in the shopping cart
            return Ok(cartItems);
        }

        // Add more endpoints for updating and removing items as needed
    }

}
