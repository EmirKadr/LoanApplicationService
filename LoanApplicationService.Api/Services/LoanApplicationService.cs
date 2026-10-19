using LoanApplicationService.Api.Models;
using LoanApplicationService.Api.Repositories;
using LoanApplicationService.Api.Validators;

namespace LoanApplicationService.Api.Services;

public class LoanApplicationService(
    ICreditScoreService creditScoreService,
    ILoanApplicationRepository loanApplicationRepository) : ILoanApplicationService
{
    private const int MinimumCreditScore = 50;

    public async Task<LoanApplication> CreateLoanApplicationAsync(string socialSecurityNumber, int amount)
    {
        LoanApplicationValidator.Validate(socialSecurityNumber, amount);

        var creditScore = await creditScoreService.GetCreditScoreAsync(socialSecurityNumber);

        var loanApplication = new LoanApplication
        {
            SocialSecurityNumber = socialSecurityNumber,
            Amount = amount,
            Status = creditScore >= MinimumCreditScore
                ? LoanApplicationStatus.Approved
                : LoanApplicationStatus.Declined
        };

        return await loanApplicationRepository.CreateAsync(loanApplication);
    }
}
