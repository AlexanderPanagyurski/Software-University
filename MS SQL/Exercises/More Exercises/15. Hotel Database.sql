CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Title NVARCHAR(20),
Notes NVARCHAR(MAX)
) 

INSERT INTO Employees([FirstName],[LastName])
VALUES
('Ivan','Ivanov'),
('Plamen','Ivanov'),
('Pesho','Peshov')

CREATE TABLE Customers(
AccountNumber NVARCHAR(20) NOT NULL,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
PhoneNumber NVARCHAR(20),
EmergencyName NVARCHAR(20),
EmergencyNumber NVARCHAR(20),
Notes NVARCHAR(MAX)
)

INSERT INTO Customers([AccountNumber],[FirstName],[LastName])
VALUES
('2141241HAHA','Plamen','Georgiev'),
('AH124215GGA','Iva','Ivanova'),
('SRT325AGAH3','Stoyan','Ivanov') 


CREATE TABLE RoomStatus(
[RoomStatus] VARCHAR(20) PRIMARY KEY NOT NULL CHECK(RoomStatus = 'Free' OR RoomStatus = 'Full' OR RoomStatus = 'Half'),
[Notes] VARCHAR(MAX)
);

INSERT INTO RoomStatus([RoomStatus])
VALUES('Free'),
('Half'),
('Full');

CREATE TABLE RoomTypes(
[RoomType] VARCHAR(20) PRIMARY KEY NOT NULL,
[Notes]VARCHAR(MAX)
);

INSERT INTO RoomTypes([RoomType])
VALUES('Tripple'),
('Double'),
('Mezonet');

CREATE TABLE BedTypes(
[BedType]  VARCHAR(20) PRIMARY KEY NOT NULL,
[Notes]VARCHAR(MAX)
);

INSERT INTO BedTypes([BedType])
VALUES('Single'),
('Double'),
('Tripple');

CREATE TABLE Rooms(
RoomNumber VARCHAR(20) NOT NULL,
RoomType VARCHAR(20) NOT NULL,
BedType VARCHAR(20) NOT NULL,
Rate INT,
RoomStatus VARCHAR(20) FOREIGN KEY REFERENCES RoomStatus([RoomStatus]) NOT NULL, 
[Notes] VARCHAR(MAX)
) 

INSERT INTO Rooms([RoomNumber], [RoomType], [BedType], [RoomStatus])
VALUES(123, 'Tripple', 'Tripple', 'Free'),
(1254, 'Mezonet', 'Single', 'Full'),
(2563, 'Double', 'Single', 'Half');

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL,
PaymentDate NVARCHAR(20) ,
AccountNumber NVARCHAR(20),
FirstDateOccupied DATETIME,
LastDateOccupied DATETIME,
TotalDays INT,
[AmountCharged] DECIMAL(15, 2),
[TaxRate] INT, 
[TaxAmount] DECIMAL(15, 2),
[PaymentTotal] DECIMAL(15, 2), 
[Notes] VARCHAR(MAX)
)

INSERT INTO Payments([EmployeeId])
VALUES
(1),
(2),
(3);

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees([Id]),
DateOccupied DATETIME,
AccountNumber INT,
RoomNumber NVARCHAR(4),
RateApplied INT,
PhoneCharge INT,
Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies([EmployeeId])
VALUES(2),
(1),
(3);