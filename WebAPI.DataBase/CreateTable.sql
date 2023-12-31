﻿IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'WebAPIdb')
BEGIN
    CREATE DATABASE WebAPIdb;
END
GO

USE WebAPIdb;
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Exemplo')
BEGIN
    CREATE TABLE Exemplo (
        Id INT PRIMARY KEY,
        Descricao NVARCHAR(max)
    );
END
GO