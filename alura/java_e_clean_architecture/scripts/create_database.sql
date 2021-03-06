CREATE DATABASE School
GO

USE School
GO

CREATE TABLE Students
(
    Cpf NVARCHAR(11) PRIMARY KEY NOT NULL,
    Name NVARCHAR(250) NOT NULL,
    Email NVARCHAR(250) NOT NULL,
)
GO

CREATE TABLE Phones
(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    DDD NVARCHAR(3),
    Number NVARCHAR(9),
)
GO

ALTER TABLE Phones ADD StudentCpf NVARCHAR(11) FOREIGN KEY REFERENCES Students(Cpf)
GO

ALTER TABLE Students ADD PasswordHash NVARCHAR(250)
GO
