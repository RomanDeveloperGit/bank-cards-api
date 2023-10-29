using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankCardsApi.Data;
using BankCardsApi.Models;

namespace BankCardsApi.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class CardController : ControllerBase
  {
    private readonly ApiContext _context;

    public CardController(ApiContext context)
    {
      _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Card>> CreateCard([FromBody] Card card)
    {
      _context.Cards.Add(card);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCardById", new { id = card.Id }, card);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> GetAllCards()
    {
      var cards = await _context.Cards.ToListAsync();

      if (cards == null || !cards.Any())
      {
        return NotFound();
      }

      return Ok(cards);
    }

    [HttpGet]
    public async Task<ActionResult<Card>> GetCardById([FromQuery] int id)
    {
      var card = await _context.Cards.FindAsync(id);

      if (card == null)
      {
        return NotFound();
      }

      return Ok(card);
    }

    [HttpGet]
    public async Task<ActionResult<Card>> GetCardByNumber([FromQuery] string number)
    {
      var card = await _context.Cards.FirstOrDefaultAsync(c => c.Number == number);

      if (card == null)
      {
        return NotFound();
      }

      return Ok(card);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> GetCardsByOwner([FromQuery] string firstName, [FromQuery] string lastName)
    {
      var cards = await _context.Cards
          .Where(c => c.OwnerFirstName == firstName && c.OwnerLastName == lastName)
          .ToListAsync();

      if (cards == null || !cards.Any())
      {
        return NotFound();
      }

      return Ok(cards);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpirationDate(int id)
    {
      var card = await _context.Cards.FindAsync(id);

      if (card == null)
      {
        return NotFound();
      }

      card.ExpirationDate = DateTime.Now.AddYears(3);

      _context.Cards.Update(card);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCard([FromQuery] int id)
    {
      var card = await _context.Cards.FindAsync(id);

      if (card == null)
      {
        return NotFound();
      }

      _context.Cards.Remove(card);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
