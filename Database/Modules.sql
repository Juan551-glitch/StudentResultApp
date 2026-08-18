-- Modules table
-- Mirrors StudentResultApp.Models.Module

USE [Student_Result_App];
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'Modules')
BEGIN
    CREATE TABLE dbo.Modules
    (
        Id            INT IDENTITY(1,1) NOT NULL,
        Code          NVARCHAR(20)      NOT NULL,
        Name          NVARCHAR(100)     NOT NULL,
        AcademicYear  INT               NOT NULL CONSTRAINT DF_Modules_AcademicYear DEFAULT (2026),
        StudentCount  INT               NOT NULL CONSTRAINT DF_Modules_StudentCount DEFAULT (0),
        Status        NVARCHAR(20)      NOT NULL CONSTRAINT DF_Modules_Status DEFAULT (N'Active'),

        CONSTRAINT PK_Modules PRIMARY KEY CLUSTERED (Id),
        CONSTRAINT UQ_Modules_Code UNIQUE (Code),
        CONSTRAINT CK_Modules_AcademicYear CHECK (AcademicYear BETWEEN 2020 AND 2100),
        CONSTRAINT CK_Modules_StudentCount CHECK (StudentCount BETWEEN 0 AND 10000),
        CONSTRAINT CK_Modules_Status CHECK (Status IN (N'Active', N'Inactive'))
    );
END
GO

-- Seed data matching StudentResultApp.Services.ModuleService
IF NOT EXISTS (SELECT 1 FROM dbo.Modules)
BEGIN
    SET IDENTITY_INSERT dbo.Modules ON;

    INSERT INTO dbo.Modules (Id, Code, Name, AcademicYear, StudentCount, Status)
    VALUES
        (1, N'MDB622', N'Database Manipulation', 2026, 14, N'Active'),
        (2, N'AZ400',  N'Designing and Implementing Microsoft DevOps Solutions', 2026, 14, N'Active'),
        (3, N'SDT621', N'Software Development', 2026, 12, N'Active'),
        (4, N'DAG511', N'Data Analytics', 2026, 10, N'Inactive');

    SET IDENTITY_INSERT dbo.Modules OFF;
END
GO
