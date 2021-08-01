using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Dtos;
using Shop.Repositories;
using System.Linq;

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
    }
}