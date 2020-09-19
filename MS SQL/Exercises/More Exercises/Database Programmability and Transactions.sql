-- Problem 1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS 
SELECT 
	FirstName,
	LastName
FROM Employees
WHERE Salary>35000

-- Problem 2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @salary DECIMAL(18,4)
AS
SELECT
	FirstName,
	LastName
FROM Employees
WHERE Salary>=@salary

-- Problem 3
CREATE PROCEDURE usp_GetTownsStartingWith @str NVARCHAR(20)
AS
SELECT 
	[Name]
FROM Towns
WHERE [Name] LIKE @str+'%'

-- Problem 4
CREATE PROCEDURE usp_GetEmployeesFromTown  @townName NVARCHAR(50)
AS
SELECT 
	e.FirstName,
	e.LastName
FROM Towns t
JOIN Addresses a
ON a.TownID=t.TownID
JOIN Employees e
ON e.AddressID=a.AddressID
WHERE t.[Name]=@townName

-- Problem 5
CREATE FUNCTION dbo.ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS 
BEGIN
	DECLARE @output NVARCHAR(10)
	IF(@salary<30000)
	BEGIN
		SET @output='Low'
	END
	ELSE IF(@salary<=50000)
	BEGIN
		SET @output='Average'
	END
	ELSE IF(@salary>50000)
	BEGIN
		SET @output='High'
	END
RETURN @output
END

-- Problem 6
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@salaryLevel NVARCHAR(10))
AS
SELECT
	FirstName,
	LastName
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel

-- Problem 7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(100))
AS
BEGIN
	DECLARE @result BIT
	DECLARE @count INT = 1

	WHILE @count <= LEN(@Word)
	BEGIN
		DECLARE @currentSymbol VARCHAR(2) = SUBSTRING(@Word, @count, 1)

		IF(CHARINDEX(@currentSymbol, @SetOfLetters)) > 0
			BEGIN
				SET @result = 1
				SET @count+=1
			END
		ELSE
			BEGIN
				SET @result = 0
				BREAK
			END
	END
	RETURN @result
END

-- Problem 8
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS

-- Problem 9
CREATE PROCEDURE usp_GetHoldersFullName
AS
SELECT
	CONCAT(FirstName,' ',LastName) [Full Name]
FROM AccountHolders

-- Problem 10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @number DECIMAL(18,2) 
AS
SELECT
	ah.FirstName,
	ah.LastName
FROM AccountHolders ah
JOIN Accounts a
ON a.AccountHolderId=ah.Id
GROUP BY ah.FirstName,ah.LastName
HAVING @number<SUM(a.Balance)
ORDER BY FirstName,LastName

-- Problem 11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearlyInterestRate FLOAT,@numberOfYears INT)
RETURNS DECIMAL (18,4)
AS
BEGIN
	DECLARE  @poweredNum FLOAT= POWER(1+@yearlyInterestRate,@numberOfYears)
	DECLARE  @result DECIMAL(18,5)
	SET @result=@sum*@poweredNum
	RETURN @result
END

-- Problem 12
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@accountId INT,  @yearlyInterestRate FLOAT)
AS
BEGIN
SELECT
	a.Id,
	FirstName,
	LastName,
	a.Balance,
	dbo.ufn_CalculateFutureValue(a.Balance,0.1,5) [Balance in 5 years]
FROM AccountHolders ah
JOIN Accounts a
ON a.AccountHolderId=ah.Id
WHERE @accountId=a.Id
END
DROP PROCEDURE usp_CalculateFutureValueForAccount
EXEC usp_CalculateFutureValueForAccount 1,0.1

-- Problem 13
CREATE FUNCTION ufn_CashInUsersGames(@Game VARCHAR(50))
RETURNS TABLE
AS
RETURN
SELECT SUM([k].[Cash]) AS [SumCash]
  FROM (
SELECT [ug].[Cash] AS [Cash],
       ROW_NUMBER() OVER (PARTITION BY [g].[Name] ORDER BY [ug].[Cash] DESC) AS [Row]
  FROM [dbo].[Games] AS g
  JOIN [dbo].[UsersGames] AS [ug] ON [g].[Id] = [ug].[GameId]
 WHERE [g].[Name] = @Game) AS k
 WHERE [k].[Row] % 2 = 1
	DROP FUNCTION ufn_CashInUsersGames
SELECT * FROM dbo.ufn_CashInUsersGames( 'Love in a mist')

