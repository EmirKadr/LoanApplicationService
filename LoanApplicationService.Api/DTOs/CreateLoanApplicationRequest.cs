namespace LoanApplicationService.Api.DTOs;

public record CreateLoanApplicationRequest(string SocialSecurityNumber, int Amount);
