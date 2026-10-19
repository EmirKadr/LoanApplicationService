IF DB_ID('LoanApplicationDb') IS NULL
    CREATE DATABASE LoanApplicationDb;
GO

USE LoanApplicationDb;
GO

IF OBJECT_ID('dbo.LoanApplications', 'U') IS NULL
CREATE TABLE dbo.LoanApplications
(
    Id                   INT IDENTITY(1,1) PRIMARY KEY,
    SocialSecurityNumber NVARCHAR(13) NOT NULL,
    Amount               INT          NOT NULL CHECK (Amount > 0),
    Status               NVARCHAR(20) NOT NULL CHECK (Status IN ('Approved', 'Declined'))
);
GO
