using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public bool Add(Category category)
        {
            _db.Categories.Add(category);
            return _db.SaveChanges() > 0;
        }

        public bool AddRange(ICollection<Category> categories)
        {
            _db.Categories.AddRange(categories);
            return _db.SaveChanges() > 0;
        }

        public bool Update(Category category)
        {
            _db.Categories.Update(category);
            return _db.SaveChanges() > 0;
        }

        public bool UpdateRange(ICollection<Category> categories)
        {
            _db.Categories.UpdateRange(categories);
            return _db.SaveChanges() > 0;
        }

        public bool Delete(Category category)
        {
            _db.Categories.Remove(category);
            return _db.SaveChanges() > 0;
        }

        public Category GetById(int code)
        {
            return _db.Categories.FirstOrDefault(c => c.Code == code);
        }

        public ICollection<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}
