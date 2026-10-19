using LoanApplicationService.Api.Models;

namespace LoanApplicationService.Api.Services;

public interface ILoanApplicationService
{
    Task<LoanApplication> CreateLoanApplicationAsync(string socialSecurityNumber, int amount);
}
