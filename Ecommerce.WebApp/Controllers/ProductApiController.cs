using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Ecommerce.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductApiController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductApiController()
        {
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDetails>> Get()
        {
            var products = _productRepository.GetAll();

            var productDetailsList = new List<ProductDetails>();
            foreach (var product in products)
            {
                var productDetails = new ProductDetails()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description
                };

                productDetailsList.Add(productDetails);
            }

            return Ok(productDetailsList);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDetails> Get(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDetails = new ProductDetails()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            return Ok(productDetails);
        }

        [HttpPost]
        public ActionResult<string> Post(ProductCreate model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                };

                // Database operations
                bool isSuccess = _productRepository.Add(product);

                if (isSuccess)
                {
                    return Ok("Product created successfully.");
                }
            }

            return BadRequest("Invalid model data.");
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, ProductEdit model)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _productRepository.GetById(id);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = model.Name;
                existingProduct.Price = model.Price;
                existingProduct.Description = model.Description;

                // Database operations
                bool isSuccess = _productRepository.Update(existingProduct);

                if (isSuccess)
                {
                    return Ok("Product updated successfully.");
                }
            }

            return BadRequest("Invalid model data.");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            bool isSuccess = _productRepository.Delete(product);

            if (isSuccess)
            {
                return Ok("Product deleted successfully.");
            }

            return BadRequest("Failed to delete product.");
        }
    }
}
