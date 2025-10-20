using LoanService.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LoanService.Domain.Entities;

public class Loan
{
    [Key]
    public required string Number { get; set; }

    public LoanStatus Status { get; set; } = LoanStatus.Published;

    public decimal Amount { get; set; }

    public int TermValue { get; set; }

    public decimal InterestValue { get; set; }

    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.Now;

    public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.Now;
}
