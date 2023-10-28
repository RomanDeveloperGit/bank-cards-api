using Microsoft.EntityFrameworkCore;
using BankCardsApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace BankCardsApi.Data
{
  public class ApiContext : DbContext
  {
    public DbSet<Card> Cards { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
  }
}
