-- Creates the StudentResultApp database.
-- Run this once before executing the table scripts in this folder
-- (Modules.sql must run before Students.sql because of the foreign key).

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = N'StudentResultApp')
BEGIN
    CREATE DATABASE StudentResultApp;
END
GO
