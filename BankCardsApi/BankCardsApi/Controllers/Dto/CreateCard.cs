using System.ComponentModel.DataAnnotations;

namespace BankCardsApi.Controllers.Dto
{
  public class CreateCardDto
  {
    [Required]
    [RegularExpression(@"^(?:\d{13}|\d{16}|\d{18}|\d{19})$", ErrorMessage = "Номер карты должен содержать 13, 16, 18 или 19 цифр.")]
    public required string Number { get; set; }

    [Required]
    [RegularExpression(@"^\d{3}$", ErrorMessage = "CVV должен содержать ровно 3 цифры.")]
    public required string CVV { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя владельца должно быть от 2 до 50 символов.")]
    public required string OwnerFirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия владельца должна быть от 2 до 50 символов.")]
    public required string OwnerLastName { get; set; }
  }
}
