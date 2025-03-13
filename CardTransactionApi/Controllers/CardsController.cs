using CardTransactionApi.Models;
using CardTransactionApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CardTransactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        public CardsController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _cardRepository.GetCardByIdAsync(id);
            if (card == null)
                return NotFound();
            return Ok(card);
        }
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            var id = await _cardRepository.AddCardAsync(card);
            card.Id = id;
            return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.Id)
                return BadRequest();
            var updated = await _cardRepository.UpdateCardAsync(card);
            if (!updated)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var deleted = await _cardRepository.DeleteCardAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
