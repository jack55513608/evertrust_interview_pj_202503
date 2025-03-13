using CardTransactionApi.Models;
using CardTransactionApi.Services;
using CardTransactionApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CardTransactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardTransaction>>> GetTransactions()
        {
            var transactions = await _transactionService.GetTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardTransaction>> GetTransaction(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null)
                return NotFound();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<CardTransaction>> PostTransaction(CardTransaction transaction)
        {
            var id = await _transactionService.AddTransactionAsync(transaction);
            transaction.Id = id;
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, CardTransaction transaction)
        {
            if (id != transaction.Id)
                return BadRequest();
            var updated = await _transactionService.UpdateTransactionAsync(transaction);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var deleted = await _transactionService.DeleteTransactionAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<CardTransaction>>> GetTransactionsByUserId(Guid userId)
        {
            var transactions = await _transactionService.GetTransactionsByUserIdAsync(userId);
            return Ok(transactions);
        }
    }
}
