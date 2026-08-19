-- Students table
-- Mirrors StudentResultApp.Models.Student
-- Depends on dbo.Modules (Modules.sql must be run first)

USE [Student_Result_App];
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'Students')
BEGIN
    CREATE TABLE dbo.Students
    (
        Id             INT IDENTITY(1,1) NOT NULL,
        StudentNumber  NVARCHAR(20)      NOT NULL,
        FullName       NVARCHAR(100)     NOT NULL,
        ModuleCode     NVARCHAR(20)      NOT NULL,
        Mark           FLOAT             NOT NULL CONSTRAINT DF_Students_Mark DEFAULT (0), -- FLOAT matches the C# "double" type used by Student.Mark

        CONSTRAINT PK_Students PRIMARY KEY CLUSTERED (Id),
        CONSTRAINT UQ_Students_StudentNumber UNIQUE (StudentNumber),
        CONSTRAINT FK_Students_Modules FOREIGN KEY (ModuleCode) REFERENCES dbo.Modules (Code),
        CONSTRAINT CK_Students_Mark CHECK (Mark BETWEEN 0 AND 100)
    );
END
GO
