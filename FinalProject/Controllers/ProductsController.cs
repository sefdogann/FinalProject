using Microsoft.AspNetCore.Mvc;
using FinalProject.Interfaces;
using FinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(product);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("over500")]
        public async Task<ActionResult<List<Product>>> GetProductsOver500TL()
        {
            var products = await _productService.GetProductsOver500TLAsync();
            return Ok(products);
        }
        [HttpGet("mostordered")]
        public async Task<ActionResult<Product>> GetMostOrderedProduct()
        {
            var product = await _productService.GetMostOrderedProductAsync();
            return Ok(product);
        }
        [HttpGet("totalstock")]
        public async Task<ActionResult<int>> GetTotalStock()
        {
            var totalStock = await _productService.GetTotalStockAsync();
            return Ok(totalStock);
        }



    }
}
