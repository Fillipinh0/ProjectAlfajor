using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAlfajor.Api.Data;
using ProjectAlfajor.Api.Models;

namespace ProjectAlfajor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailySaleController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DailySaleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DailySale>>> GetDailySales()
        {
            var dailySales = await _context.DailySales.OrderBy(p => p.Date).ToListAsync();

            return Ok(dailySales);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DailySale>> GetDailySale(int id)
        {
            var dailySale = await _context.DailySales.FindAsync(id);

            if (dailySale is null) return NotFound($"Daily sale id:{id} not found.");

            return Ok(dailySale);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostDailySale([FromBody]DailySale dailySale)
        {
            if (dailySale is null) return BadRequest("Invalid daily sales data.");
            
            _context.DailySales.Add(dailySale);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDailySale), new { id = dailySale.DailySaleId }, dailySale);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutDailySale(int id, [FromBody]DailySale dailySale)
        {
            if(dailySale is null) return BadRequest("Invalid daily sales data.");
            
            var putDailySale = await _context.DailySales.FindAsync(id);
            
            if (putDailySale is null) return NotFound($"Daily sale id:{id} not found.");

            putDailySale.Date = dailySale.Date;
            putDailySale.QuantitySold = dailySale.QuantitySold;
            putDailySale.QuantityLeft = dailySale.QuantityLeft;
            putDailySale.TotalReceived = dailySale.TotalReceived;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteDailySale(int id)
        {
            var dailySale = await _context.DailySales.FindAsync(id);

            if (dailySale is null) return NotFound($"Daily sale id:{id} not found.");

            _context.DailySales.Remove(dailySale);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
