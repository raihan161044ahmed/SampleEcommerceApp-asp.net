using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repositories
{
    public class ShoppingCartRepository
    {
        ApplicationDbContext _db;

        public ShoppingCartRepository()
        {
            _db = new ApplicationDbContext();
        }

        public bool Add(ShoppingCartItem cartItem)
        {
            _db.ShoppingCartItems.Add(cartItem);
            return _db.SaveChanges() > 0;
        }

        public bool RemoveFromCart(int cartItemId)
        {
            var cartItem = _db.ShoppingCartItems.FirstOrDefault(item => item.Id == cartItemId);

            if (cartItem != null)
            {
                _db.ShoppingCartItems.Remove(cartItem);
                return _db.SaveChanges() > 0;
            }

            return false;
        }

        public ICollection<ShoppingCartItem> GetCartItems()
        {
            return _db.ShoppingCartItems.ToList();
        }

        public bool UpdateCartItem(int itemId, ShoppingCartItem updatedItem)
        {
            var itemToUpdate = _db.ShoppingCartItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToUpdate != null)
            {
                // Update the properties of the item
                itemToUpdate.Quantity = updatedItem.Quantity;

                _db.Entry(itemToUpdate).State = EntityState.Modified;
                return _db.SaveChanges() > 0;
            }

            return false;
        }
    }
}
