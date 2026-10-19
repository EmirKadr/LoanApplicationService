namespace LoanApplicationService.Api.Services;

public sealed class MockCreditScoreService : ICreditScoreService
{
    private sealed record FakeCustomer(string Name, int AnnualIncome, int TotalDebt, int CreditScore);

    // Påhittade testpersoner med fasta kreditvärden
    private static readonly IReadOnlyDictionary<string, FakeCustomer> Customers =
        new Dictionary<string, FakeCustomer>(StringComparer.Ordinal)
        {
            ["19900101-2010"] = new("Anna Svensson", 520000, 150000, 70),    // Approved
            ["19850515-1234"] = new("Erik Johansson", 360000, 180000, 49),   // Declined (precis under gränsen)
            ["19780320-5678"] = new("Maria Lindberg", 680000, 1200000, 100), // Approved
            ["20000229-9876"] = new("Sara Ahmed", 290000, 40000, 50),        // Approved (precis på gränsen)
            ["19751010-5555"] = new("Ali Karimi", 210000, 650000, 15)        // Declined
        };

    private const int UnknownCustomerCreditScore = 0;

    public async Task<int> GetCreditScoreAsync(string socialSecurityNumber)
    {
        // Simulerar ett anrop till en extern tjänst
        await Task.Delay(500);

        // Okända personer saknar kredithistorik och får lägsta kreditvärde
        return Customers.TryGetValue(socialSecurityNumber, out var customer)
            ? customer.CreditScore
            : UnknownCustomerCreditScore;
    }
}
