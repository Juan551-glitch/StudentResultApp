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
