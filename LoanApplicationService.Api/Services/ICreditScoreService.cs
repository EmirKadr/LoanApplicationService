namespace LoanApplicationService.Api.Services;

public interface ICreditScoreService
{
    Task<int> GetCreditScoreAsync(string socialSecurityNumber);
}
