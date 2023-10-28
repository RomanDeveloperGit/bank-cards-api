using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
  }
}
