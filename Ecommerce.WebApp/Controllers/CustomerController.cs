using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            // Retrieve the customer by id
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            // Map the customer to the CustomerEdit model
            var model = new CustomerDetails()
            {
                Id = customer.Id,
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email
            };

            return View(model);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCreate model)
        {

            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,
                };
                //Database operations 
                bool isSuccess = _customerRepository.Add(customer);

                if (isSuccess)
                {
                    return RedirectToAction("Show");
                }
               
            }
            
            return View();
          
        }
        public IActionResult Show()
        {
            var customers = _customerRepository.GetAll();

            return View(customers);
        }
        public IActionResult Delete(int id)
        {
            // Retrieve the customer by id
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            // Database operations 
            bool isSuccess = _customerRepository.Delete(customer);

            if (isSuccess)
            {
                return RedirectToAction("Show");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            // Retrieve the customer by id
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            // Map the customer to the CustomerEdit model
            var model = new CustomerEdit()
            {
                Id = customer.Id,
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CustomerEdit model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing customer by id
                var existingCustomer = _customerRepository.GetById(model.Id);

                if (existingCustomer == null)
                {
                    return NotFound();
                }

                // Update the properties of the existing customer
                existingCustomer.Name = model.Name;
                existingCustomer.Phone = model.Phone;
                existingCustomer.Email = model.Email;

                // Database operations
                bool isSuccess = _customerRepository.Update(existingCustomer);

                if (isSuccess)
                {
                    return RedirectToAction("Show");
                }
            }

            return View();
        }

    }
}
