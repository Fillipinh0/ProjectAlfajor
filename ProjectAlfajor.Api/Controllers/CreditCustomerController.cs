using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAlfajor.Api.Data;
using ProjectAlfajor.Api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectAlfajor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCustomerController : ControllerBase
    {

        private readonly AppDbContext _context;
        public CreditCustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CreditCustomer>>> GetCreditCustomers()
        {
            var creditCustomers = await _context.CreditCustomers.OrderBy(p => p.SaleDate).ToListAsync();

            return Ok(creditCustomers);
        }

        [HttpGet("NotPaid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CreditCustomer>>> GetCreditCustomersNotPaid()
        {
            var creditCustomers = await _context.CreditCustomers.Where(p => p.IsPaid == false).ToListAsync();

            return Ok(creditCustomers);
        }

        [HttpGet("isPaid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CreditCustomer>>> GetCreditCustomersIsPaid()
        {
            var creditCustomers = await _context.CreditCustomers.Where(p => p.IsPaid == true).ToListAsync();

            return Ok(creditCustomers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreditCustomer>> GetCreditCustomer(int id)
        {
            var creditCustumer = await _context.CreditCustomers.FindAsync(id);

            if(creditCustumer is null) return NotFound($"Credit customer id:{id} not found.");

            return Ok(creditCustumer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreditCustomer>> PostCrediteCustomer([FromBody] CreditCustomer crediteCustomer)
        {
            if (crediteCustomer is null) return BadRequest("Invalid credit customer data.");
            _context.CreditCustomers.Add(crediteCustomer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return BadRequest("Unable to save credite customer. Please check the details and try again.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno ao criar o cliente de crédito.");
            }

            return CreatedAtAction(nameof(GetCreditCustomer), new { id = crediteCustomer.CreditCustomerId}, crediteCustomer);
        }

        [HttpPut("{id}")] //Cara, sempre lemra o Unico dado que importa aq [e o ID pq a unica coisa que tu precisa atualizar no devedor [e a se ele apgou ou n
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCrediteCustomer(int id)
        {
            var crediteCustomer = await _context.CreditCustomers.FindAsync(id);

            if (crediteCustomer is null) return NotFound($"Credit customer id:{id} not found.");

            crediteCustomer.IsPaid = true;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCrediteCustomer(int id)
        {
            var crediteCustomer = await _context.CreditCustomers.FindAsync(id);
            
            if (crediteCustomer is null) return NotFound($"Credit customer id:{id} not found.");

            _context.CreditCustomers.Remove(crediteCustomer);
          
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
