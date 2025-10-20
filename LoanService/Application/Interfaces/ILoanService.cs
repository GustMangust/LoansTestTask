using LoanService.Domain.Entities;
using LoanService.Domain.Enums;

namespace LoanService.Application.Interfaces;

public interface ILoanService
{
    Task<IEnumerable<LoanResponse>> GetAllAsync(
        LoanStatus? status,
        decimal? minAmount,
        decimal? maxAmount,
        int? minTerm,
        int? maxTerm);
    Task<LoanResponse> CreateLoanAsync(LoanRequest request);
    Task<LoanResponse> ToggleStatusAsync(string number);
}
