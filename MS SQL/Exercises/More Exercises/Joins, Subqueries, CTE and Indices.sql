-- Problem 1
SELECT TOP(5)
	e.EmployeeID,
	e.JobTitle,
	e.AddressID,
	a.AddressText
FROM Employees e
LEFT JOIN Addresses a
ON a.AddressID=e.AddressID
ORDER BY e.AddressID

-- Problem 2
SELECT TOP(50)
	FirstName,
	LastName,
	t.[Name],
	a.AddressText
FROM Employees e
JOIN Addresses a
ON a.AddressID=e.AddressID
JOIN Towns t
ON t.TownID=a.TownID
ORDER BY FirstName,LastName

-- Problem 3
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] 
FROM Employees e
JOIN Departments d
ON d.DepartmentID=e.DepartmentID
WHERE d.[Name]='Sales'
ORDER BY e.EmployeeID

-- Problem 4
SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name]
FROM Employees e
JOIN Departments d
ON d.DepartmentID=e.DepartmentID
WHERE e.Salary>15000
ORDER BY e.DepartmentID

-- Problem 5
SELECT TOP(3)
	e.EmployeeID,
	e.FirstName 
FROM Employees e
FULL JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

-- Problem 6
SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DeptName 
FROM Employees e
JOIN Departments d
ON d.DepartmentID=e.DepartmentID
WHERE d.[Name]='Sales' OR d.[Name]='Finance'
AND HireDate>'1.1.1999'
ORDER BY HireDate

-- Problem 7
SELECT TOP(5)
	e.EmployeeID, 
	e.FirstName,
	p.[Name] AS ProjectName
FROM Employees e
JOIN EmployeesProjects ep
ON ep.EmployeeID=e.EmployeeID
JOIN Projects p
ON p.ProjectID=ep.ProjectID
WHERE p.StartDate>'2002.08.13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- Problem 8
SELECT
	e.EmployeeID,
	e.FirstName,
	IIF(YEAR(p.StartDate) >= 2005, NULL, p.[Name]) AS ProjectName
FROM Employees e 
JOIN EmployeesProjects ep
ON ep.EmployeeID=e.EmployeeID
JOIN Projects p
ON p.ProjectID=ep.ProjectID
WHERE e.EmployeeID=24 

-- Problem 9
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName AS ManagerName
FROM Employees e
JOIN Employees m
ON m.EmployeeID=e.ManagerID
WHERE m.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID

-- Problem 10
SELECT TOP(50)
	 e.EmployeeID,
	 CONCAT(e.FirstName,' ',e.LastName) AS EmployeeName,
	 CONCAT(m.FirstName,' ',m.LastName) AS ManagerName,
	 d.[Name] AS DepartmentName 
FROM Employees e
JOIN Employees m
ON m.EmployeeID=e.ManagerID
JOIN Departments d
ON d.DepartmentID=e.DepartmentID
ORDER BY e.EmployeeID

-- Problem 11
SELECT TOP(1)
	 AVG(e.Salary) AS MinAverageSalary
FROM Employees e
JOIN Departments d
ON d.DepartmentID=e.DepartmentID
GROUP BY d.[Name]
ORDER BY MinAverageSalary

-- Problem 12
SELECT 
	mc.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation 
FROM Peaks p
JOIN Mountains m
ON p.MountainId=m.Id
JOIN MountainsCountries mc
ON mc.MountainId=m.Id
WHERE mc.CountryCode='BG' AND Elevation>2835
ORDER BY Elevation DESC

-- Problem 13
SELECT 
	mc.CountryCode,
	COUNT(m.MountainRange)
FROM Mountains m
JOIN MountainsCountries mc
ON mc.MountainId=m.Id
WHERE mc.CountryCode='BG' OR mc.CountryCode='RU' OR mc.CountryCode='US'
GROUP BY CountryCode

-- Problem 14
SELECT TOP(5)
	c.CountryName,
	r.RiverName
FROM Rivers r
JOIN CountriesRivers cr
ON cr.RiverId=r.Id
Right JOIN Countries c
ON c.CountryCode=cr.CountryCode
WHERE c.ContinentCode='AF'
ORDER BY c.CountryName

-- Problem 15
SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
    FROM (
  SELECT c.ContinentCode,
         c.CurrencyCode,
  	     COUNT(c.CurrencyCode) AS [CurrencyUsage],
  	     DENSE_RANK() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
    FROM Countries AS c
    JOIN Currencies AS cc ON cc.CurrencyCode = c.CurrencyCode
GROUP BY c.ContinentCode, c.CurrencyCode
  HAVING COUNT(c.CurrencyCode) != 1) AS k
   WHERE k.[Rank] = 1
ORDER BY k.ContinentCode 

-- Problem 16
SELECT COUNT(*) [Count]
 FROM Countries c
LEFT JOIN MountainsCountries mc
ON mc.CountryCode=c.CountryCode
WHERE mc.CountryCode IS NULL

EXEC sp_changedbowner 'sa'
-- Problem 17
SELECT TOP(5)
	c.CountryName,
	MAX(p.Elevation) AS [HighestPeakElevation],
		 MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries c
JOIN MountainsCountries mc
ON mc.CountryCode=c.CountryCode
JOIN Mountains m
ON m.Id=mc.MountainId
JOIN Peaks p
ON p.MountainId=m.Id
JOIN  CountriesRivers cr
ON cr.CountryCode=c.CountryCode
JOIN Rivers r
ON r.Id=cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC ,LongestRiverLength DESC, c.CountryName

-- Problem 18
SELECT TOP(5)
	c.CountryName, 
	IIF(p.PeakName IS NULL,'(no highest peak)',p.PeakName) AS [Highest Peak Name],
	IIF(p.Elevation IS NULL,0,p.Elevation) AS [Highest Peak Elevation],
	IIF(m.MountainRange IS NULL, '(no mountain)',m.MountainRange) AS Mountain
	FROM Countries c
LEFT JOIN MountainsCountries mc
ON mc.CountryCode=c.CountryCode
LEFT JOIN Mountains m
ON m.Id=mc.MountainId
LEFT Join Peaks p
ON p.MountainId=m.Id
ORDER BY c.CountryName,[Highest Peak Name]











