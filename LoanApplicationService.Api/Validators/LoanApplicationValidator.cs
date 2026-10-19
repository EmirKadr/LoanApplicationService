using System.Text.RegularExpressions;

namespace LoanApplicationService.Api.Validators;

public static partial class LoanApplicationValidator
{
    // Format: YYYYMMDD-XXXX
    [GeneratedRegex(@"^\d{8}-\d{4}$")]
    private static partial Regex SocialSecurityNumberPattern();

    public static void Validate(string? socialSecurityNumber, int amount)
    {
        if (string.IsNullOrWhiteSpace(socialSecurityNumber) || !SocialSecurityNumberPattern().IsMatch(socialSecurityNumber))
            throw new ArgumentException("Personnummer måste ha formatet YYYYMMDD-XXXX.");

        if (amount <= 0)
            throw new ArgumentException("Lånebeloppet måste vara större än 0.");
    }
}
