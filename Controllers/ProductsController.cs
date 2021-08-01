using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Dtos;
using Shop.Repositories;
using System.Linq;
using Shop.Entities;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            var products = (await repository.GetProductsAsync()).Select(product => product.AsDto());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductAsync(Guid id)
        {
            var product = await repository.GetProductAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return product.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync(CreateProductDTO productDTO)
        {
            Product product = new()
            {
                Id = Guid.NewGuid(),
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
            };

            await repository.CreateProductAsync(product);

            return CreatedAtAction(nameof(CreateProductAsync), new { id = product.Id }, product.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, UpdateProductDTO productDTO)
        {
            var existingProduct = await repository.GetProductAsync(id);
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

            await repository.UpdateProductAsync(updatedProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var existingProduct = repository.GetProductAsync(id);
            if (existingProduct is null)
            {
                return NotFound();
            }

            repository.DeleteProductAsync(id);

            return NoContent();
        }
    }
}