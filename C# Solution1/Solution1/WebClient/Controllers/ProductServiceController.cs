using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Entity;
using ClassLibrary.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceController : ControllerBase
    {
        private IProductRepositoryAsync productRepository;

        public ProductServiceController(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await productRepository.SelectAllAsync();
            return Ok(products);
        }

        // "{id}" is a placeholder variable for the ID of the Product 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByNameAsync(string id)
        {
            var products = await productRepository.SelectByNameAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        //
        [HttpGet("{id:regex(^p\\d+$)}", Name = "GetProductsById")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var item = await productRepository.SelectByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(ModelState);
            }

            bool created = await productRepository.CreateAsync(product);
            if (!created)
            {
                return BadRequest($"{product.Id} already exists");
            }

            return CreatedAtRoute("GetProductsById", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] Product product)
        {
            if (product == null || product.Id != id)
            {
                return BadRequest();
            }

            bool updated = await productRepository.UpdateAsync(product);
            if (!updated)
            {
                return NotFound();
            }

            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            bool deleted = await productRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return new NoContentResult();
        }
    }
}
