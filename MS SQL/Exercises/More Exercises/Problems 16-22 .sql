CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL,
)


CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY(1,1),
AddressText NVARCHAR(30),
TownId INT FOREIGN KEY REFERENCES Towns([Id]),
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50)
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(20),
MiddleName NVARCHAR(20),
LastName NVARCHAR(20),
JobTitle NVARCHAR(20),
DepartmentId INT FOREIGN KEY REFERENCES Departments([Id]),
HireDate VARCHAR(50),
Salary DECIMAL (10,2),
AddressId INT FOREIGN KEY REFERENCES Addresses([Id])
)
DROP TABLE Employees


INSERT INTO Departments([Name])
Values
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Departments([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Employees([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary])
VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'01/02/2013',3500.00),
('Petar','Petrov','Petrov','Senior Engineer',1,'02/03/2004',4000.00),
('Maria','Petrova','Ivanova','Intern',5,'28/08/2016',525.25),
('Georgi','Terziev','Ivanov','CEO',2,'09/12/2007',3000.00),
('Peter','Pan','Pan','Intern',3,'28/08/2016',599.88)

-- Problem 20

SELECT * FROM Towns ORDER BY Name;
SELECT * FROM Departments ORDER BY Name;
SELECT * FROM Employees ORDER BY Salary DESC;

-- Problem 21

SELECT [Name] FROM Towns
ORDER BY Name;

SELECT [Name] FROM Departments
ORDER BY Name;

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM Employees
ORDER BY Salary DESC;

-- Problem 22
UPDATE Employees
SET [Salary] = [Salary] + [Salary] * 0.10;
SELECT [Salary] FROM Employees;
