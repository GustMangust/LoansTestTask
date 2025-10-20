namespace LoanService.Domain.Entities;

public class LoanResponse
{
    public string Number { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public int TermValue { get; set; }

    public decimal InterestValue { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }
}
