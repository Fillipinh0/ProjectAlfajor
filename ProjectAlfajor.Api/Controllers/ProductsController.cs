using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAlfajor.Api.Data;
using ProjectAlfajor.Api.DTOs;
using ProjectAlfajor.Api.Models;

namespace ProjectAlfajor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;


        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/products
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var produto = await _context.Products.OrderBy(p => p.PurchaseDate).ToListAsync();

            //Tirei o if is null por que uma lista vazia nao [e erro [e simplismente pq ela nao tem nada kkkk
            
            return Ok(produto);
        }

        //Get: api/products/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null) return NotFound($"Product id:{id} not found."); // Produto não encontrado
            return Ok(product);
        }

        //Post: /api/products
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostProduct([FromBody] ProductCreateDTO productDTO)
        {
            if (productDTO is null) return BadRequest($"Invalid product data. {productDTO}");

            var product = new Product
            {
                Name = productDTO.Name,
                UnitPrice = productDTO.UnitPrice,
                PurchaseDate = productDTO.PurchaseDate.Date,
                Quantity = productDTO.Quantity,
                TotalPurchaseValue = productDTO.UnitPrice * productDTO.Quantity
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        //Put /api/products/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutProduct(int id, [FromBody] ProductCreateDTO updatedData)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null) return NotFound($"Product id:{id} not found.");

            product.Name = updatedData.Name;
            product.UnitPrice = updatedData.UnitPrice;
            product.PurchaseDate = updatedData.PurchaseDate.Date;
            product.Quantity = updatedData.Quantity;
            product.TotalPurchaseValue = updatedData.UnitPrice * updatedData.Quantity;

            await _context.SaveChangesAsync();

            return NoContent(); // 204 - sucesso sem conteúdo de volta

        }

        //Delete /api/prodcuts/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null) return NotFound($"Product id:{id} not found.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 - sucesso sem conteúdo de volta
        }



    }
}
