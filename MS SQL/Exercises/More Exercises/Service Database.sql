
-- 01. DDL
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username NVARCHAR(30) NOT NULL,
[Password] NVARCHAR(50) NOT NULL,
[Name] NVARCHAR(50),
Birthdate DATETIME2,
Age INT CHECK(Age>=14 AND Age<=110),
Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL 
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Birthdate DATETIME2,
Age INT CHECK(Age>=18 AND Age<=110),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
Id INT PRIMARY KEY IDENTITY,
Label NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
OpenDate DATETIME2 NOT NULL,
CloseDate DATETIME2,
[Description] NVARCHAR(200) NOT NULL,
UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

-- 02. Insert
INSERT INTO Employees
VALUES
('Marlo','O''Malley','1958-9-21',NULL,1),
('Niki','Stanaghan','1969-11-26',NULL,4),
('Ayrton','Senna','1960-03-21',NULL,9),
('Ronnie','Peterson','1944-02-14',NULL,9),
('Giovanna','Amati','1959-07-20',NULL,5)

INSERT INTO Reports
VALUES
(1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2),
(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
(14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5,2),
(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)

-- 03. Update
UPDATE Reports
SET CloseDate=CURRENT_TIMESTAMP
WHERE CloseDate IS NULL

--05. Unassigned Reports
SELECT 
	r.[Description],
	FORMAT(r.OpenDate,'dd-MM-yyyy') AS OpenDate
FROM Reports r
LEFT JOIN dbo.Employees	e
ON r.EmployeeId=e.Id
WHERE e.Id IS NULL
ORDER BY r.OpenDate,r.[Description]

--06. Reports & Categories
SELECT 
	[r].[Description],
	[c].[Name]
FROM [dbo].[Reports] AS r
Left Join [dbo].[Categories] AS c
ON [r].[CategoryId]=[c].[Id]
ORDER BY [r].[Description], [c].[Name]