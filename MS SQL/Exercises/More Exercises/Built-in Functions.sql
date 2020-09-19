-- Problem 1
SELECT 
	FirstName,
	LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

-- Problem 2
SELECT
	FirstName,
	LastName 
FROM Employees
WHERE LastName LIKE '%ei%'

-- Problem 3
SELECT
	FirstName
 FROM Employees
 WHERE DepartmentID = 3 OR DepartmentID=10
 AND  DATEPART(year,HireDate)>=1995 AND DATEPART(year,HireDate)<=2005

-- Problem 4
SELECT
	FirstName,
	LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- Problem 5
SELECT
	[Name]
FROM Towns
WHERE LEN([Name])=5 OR Len([Name])=6
ORDER BY [Name] 

-- Problem 6
SELECT
	TownID, 
	[Name]
FROM Towns
WHERE [Name] LIKE 'M%' OR [Name]  LIKE 'K%' OR [Name]  LIKE 'B%' OR [Name] Like 'E%'
ORDER By [Name]

-- Problem 7
SELECT
	TownID, 
	[Name]
FROM Towns
WHERE [Name]  NOT LIKE 'R%' AND [Name] NOT LIKE 'B%' AND [Name] NOT LIKE 'D%'
ORDER By [Name]

-- Problem 8
CREATE VIEW V_EmployeesHiredAfter2000 AS 
SELECT
	FirstName,
	LastName
FROM Employees
WHERE DATEPART(YEAR,HireDate)>2000


-- Problem 9
SELECT
	FirstName,
	LastName
FROM Employees
WHERE LEN(LastName)=5

-- Problem 10
SELECT 
	EmployeeID,
	FirstName,
	LastName,
	Salary,
	DENSE_RANK () OVER (
	PARTITION BY Salary
	ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary>= 10000 AND Salary<=50000
ORDER BY Salary DESC

-- Problem 11
SELECT * FROM (
	SELECT
	EmployeeID,
	FirstName,
	LastName,
	Salary,
	DENSE_RANK () OVER (
	PARTITION BY Salary
	ORDER BY EmployeeID) AS [Rank]
FROM Employees) Employees
WHERE [Rank]=2 AND Salary>=10000 AND Salary<=50000
ORDER BY Salary DESC

-- Problem 12
SELECT 
	CountryName AS [Country Name],
	IsoCode AS [ISO Code]
FROM Countries
WHERE  LEN(CountryName) - LEN(REPLACE(CountryName,LOWER('A'),'')) >=3
ORDER BY IsoCode

-- Problem 13
SELECT PeakName, RiverName, LOWER(LEFT(PeakName, LEN(PeakName) - 1) + RiverName) AS Mix
    FROM Peaks, Rivers
   WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix;

USE Diablo

-- Problem 14
SELECT TOP(50)
	[Name],
	CONVERT(VARCHAR,[Start],23) AS [Start]
FROM Games
WHERE DATEPART(year,[Start])>=2011 AND DATEPART(year,[Start])<=2012
ORDER BY [Start],[Name]

--Problem 15
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider], Username;

--Problem 16
SELECT 
	Username,
	IpAddress AS [IP Address]
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--Problem 17
SELECT
	[Name],
	CASE
		WHEN DATEPART(hour,[Start])>=0 AND DATEPART(hour,[Start])<12 THEN 'Morning'
		WHEN DATEPART(hour,[Start])>=12 AND DATEPART(hour,[Start])<18 THEN 'Afternoon'
		WHEN DATEPART(hour,[Start])>=18 AND DATEPART(hour,[Start])<24 THEN 'Evening'
	END AS [Part Of The Day],
	CASE
		WHEN Duration<=3 THEN 'Extra Short'
		WHEN Duration>=4 AND Duration<=6 THEN 'Short'
		WHEN Duration>6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END AS Duration
FROM Games
ORDER BY [Name],Duration,[Part Of The Day]

USE Orders

--Problem 18
SELECT 
	ProductName,
	OrderDate,
	DATEADD(DAY,3,OrderDate) AS [Pay Due],
	DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
FROM Orders
