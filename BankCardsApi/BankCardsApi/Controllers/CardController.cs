using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankCardsApi.Data;
using BankCardsApi.Models;
using BankCardsApi.Controllers.Dto;

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
    public async Task<ActionResult<Card>> CreateCard([FromBody] CreateCardDto dto)
    {
      var card = new Card
      {
        Number = dto.Number,
        CVV = dto.CVV,
        ExpirationDate = DateTime.UtcNow.AddYears(3),
        OwnerFirstName = dto.OwnerFirstName,
        OwnerLastName = dto.OwnerLastName
      };

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

    [HttpGet("{id}")]
    public async Task<ActionResult<Card>> GetCardById(int id)
    {
      var card = await _context.Cards.FindAsync(id);

      if (card == null)
      {
        return NotFound();
      }

      return Ok(card);
    }

    [HttpGet]
    public async Task<ActionResult<Card>> GetCardByNumber([FromQuery] GetCardByNumberDto dto)
    {
      var card = await _context.Cards.FirstOrDefaultAsync(c => c.Number == dto.Number);

      if (card == null)
      {
        return NotFound();
      }

      return Ok(card);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> GetCardsByOwner([FromQuery] GetCardsByOwnerDto dto)
    {
      var cards = await _context.Cards
          .Where(c => c.OwnerFirstName == dto.OwnerFirstName && c.OwnerLastName == dto.OwnerLastName)
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCard(int id)
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
