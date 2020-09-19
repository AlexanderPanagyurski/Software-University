/*02. Find All Information About Departments*/
SELECT *
 FROM DEPARTMENTS

/*03. Find all Department Names*/
SELECT Name
 FROM DEPARTMENTS 

/*04. Find Salary of Each Employee*/
SELECT FirstName,LastName,Salary
 FROM Employees 

/*05. Find Full Name of Each Employee*/
SELECT FirstName,MiddleName,LastName
 FROM Employees 

/*06. Find Email Address of Each Employee*/
SELECT FirstName+'.'+LastName+'@softuni.bg' 
AS 'Full Email Address'
 FROM Employees

/*07. Find All Different Employee’s Salaries*/
SELECT DISTINCT Salary
FROM Employees

/*08. Find all Information About Employees*/
SELECT *
FROM Employees
WHERE JobTitle='Sales Representative'

/*09. Find Names of All Employees by Salary in Range*/
SELECT FirstName,LastName,JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

/*10. Find Names of All Employees*/
SELECT CONCAT(FirstName,' ',MiddleName,' ',LastName) AS 'Full Name'
FROM Employees
WHERE Salary IN (25000, 14000, 12500,23600)

/*11. Find All Employees Without Manager*/
SELECT FirstName,LastName
FROM Employees
WHERE ManagerID IS NULL

/*12. Find All Employees with Salary More Than*/
SELECT FirstName,LastName,Salary
FROM Employees
WHERE Salary >50000
ORDER BY Salary DESC

/*13. Find 5 Best Paid Employees*/
SELECT TOP(5)FirstName, LastName
FROM Employees
ORDER BY Salary DESC

/*14. Find All Employees Except Marketing
Write a SQL query to find the first and last names 
of all employees whose department ID is different from 4.*/
SELECT FirstName,LastName
FROM Employees
WHERE DepartmentID != 4

/*15. Sort Employees Table
Write a SQL query to sort all records in the Employees table by the following criteria: 
•	First by salary in decreasing order
•	Then by first name alphabetically
•	Then by last name descending
•	Then by middle name alphabetically*/
SELECT *
FROM Employees
ORDER BY Salary DESC,FirstName, LastName DESC,MiddleName

/*16. Create View Employees with Salaries*/
CREATE VIEW  [V_EmployeesSalaries] AS
SELECT
FirstName,LastName,Salary
FROM Employees

/*17. Create View Employees with Job Titles*/
CREATE VIEW  [V_EmployeeNameJobTitle] AS
SELECT
CONCAT(FirstName,' ',MiddleName,' ',LastName) AS 'Full Name',JobTitle
FROM Employees

/*18. Distinct Job Titles
Write a SQL query to find all distinct job titles.*/
SELECT DISTINCT JobTitle 
FROM Employees

/* 19. Find First 10 Started Projects
Write a SQL query to find first 10 started projects. 
Select all information about them and sort them by start date, then by name.*/
SELECT TOP(10) *  
FROM Projects
ORDER BY StartDate,Name

/*20. Last 7 Hired Employees
Write a SQL query to find last 7 hired employees. 
Select their first, last name and their hire date.*/
SELECT TOP(7) FirstName,LastName,HireDate
FROM Employees
ORDER By HireDate DESC

/*21. Increase Salaries
Write a SQL query to increase salaries of all employees that are in the Engineering,
Tool Design, Marketing or Information Services department by 12%.
Then select Salaries column from the Employees table.
After that exercise restore your database to revert those changes.*/
UPDATE Employees
SET Salary+=Salary*0.12
WHERE DepartmentID IN (1,2,4,11)

SELECT Salary FROM Employees


/* 22. All Mountain Peaks
Display all mountain peaks in alphabetical order.
*/
SELECT  PeakName
FROM Peaks
Order By PeakName

/* 23. Biggest Countries by Population
Find the 30 biggest countries by population from Europe.
Display the country name and population.
Sort the results by population (from biggest to smallest),
 then by country alphabetically. */

 SELECT TOP(30) CountryName,[Population]
FROM Countries
WHERE ContinentCode='EU'
Order By Population DESC

/*24. *Countries and Currency (Euro / Not Euro)
Find all countries along with information about their currency. 
Display the country name, country code and information 
about its currency: either "Euro" or "Not Euro". Sort the results by country name alphabetically.*/

SELECT CountryName, CountryCode, 
CASE
	WHEN CurrencyCode !='EUR' THEN 'Not Euro'
	WHEN CurrencyCode ='EUR' THEN 'Euro'
	WHEN CurrencyCode IS NULL THEN 'Not Euro'
END AS Currency
FROM Countries
ORDER BY CountryName

/* 25. All Diablo Characters
Display all characters in alphabetical order. 
*/
SELECT [Name] 
FROM Characters
ORDER BY [Name]
