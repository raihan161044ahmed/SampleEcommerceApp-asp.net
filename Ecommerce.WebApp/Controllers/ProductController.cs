using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            // Retrieve the customer by id
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            // Map the customer to the CustomerEdit model
            var model = new ProductDetails()
            {
                Id = product.Id,
                Name = product.Name,
                Price =product.Price,
                Description =product.Description
            };

            return View(model);
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreate model)
        {

            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                };
                //Database operations 
                bool isSuccess = _productRepository.Add(product);

                if (isSuccess)
                {
                    return RedirectToAction("Show");
                }

            }

            return View();
        }
        public IActionResult Show()
        {          
            var products = _productRepository.GetAll();   

            return View(products);
        }
        public IActionResult Delete(int id)
        {
            // Retrieve the product by id
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            // Database operations 
            bool isSuccess = _productRepository.Delete(product);

            if (isSuccess)
            {
                return RedirectToAction("Show");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            // Retrieve the product by id
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            // Map the product to the ProductEdit model
            var model = new ProductEdit()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductEdit model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing product by id
                var existingProduct = _productRepository.GetById(model.Id);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Update the properties of the existing product
                existingProduct.Name = model.Name;
                existingProduct.Price = model.Price;
                existingProduct.Description = model.Description;

                // Database operations 
                bool isSuccess = _productRepository.Update(existingProduct);

                if (isSuccess)
                {
                    return RedirectToAction("Show");
                }
            }

            return View();
        }


    }
}
