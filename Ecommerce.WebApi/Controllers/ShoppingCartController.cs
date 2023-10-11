using Ecommerce.Repositories;
using Ecommerce.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartRepository _cartRepository;

        public ShoppingCartController(ShoppingCartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost("add")]
        public IActionResult AddToCart(ShoppingCartItem item)
        {
            bool isSuccess = _cartRepository.Add(item);

            if (isSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to add item to the cart.");
            }
        }

        [HttpGet("items")]
        public IActionResult GetCartItems()
        {
            List<ShoppingCartItem> cartItems = _cartRepository.GetCartItems().ToList();
            return Ok(cartItems);
        }

        [HttpDelete("remove/{itemId}")]
        public IActionResult RemoveFromCart(int itemId)
        {
            bool isSuccess = _cartRepository.RemoveFromCart(itemId);

            if (isSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound("Item not found in the cart.");
            }
        }

        [HttpPut("update/{itemId}")]
        public IActionResult UpdateCartItem(int itemId, ShoppingCartItem updatedItem)
        {
            bool isSuccess = _cartRepository.UpdateCartItem(itemId, updatedItem);

            if (isSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound("Item not found in the cart.");
            }
        }
    }
}
