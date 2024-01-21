using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.CardDetailAggregate.EndPoints;

public record CardDetailRequest
{

    public CardDetailRequest(string _CardNumber, DateTime _ExpieryDate, string _CardVerificationValue)
    {
        CardNumber = _CardNumber;
        ExpieryDate = _ExpieryDate;
        CardVerificationValue = _CardVerificationValue;
    }


    [StringLength(16)]
    public string CardNumber { get; }

    [Required]
    public DateTime ExpieryDate { get; }

    [Required]
    [StringLength(3, ErrorMessage = "Need 3 chars", MinimumLength = 3)]
    public string CardVerificationValue { get; }

}
