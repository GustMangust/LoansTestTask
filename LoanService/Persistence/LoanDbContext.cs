using LoanService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Persistence;

public class LoanDbContext(DbContextOptions<LoanDbContext> options): DbContext(options)
{
    public DbSet<Loan> Loans { get; set; }
}
