using LoanService.Application.Interfaces;
using LoanService.Domain.Entities;
using LoanService.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController(ILoanService loanService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(
        LoanStatus? status,
        decimal? minAmount,
        decimal? maxAmount,
        int? minTerm,
        int? maxTerm)
    {
        var loans = await loanService.GetAllAsync(status, minAmount, maxAmount, minTerm, maxTerm);

        return Ok(loans);
    }

    [HttpPost]
    public async Task<IActionResult> Create(LoanRequest request) 
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var loan = await loanService.CreateLoanAsync(request);
            return Ok(loan);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }   
    }

    [HttpPatch("{number}")]
    public async Task<IActionResult> Update(string number)
    {
        try
        {
            var loan = await loanService.ToggleStatusAsync(number);
            return Ok(loan);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
