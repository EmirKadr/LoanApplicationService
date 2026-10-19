using System.Collections.Concurrent;
using LoanApplicationService.Api.Models;

namespace LoanApplicationService.Api.Repositories;

// Lagrar låneansökningar i minnet. Datan försvinner när applikationen startas om.
public class MockLoanApplicationRepository : ILoanApplicationRepository
{
    private readonly ConcurrentDictionary<int, LoanApplication> _loanApplications = new();
    private int _lastId;

    public MockLoanApplicationRepository()
    {
        // Påhittade ansökningar för samma testpersoner som i MockCreditScoreService
        Seed("19900101-2010", 100000, LoanApplicationStatus.Approved); // Anna Svensson
        Seed("19850515-1234", 50000, LoanApplicationStatus.Declined);  // Erik Johansson
        Seed("19780320-5678", 750000, LoanApplicationStatus.Approved); // Maria Lindberg
        Seed("20000229-9876", 250000, LoanApplicationStatus.Approved); // Sara Ahmed
        Seed("19751010-5555", 30000, LoanApplicationStatus.Declined);  // Ali Karimi
    }

    public Task<LoanApplication> CreateAsync(LoanApplication loanApplication)
    {
        loanApplication.Id = Interlocked.Increment(ref _lastId);
        _loanApplications[loanApplication.Id] = loanApplication;

        return Task.FromResult(loanApplication);
    }

    private void Seed(string socialSecurityNumber, int amount, LoanApplicationStatus status) =>
        CreateAsync(new LoanApplication
        {
            SocialSecurityNumber = socialSecurityNumber,
            Amount = amount,
            Status = status
        });
}
