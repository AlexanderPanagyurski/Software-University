-- Problem 1
CREATE DATABASE OneToOne;

USE OneToOne;

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY NOT NULL,
	PassportNumber VARCHAR(50) NOT NULL
);

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	Salary DECIMAL(15, 2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) NOT NULL
);

INSERT INTO Passports([PassportID], [PassportNumber]) VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2');

INSERT INTO Persons([FirstName], [Salary], [PassportID]) VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101);

SELECT *
  FROM Persons AS p
  JOIN Passports As pass ON pass.PassportID = p.PassportID;

-- Problem 2
CREATE DATABASE OneToMany;

USE OneToMany

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR (30) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO Manufacturers([Name],EstablishedOn) VALUES
('BMW' ,'07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')

INSERT INTO Models(ModelID,[Name],ManufacturerID) VALUES
(101,'X1',1),
(102,'i6',1),
(103,'Model S',2),
(104,'Model X',2),
(105,'Model 3',2),
(106,'Nova',3)

SELECT 
	ModelID,
	models.[Name] AS MODEL,
	manuf.[Name] AS Manufacturer
 FROM Models AS models
JOIN Manufacturers manuf ON  models.ManufacturerID=manuf.ManufacturerID

-- Problem 3
CREATE DATABASE ManyToMany

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT  FOREIGN KEY REFERENCES Exams(ExamID)
	PRIMARY KEY(StudentID,ExamID)
)

INSERT INTO Students([Name]) VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams(ExamID,[Name]) VALUES
(101,'SpringMVC'),
(102,'Neo4j'),
(103,'Oracle 11g')

INSERT INTO StudentsExams(StudentID,ExamID) VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

-- Problem 4
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR (30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID,[Name],ManagerID) VALUES
(101,'John',NULL),
(102,'Maya',106),
(103,'Silvia',106),
(104,'Ted',105),
(105,'Mark',101),
(106,'Greta',101)

SELECT * FROM Teachers

-- Problem 5
CREATE DATABASE OnlineStoreDb

CREATE TABLE ItemTypes (
	ItemTypeID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Cities (
	CityID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items (
	ItemID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)


CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders (
	OrderID INT PRIMARY KEY NOT NULL,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems (
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID)
	PRIMARY KEY(OrderID,ItemID)
)

-- Problem 6
CREATE DATABASE UniversityDb

CREATE TABLE Majors (
	MajorID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR (50) NOT NULL
)

CREATE TABLE Subjects (
	SubjectID INT PRIMARY KEY NOT NULL,
	SubjectName NVARCHAR (50) NOT NULL
)

CREATE TABLE Students (
	StudentID INT PRIMARY KEY NOT NULL,
	StudentNumber VARCHAR(20) NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY(StudentID,SubjectID)
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY NOT NULL,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(10,2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

-- Problem 9
USE [Geography];

  SELECT *
    FROM (
  SELECT MountainRange, p.PeakName, p.Elevation
    FROM Mountains AS m
    JOIN Peaks AS p ON p.MountainId = m.Id) AS g
   WHERE MountainRange = 'Rila'
ORDER BY g.Elevation DESC;