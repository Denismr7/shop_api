using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Dtos;
using Shop.Repositories;
using System.Linq;
using Shop.Entities;

namespace Shop.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository repository;
        public ProductsController(IProductsRepository repository) {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = repository.GetProducts().Select(product => product.AsDto());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProduct(Guid id)
        {
            var product = repository.GetProduct(id);
            if (product is null)
            {
                return NotFound();
            }

            return product.AsDto();
        }

        [HttpPost]
        public ActionResult CreateProduct(CreateProductDTO productDTO)
        {
            Product product = new()
            {
                Id = Guid.NewGuid(),
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
            };

            repository.CreateProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(Guid id, UpdateProductDTO productDTO)
        {
            var existingProduct = repository.GetProduct(id);
            if (existingProduct is null)
            {
                return NotFound();
            }

            var updatedProduct = existingProduct with
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
            };

            repository.UpdateProduct(updatedProduct);

            return NoContent();
        }

        [HttpDelete("{id")]
        public ActionResult DeleteProduct(Guid id)
        {
            var existingProduct = repository.GetProduct(id);
            if (existingProduct is null)
            {
                return NotFound();
            }

            repository.DeleteProduct(id);

            return NoContent();
        }
    }
}