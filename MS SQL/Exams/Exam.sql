CREATE DATABASE [Service]
USE [Service]

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age Between 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)  
)

-- 02. Insert
INSERT INTO Employees([FirstName],[LastName],[Birthdate],[DepartmentId]) VALUES
('Marlo','O''Malley','1958-9-21',1),
('Niki','Stanaghan','1969-11-26',4),
('Ayrton','Senna','1960-03-21',9),
('Ronnie','Peterson','1944-02-14',9),
('Giovanna','Amati','1959-07-20',5)

INSERT INTO Reports([CategoryId],[StatusId],[OpenDate],[CloseDate],[Description],[UserId],[EmployeeId]) VALUES
(1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2),
(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
(14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5,2),
(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)


-- 03. Update
UPDATE Reports
SET CloseDate=GETDATE()
WHERE CloseDate IS NULL

-- 04. Delete
DELETE FROM Reports WHERE StatusId=4

SELECT COUNT(*) FROM Reports WHERE StatusId=4

-- 05. Unassigned Reports
SELECT 
	r.[Description],
	CONVERT(VARCHAR,r.OpenDate,105) As OpenDate
FROM dbo.Reports r
WHERE r.EmployeeId IS NULL
ORDER BY r.OpenDate,r.[Description]

-- 06. Reports & Categories
SELECT 
	r.[Description],
	c.[Name]
FROM dbo.Reports r
JOIN dbo.Categories c
ON r.CategoryId=c.Id
WHERE r.CategoryId IS NOT NULL
ORDER BY r.[Description],c.[Name]

-- 07. Most Reported Category
SELECT TOP(5)
	c.[Name],
	COUNT(r.CategoryId) ReportsNumber
FROM dbo.Categories c
JOIN dbo.Reports r
ON r.CategoryId=c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]

-- 08. Birthday Report
SELECT 
	u.Username AS Username,
	c.[Name] AS CategoryName
FROM dbo.Users u
JOIN dbo.Reports r
ON r.UserId=u.Id
JOIN dbo.Categories c
ON c.Id=r.CategoryId
WHERE FORMAT(r.OpenDate,'MM-dd')=FORMAT(u.Birthdate,'MM-dd')
ORDER BY Username, CategoryName

-- 09. User per Employee
SELECT 
	 CONCAT(e.FirstName,' ',e.LastName) AS [Full Name],
	 COUNT(u.Id) UsersCount
FROM dbo.Employees e
LEFT JOIN dbo.Reports r
ON r.EmployeeId=e.Id
LEFT JOIN dbo.Users u
ON u.Id=r.UserId
GROUP BY e.FirstName,e.LastName
ORDER BY UsersCount DESC, [Full Name] 

-- 10. Full Info
SELECT 
	ISNULL( CONCAT(e.FirstName,' ',e.LastName),'None') AS Employee,
	ISNULL(d.[Name],'None') AS Department,
	ISNULL(c.[Name],'None') AS Category,
	ISNULL(r.[Description],'None') AS [Description],
	ISNULL(FORMAT([r].[OpenDate], 'dd.MM.yyyy'), 'None') AS [OpenDate],
	ISNULL(s.Label,'None') AS [Status],
	ISNULL(u.[Name],'None') AS [User]
FROM dbo.Reports r
LEFT JOIN [dbo].[Employees] AS [e] ON [r].[EmployeeId] = [e].[Id]
LEFT JOIN [dbo].[Departments] AS [d] ON [e].[DepartmentId] = [d].[Id]
LEFT JOIN [dbo].[Categories] AS [c] ON [r].[CategoryId] = [c].[Id]
LEFT JOIN [dbo].[Status] AS [s] ON [r].[StatusId] = [s].[Id]
LEFT JOIN [dbo].[Users] AS [u] ON [r].[UserId] = [u].[Id]
ORDER BY e.FirstName DESC,e.LastName DESC,d.[Name],c.[Name], r.[Description], r.OpenDate, [s].[Label],[u].[Name]
 ​
--11
GO

CREATE  FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL)
	BEGIN
		RETURN 0
	END
	IF(@EndDate IS NULL)
	BEGIN
		RETURN 0
	END
	DECLARE @result INT
	SET @result=CONVERT(INT,DATEDIFF(HOUR,@StartDate,@EndDate))
	RETURN @result
END​

GO
--12
CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
DECLARE @employeeDepartment INT = (SELECT [e].[DepartmentId]
                                         FROM [dbo].[Employees] AS e
                                        WHERE [e].[Id] = @EmployeeId)

	DECLARE @reportDepartment INT = (SELECT [c].[DepartmentId]
                                       FROM [dbo].[Reports] AS r
                                       JOIN [dbo].[Categories] AS [c] ON [r].[CategoryId] = [c].[Id]
                                      WHERE [r].[Id] = @ReportId)


IF(@EmployeeDepartmentId <> @CategoryDepartmentId)
BEGIN 
	RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)
	RETURN
END 
ELSE
BEGIN
	UPDATE dbo.Reports 
	SET EmployeeId=@EmployeeId  
	WHERE @ReportId=Id
END 

EXEC usp_AssignEmployeeToReport 30, 1

DROP PROCEDURE  usp_AssignEmployeeToReport

SELECT d. FROM dbo.Reports d