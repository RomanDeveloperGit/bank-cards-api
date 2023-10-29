using System.ComponentModel.DataAnnotations;

namespace BankCardsApi.Controllers.Dto
{
  public class GetCardsByOwnerDto
  {
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя владельца должно быть от 2 до 50 символов.")]
    public required string OwnerFirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия владельца должна быть от 2 до 50 символов.")]
    public required string OwnerLastName { get; set; }
  }
}
