namespace LoanApplicationService.Api.Services;

public class CreditScoreService : ICreditScoreService
{
    public async Task<int> GetCreditScoreAsync(string socialSecurityNumber)
    {
        // Simulerar ett anrop till en extern tjänst
        await Task.Delay(500);

        // Returnerar ett påhittat kreditvärde
        return 75;
    }
}
