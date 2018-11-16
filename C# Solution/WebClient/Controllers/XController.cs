using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Entity;
using ClassLibrary.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    [Produces("application/json")]
    [Route("api/X")]
    public class XController : Controller
    {
        private IProductRepositoryAsync productRepository;
        public XController(IProductRepositoryAsync
                                                  productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productRepository.SelectAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByName(string id)
        {
            var products = await productRepository.SelectByNameAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id:regex(^p\\d+$)}", Name = "GetProductsById")]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await productRepository.SelectByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
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
        public async Task<IActionResult> Update(string id, [FromBody] Product product)
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
        public async Task<IActionResult> Delete(string id)
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