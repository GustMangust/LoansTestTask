using AutoMapper;
using LoanService.Application.Interfaces;
using LoanService.Domain.Entities;
using LoanService.Domain.Enums;
using LoanService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Application.Services;

public class LoanService(LoanDbContext dbContext, IMapper mapper) : ILoanService
{
    public async Task<IEnumerable<LoanResponse>> GetAllAsync(
        LoanStatus? status,
        decimal? minAmount,
        decimal? maxAmount,
        int? minTerm,
        int? maxTerm)
    {
        var query = dbContext.Loans.AsQueryable();

        query = ApplyFilters(query, status, minAmount, maxAmount, minTerm, maxTerm);

        return mapper.Map<IEnumerable<LoanResponse>>(await query.ToListAsync());
    }

    public async Task<LoanResponse> CreateLoanAsync(LoanRequest request)
    {
        bool exists = await dbContext.Loans.AnyAsync(l => l.Number == request.Number);

        if (exists)
            throw new InvalidOperationException($"Loan with {request.Number} number exists");

        var loan = new Loan
        {
            Number = request.Number,
            Amount = request.Amount,
            TermValue = request.TermValue,
            InterestValue = request.InterestValue,
        };

        await dbContext.Loans.AddAsync(loan);
        await dbContext.SaveChangesAsync();

        return mapper.Map<LoanResponse>(loan);
    }

    public async Task<LoanResponse> ToggleStatusAsync(string number)
    {
        var loan = await dbContext.Loans.FindAsync(number) ?? throw new KeyNotFoundException("Loan is not found");

        loan.Status = loan.Status == LoanStatus.Published ? LoanStatus.Unpublished : LoanStatus.Published;

        loan.ModifiedAt = DateTimeOffset.Now;

        await dbContext.SaveChangesAsync();

        return mapper.Map<LoanResponse>(loan);
    }

    private IQueryable<Loan> ApplyFilters(
        IQueryable<Loan> query,
        LoanStatus? status,
        decimal? minAmount,
        decimal? maxAmount,
        int? minTerm,
        int? maxTerm)
    {
        if (status.HasValue)
            query = query.Where(l => l.Status == status.Value);

        if (minAmount.HasValue)
            query = query.Where(l => l.Amount >= minAmount.Value);

        if (maxAmount.HasValue)
            query = query.Where(l => l.Amount <= maxAmount.Value);

        if (minTerm.HasValue)
            query = query.Where(l => l.TermValue >= minTerm.Value);

        if (maxTerm.HasValue)
            query = query.Where(l => l.TermValue <= maxTerm.Value);

        return query;
    }
}
