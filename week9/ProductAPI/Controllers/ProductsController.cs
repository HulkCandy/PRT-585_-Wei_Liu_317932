using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductAPIContext _context;
        private readonly IDataRepository<Product> _repo;

        public ProductsController(ProductAPIContext context, IDataRepository<Product> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {
            return  _context.Product.OrderByDescending(p => p.ProductID);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _repo.Update(product);
                var save = await _repo.SaveAsync(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //data repository
            _repo.Add(product);
            var save = await _repo.SaveAsync(product);

            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _repo.Delete(product);
            var save = await _repo.SaveAsync(product);

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
