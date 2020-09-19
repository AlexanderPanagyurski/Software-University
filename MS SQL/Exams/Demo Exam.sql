CREATE DATABASE Bitbucket
USE Bitbucket

-- 01. DDL
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	CONSTRAINT PK_RepositoriesContributors PRIMARY KEY(RepositoryId,ContributorId)
)

CREATE TABLE Issues(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)
-- 02. Insert
INSERT INTO Files([Name],Size,ParentId,CommitId) VALUES
('Trade.idk',2598.0,1,1),
('menu.net',9238.31,2,2),
('Administrate.soshy',1246.93,3,3),
('Controller.php',7353.15,4,4),
('Find.java',9957.86,5,5),
('Controller.json',14034.87,3,6),
('Operate.xix',7662.92,7,7)

INSERT INTO Issues(Title,IssueStatus,RepositoryId,AssigneeId) VALUES
('Critical Problem with HomeController.cs file','open',1,4),
('Typo fix in Judge.html','open',4,3),
('Implement documentation for UsersService.cs','closed',8,2),
('Unreachable code in Index.cs','open',9,8)

-- 03. Update
UPDATE Issues 
SET IssueStatus='closed' WHERE AssigneeId=6

--04. Delete
  
DELETE FROM dbo.RepositoriesContributors 
WHERE dbo.RepositoriesContributors.RepositoryId IN (
SELECT r.Id FROM dbo.Repositories r WHERE r.[Name]='Softuni-Teamwork')

DELETE FROM dbo.Issues WHERE dbo.Issues.RepositoryId IN (
SELECT r.Id FROM dbo.Repositories r WHERE r.[Name]='Softuni-Teamwork')
 
-- 05. Commits
SELECT 
	c.Id,
	c.[Message],
	c.RepositoryId,
	c.ContributorId 
FROM dbo.Commits c
ORDER BY c.Id,c.[Message],c.RepositoryId,c.ContributorId

-- 06. Heavy HTML
SELECT 
	f.Id,
	f.[Name],
	f.Size 
FROM dbo.Files f
WHERE f.Size>1000 AND f.[Name] LIKE '%html%'
ORDER BY f.Size DESC,f.Id,f.[Name]

-- 07. Issues and Users
SELECT 
	i.Id,
	CONCAT(u.Username,' : ',i.Title) AS IssueAssignee 
FROM dbo.Issues i
JOIN dbo.Users u
ON i.AssigneeId=u.Id
ORDER BY i.Id DESC, i.Title

-- 08. Non-Directory Files
SELECT 
	f.Id,
	f.[Name],
	CONCAT(f.Size,'KB') AS Size 
FROM dbo.Files f
LEFT JOIN dbo.Files ff 
ON f.Id=ff.ParentId
WHERE ff.ParentId IS NULL
ORDER BY f.Id,f.[Name],Size DESC

-- 09. Most Contributed Repositories
SELECT TOP(5) r.Id,r.[Name],
		(Count(c.RepositoryId)+COUNT(rc.RepositoryId))/2 AS [Commits Count]
FROM dbo.Repositories r
JOIN dbo.Commits c
ON c.RepositoryId=r.Id
JOIN dbo.RepositoriesContributors rc
ON rc.RepositoryId=r.Id
GROUP BY r.Id,r.[Name]
ORDER BY [Commits Count] DESC ,r.Id,r.[Name]

-- 10. User and Files
SELECT 
	u.Username,
	AVG(f.Size) AS AvgSize
FROM Users u
JOIN Commits c
ON c.ContributorId=u.Id
JOIN Files f
ON f.CommitId=c.Id
GROUP BY u.Username
ORDER BY AvgSize DESC, u.Username
GO
-- Problem 11
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @result INT

	SET @result=(SELECT  COUNT(*)
	FROM dbo.Users u
	JOIN dbo.Commits c
	ON c.ContributorId=u.Id
	WHERE u.Username=@username)
	RETURN @result
END

SELECT dbo.udf_UserTotalCommits ('UnderSinduxrein')
GO

--Problem 12
CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(20))
AS
SELECT 
	f.Id,
	f.[Name],
	CONCAT(f.Size,'KB') AS Size 
FROM dbo.Files f
WHERE f.[Name] LIKE '%'+@extension+'%'
ORDER BY f.Id,f.[Name],Size DESC

EXEC usp_FindByExtension 'txt'