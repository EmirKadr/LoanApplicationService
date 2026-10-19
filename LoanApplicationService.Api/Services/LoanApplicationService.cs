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
        if (!SocialSecurityNumberValidator.IsValid(socialSecurityNumber))
            throw new ArgumentException("Personnummer måste ha formatet YYYYMMDD-XXXX.");

        if (amount <= 0)
            throw new ArgumentException("Lånebeloppet måste vara större än 0.");

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
