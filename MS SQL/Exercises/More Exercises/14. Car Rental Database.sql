CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryName NVARCHAR(20) NOT NULL,
DailyRate INT,
WeeklyRate INT,
MonthlyRate INT,
WeekendRate INT
)

INSERT INTO Categories(CategoryName)
VALUES
('Off-Road'),
('Speed'),
('Track')

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY(1,1),
PlateNumber NVARCHAR(20) NOT NULL,
Manufacturer NVARCHAR(20) NOT NULL,
Model NVARCHAR(20) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
[Doors] INT,
[Picture] IMAGE,
[Condition] VARCHAR(100),
[Available] VARCHAR(5) NOT NULL CHECK([Available] = 'Yes' Or [Available] = 'No')
) 

INSERT INTO Cars([PlateNumber],[Manufacturer],[Model],[CarYear],[CategoryId],[Doors],[Available])
VALUES
('NY3256NY', 'Mercedes-Benz','S400', 2019, 2, 4, 'Yes'),
('LA4567CA', 'Tesla','Model S' ,2016, 1, 4, 'No'),
('SA1367CA', 'Tesla', 'Model 3',2018, 3, 4, 'Yes');


CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Title NVARCHAR(20),
Notes NVARCHAR(MAX)
) 

INSERT INTO Employees([FirstName],[LastName])
VALUES
('Viktor','Ivanov'),
('Iva','Alexieva'),
('Nadya','Miroslavova')

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY(1,1),
DriverLicenceNumber NVARCHAR(20) NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(25) NOT NULL,
City NVARCHAR(20) NOT NULL,
ZIPCode INT,
Notes NVARCHAR(MAX)
) 


INSERT INTO Customers([DriverLicenceNumber],[FullName],[Address],[City])
VALUES
('12412442314','Ivaylo Ivanov','Peter Berkovski 11','Sofia'),
('42143252312','Georgi Georgiev','Ivan Asen II 23','Veliko Tarnovo'),
('63412431242','Simeon Vladimirov','Ivan Alexander 15','Vidin')

CREATE TABLE RentalOrders(
[Id]INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL,
[CustomerId]  INT FOREIGN KEY REFERENCES Customers([Id]) NOT NULL,
[CarId]  INT FOREIGN KEY REFERENCES Cars([Id]) NOT NULL, 
[TankLevel] INT, 
[KilometrageStart] INT NOT NULL, 
[KilometrageEnd] INT, 
[TotalKilometrage] INT,
[StartDate] DATETIME,
[EndDate] DATETIME, 
[TotalDays] INT, 
[RateApplied] INT, 
[TaxRate] INT, 
[OrderStatus] VARCHAR(20), 
[Notes] VARCHAR(MAX)
);

INSERT INTO RentalOrders([EmployeeId], [CustomerId], [CarId], [KilometrageStart])
VALUES(2, 1, 3, 1253620),
(1, 2, 3, 1236322036),
(3, 3, 1, 1523692);