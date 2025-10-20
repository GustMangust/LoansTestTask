using System.ComponentModel.DataAnnotations;

namespace LoanService.Domain.Entities;

public class LoanRequest
{
    public required string Number { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int TermValue { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal InterestValue { get; set; }
}
