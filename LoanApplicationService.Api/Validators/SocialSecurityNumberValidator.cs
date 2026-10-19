using System.Text.RegularExpressions;

namespace LoanApplicationService.Api.Validators;

public static partial class SocialSecurityNumberValidator
{
    // Format: YYYYMMDD-XXXX
    [GeneratedRegex(@"^\d{8}-\d{4}$")]
    private static partial Regex Pattern();

    public static bool IsValid(string? socialSecurityNumber) =>
        !string.IsNullOrWhiteSpace(socialSecurityNumber) && Pattern().IsMatch(socialSecurityNumber);
}
