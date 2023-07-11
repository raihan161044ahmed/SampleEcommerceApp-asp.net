using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class CustomerRepository
    {
        ApplicationDbContext _db;

        public CustomerRepository()
        {
            _db = new ApplicationDbContext();
        }

        public bool Add(Customer Customer)
        {
            _db.Customers.Add(Customer);
            return _db.SaveChanges() > 0;
        }

        public bool AddRange(ICollection<Customer> Customers)
        {
            _db.Customers.AddRange(Customers);
            return _db.SaveChanges() > 0;
        }

        public bool Update(Customer Customer)
        {
            _db.Customers.Update(Customer);

            return _db.SaveChanges() > 0;
        }

        public bool UpdateRange(ICollection<Customer> Customers)
        {
            _db.Customers.UpdateRange(Customers);
            return _db.SaveChanges() > 0;
        }

        public bool Delete(Customer Customer)
        {
            _db.Customers.Remove(Customer);
            return _db.SaveChanges() > 0;
        }

        public Customer GetById(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }
    }
}
