using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Sample data
        private static readonly List<string> products = new List<string>
        {
            "Laptop", "Phone", "Tablet"
        };

        // GET: api/products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound("Product not found");

            return Ok(products[id]);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult AddProduct([FromBody] string product)
        {
            products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = products.Count - 1 }, product);
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound("Product not found");

            products.RemoveAt(id);
            return NoContent();
        }
    }
}
