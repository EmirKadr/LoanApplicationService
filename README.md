# LoanApplicationService

Ett Web API byggt med ASP.NET Core (Minimal APIs) för att ta emot, behandla och lagra låneansökningar.

## Funktionalitet

- `POST /api/loanapplications` – skapar en låneansökan, gör en kreditbedömning och returnerar ansökans ID och status (`Approved`/`Declined`).

## Teknik

- ASP.NET Core Web API (.NET)
- Dapper + SQL Server LocalDB/Express
- Interfaces och dependency injection (services och repositories)
- Azure App Service (in-memory-repository i Azure)

## Kom igång

1. Sätt anslutningssträngen med User Secrets:
   ```
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<din-anslutningssträng>" --project LoanApplicationService.Api
   ```
2. Kör applikationen:
   ```
   dotnet run --project LoanApplicationService.Api
   ```
   HTTPS: `https://localhost:8000`, HTTP: `http://localhost:9000`
