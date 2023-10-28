using System.Security.Cryptography.X509Certificates;

namespace BankCardsApi.Models
{
  public class Card
  {
    public int Id { get; set; }
    public required string Number { get; set; }
    public required string CVV { get; set; }
    public required DateTime ExpirationDate { get; set; }
    public required string OwnerFirstName { get; set; }
    public required string OwnerLastName { get; set; }
  }
}
