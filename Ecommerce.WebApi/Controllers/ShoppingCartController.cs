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

        // Endpoint to remove an item from the shopping cart by Id
        [HttpDelete("remove/{itemId}")]
        public IActionResult RemoveFromCart(int itemId)
        {
            // Find the item by Id and remove it from the cart
            var itemToRemove = cartItems.FirstOrDefault(item => item.Id == itemId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                return Ok();
            }
            else
            {
                return NotFound("Item not found in the cart.");
            }
        }

        // Endpoint to update an item in the shopping cart by Id
        [HttpPut("update/{itemId}")]
        public IActionResult UpdateCartItem(int itemId, ShoppingCartItem updatedItem)
        {
            // Find the item by Id and update its properties
            var itemToUpdate = cartItems.FirstOrDefault(item => item.Id == itemId);
            if (itemToUpdate != null)
            {
                // Update the properties of the item
                itemToUpdate.Id = updatedItem.Id;
                itemToUpdate.Quantity = updatedItem.Quantity;

                return Ok();
            }
            else
            {
                return NotFound("Item not found in the cart.");
            }
        }

    }

}
