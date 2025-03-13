using CardTransactionApi.Models;
using CardTransactionApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardTransactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("{CardNumber}")]
        public async Task<ActionResult<Card>> GetCard(string CardNumber)
        {
            var card = await _cardService.GetCardByNumberAsync(CardNumber);
            if (card == null)
                return NotFound();
            return Ok(card);
        }

        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(PostCardRequest request)
        {
            var card = new Card { 
                CardNumber = request.CardNumber,
                Name = request.Name,
                Specification = request.Specification
                };
            var id = await _cardService.AddCardAsync(card);
            return CreatedAtAction(nameof(GetCard), new { id }, card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.Id)
                return BadRequest();
            var updated = await _cardService.UpdateCardAsync(card);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var deleted = await _cardService.DeleteCardAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
