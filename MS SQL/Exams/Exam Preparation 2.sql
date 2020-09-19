CREATE DATABASE School
USE School
CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL CHECK(Age > 0),
	[Address] NVARCHAR(50),
	Phone NVARCHAR(10)
)


CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL CHECK(Lessons > 0)
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	StudentId INT FOREIGN KEY REFERENCES [dbo].[Students]([Id]) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES [dbo].[Subjects]([Id]) NOT NULL,
	Grade DECIMAL(15, 2) NOT NULL CHECK (Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Date] DATETIME,
	SubjectId INT FOREIGN KEY REFERENCES [dbo].[Subjects]([Id]) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentId INT FOREIGN KEY REFERENCES [dbo].[Students]([Id]) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES [dbo].[Exams]([Id]) NOT NULL,
	Grade DECIMAL(15, 2) NOT NULL CHECK(Grade BETWEEN 2 AND 6),
	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone NVARCHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES [dbo].[Subjects]([Id]) NOT NULL
)

CREATE TABLE StudentsTeachers(
	StudentId INT FOREIGN KEY REFERENCES [dbo].[Students]([Id]) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES [dbo].[Teachers]([Id]) NOT NULL,
	CONSTRAINT PK_StudentsTeachers PRIMARY KEY(StudentId, TeacherId)
)
INSERT INTO Teachers(FirstName,LastName,[Address],Phone,SubjectId)
VALUES
('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
('Gerrard','Lowin','370 Talisman Plaza','3324874824',2),
('Merrile','Lambdin','81 Dahle Plaza','4373065154',5),
('Bert','Ivie','2 Gateway Circle','4409584510',4)

INSERT INTO Subjects([Name],Lessons)
VALUES
('Geometry',12),
('Health',10),
('Drama',7),
('Sports',9)

UPDATE dbo.StudentsSubjects
SET Grade=6.00
WHERE dbo.StudentsSubjects.SubjectId IN (1,2) AND dbo.StudentsSubjects.Grade>=5.50

DELETE
  FROM [dbo].[StudentsTeachers]
 WHERE [dbo].[StudentsTeachers].[TeacherId] IN (SELECT [dbo].[Teachers].[Id]
                                                  FROM [dbo].[Teachers]
                                                 WHERE [dbo].[Teachers].[Phone] LIKE '%72%');

DELETE
  FROM [dbo].[Teachers]
 WHERE [dbo].[Teachers].[Phone] LIKE '%72%';

SELECT 
	t.Phone 
FROM Teachers t

SELECT 
	s.FirstName,
	s.LastName,
	s.Age 
FROM dbo.Students s
WHERE s.Age>=12
ORDER BY s.FirstName,s.LastName

SELECT 
	s.FirstName,
	s.LastName,
	COUNT(t.Id)
FROM dbo.Students s
JOIN dbo.StudentsTeachers st
ON st.StudentId=s.Id
JOIN dbo.Teachers t
ON t.Id=st.TeacherId
GROUP BY s.FirstName,s.LastName

SELECT 
	 CONCAT(s.FirstName,' ',s.LastName) AS [Full Name]
FROM dbo.Students s
LEFT JOIN dbo.StudentsExams se
ON se.StudentId=s.Id
WHERE se.StudentId IS NULL
ORDER BY [Full Name]

SELECT TOP(10)
	 s.FirstName,
	 s.LastName,
	 STR(AVG(se.Grade),12,2) Grade
FROM dbo.Students s
JOIN [dbo].StudentsExams se
ON se.StudentId=s.Id
GROUP BY s.FirstName,s.LastName,se.StudentId
ORDER BY Grade DESC,s.FirstName,s.LastName

SELECT 
	CASE
		WHEN s.MiddleName IS NOT NULL THEN CONCAT(s.FirstName,' ',s.MiddleName,' ',s.LastName) 
		WHEN s.MiddleName IS NULL THEN CONCAT(S.FirstName,' ',s.LastName)	
	END AS [Full Name]
FROM [dbo].Students s
LEFT JOIN [dbo].[StudentsSubjects] ss
ON ss.StudentId=s.Id
WHERE ss.StudentId IS NULL
ORDER BY [Full Name]

SELECT 
	s.[Name],
	AVG(ss.Grade) AS AverageGrade
FROM [dbo].[Subjects] s
JOIN [dbo].[StudentsSubjects] ss
ON ss.SubjectId=s.Id
GROUP BY s.[Name],ss.SubjectId
ORDER BY ss.SubjectId
go
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @findId INT;
	DECLARE @count INT
	DECLARE @result VARCHAR(MAX)
	SET @findId=(SELECT s.Id FROM dbo.Students s WHERE s.Id=@studentId)
	IF(@findId IS NULL)
	BEGIN
		SET @result='The student with provided id does not exist in the school!'
	END
	ELSE IF (@findId IS NOT NULL)
	BEGIN
		IF(@grade>6.00)
		BEGIN
			SET @result='Grade cannot be above 6.00!'
		END
	ELSE
	BEGIN
		DECLARE @studentName VARCHAR(30)
		SET @count=(SELECT COUNT(*) FROM dbo.Students s JOIN dbo.StudentsExams se ON se.StudentId=s.Id WHERE s.Id=@studentId AND se.Grade>=@grade AND se.Grade<=@grade+0.50)
		SET @studentName=(SELECT s.FirstName FROM Students s WHERE s.Id=@studentId)
			SET @result='You have to update '+CONVERT(VARCHAR(MAX),@count)+' grades for the student '+@studentName
	END
END
	RETURN  @result
END
go
CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
DECLARE @doesExist INT
SET @doesExist= (SELECT dbo.Students.Id FROM dbo.Students WHERE dbo.Students.Id=@StudentId)
IF(@doesExist IS NULL)
BEGIN
	RAISERROR ('This school has no student with the provided id!',16,1)
	RETURN
END
	DELETE FROM dbo.StudentsSubjects 
	WHERE dbo.StudentsSubjects.StudentId IN (SELECT se.StudentId  
	FROM dbo.StudentsSubjects se
	WHERE se.StudentId=@StudentId)
	
	DELETE FROM dbo.StudentsExams
	WHERE dbo.StudentsExams.StudentId IN (SELECT se.StudentId
	FROM dbo.StudentsExams se
	WHERE se.StudentId=@StudentId)
	
	DELETE FROM dbo.StudentsTeachers
	WHERE dbo.StudentsTeachers.StudentId IN(SELECT st.StudentId
	FROM dbo.StudentsTeachers st 
	WHERE st.StudentId=@StudentId )
	
	DELETE FROM dbo.Students WHERE dbo.Students.Id=@StudentId
