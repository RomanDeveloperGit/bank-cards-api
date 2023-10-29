using System.ComponentModel.DataAnnotations;

namespace BankCardsApi.Controllers.Dto
{
  public class GetCardByNumberDto
  {
    [Required]
    [RegularExpression(@"^(?:\d{13}|\d{16}|\d{18}|\d{19})$", ErrorMessage = "Номер карты должен содержать 13, 16, 18 или 19 цифр.")]
    public required string Number { get; set; }
  }
}
