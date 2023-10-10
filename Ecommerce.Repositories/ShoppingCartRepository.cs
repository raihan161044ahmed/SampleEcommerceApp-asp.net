using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repositories
{
    public class ShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public bool AddToCart(ShoppingCartItem cartItem)
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
    }
}
