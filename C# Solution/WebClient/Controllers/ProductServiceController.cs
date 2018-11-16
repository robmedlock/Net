using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Entity;
using ClassLibrary.ServiceInterfaces;
using ClassLibrary.RepositoryInterfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebClient.Controllers
{
    //Route attribute defines path api/productservice
    [Route("api/[controller]")]
    public class ProductServiceController : Controller
    {
        private IProductRepositoryAsync productRepository;

        public ProductServiceController(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productRepository.SelectAllAsync();
            return Ok(products);
        }

        // "{id}" is a placeholder variable for the ID of the Product 
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

        //
        [HttpGet("{id:regex(^p\\d+$)}", Name = "GetProductsById")]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await productRepository.SelectByIdAsync(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (product == null )
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
