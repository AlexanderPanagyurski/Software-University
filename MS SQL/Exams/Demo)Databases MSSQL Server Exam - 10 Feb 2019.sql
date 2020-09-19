CREATE DATABASE ColonialJourney
USE ColonialJourney


-- 01. DDL
CREATE TABLE Planets(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL,
	BirthDate Date NOT NULL
	UNIQUE (Ucn)
)

CREATE TABLE Journeys(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) CHECK (Purpose='Medical' OR Purpose='Technical' 
						OR Purpose='Educational' OR Purpose='Military'),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CardNumber CHAR(10) NOT NULL UNIQUE(CardNumber),
	JobDuringJourney VARCHAR(8) NOT NULL CHECK(JobDuringJourney='Pilot' OR JobDuringJourney='Engineer' 
					OR JobDuringJourney='Trooper' OR JobDuringJourney='Cleaner' OR JobDuringJourney='Cook'),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)

-- 02. Insert
INSERT INTO Planets([Name]) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships([Name],[Manufacturer],[LightSpeedRate]) VALUES
('Golf','VW',3),
('WakaWaka','Wakanda',4),
('Falcon9','SpaceX',1),
('Bed','Vidolov',6)

-- 03. Update
UPDATE Spaceships
SET [LightSpeedRate]+=1
WHERE [Id] BETWEEN 8 AND 12

-- 04. Delete
DELETE
  FROM [dbo].[TravelCards]
 WHERE [dbo].[TravelCards].[JourneyId] IN (1, 2, 3);

DELETE
  FROM [dbo].[Journeys]
 WHERE [dbo].[Journeys].[Id] IN (1, 2, 3)

 -- 05. Select All Travel Cards

 SELECT 
	tc.CardNumber,
	tc.JobDuringJourney
 FROM dbo.TravelCards tc
 ORDER BY tc.CardNumber

 -- 06. Select All Colonists
 SELECT 
	c.Id,
	CONCAT(c.FirstName,' ',c.LastName) AS FullName,
	c.Ucn 
 FROM dbo.Colonists c
 ORDER BY c.FirstName,c.LastName,c.Id

 -- 07. Select All Military Journeys
 SELECT 
	j.Id,
	CONVERT(VARCHAR,j.JourneyStart,103) AS JourneyStart,
	CONVERT(VARCHAR,j.JourneyEnd,103) AS JourneyEnd 
 FROM dbo.Journeys j
 WHERE j.Purpose='Military'
 ORDER BY JourneyStart

 -- 08. Select All Pilots
 SELECT 
	 c.Id,
	 CONCAT(c.FirstName,' ',c.LastName) AS FullName
 FROM dbo.Colonists c
 JOIN dbo.TravelCards tc
 ON tc.ColonistId=c.Id
 WHERE tc.JobDuringJourney='Pilot'
 ORDER BY c.Id

 -- 09. Count Colonists
SELECT 
	COUNT(*) AS [Count]
FROM dbo.Colonists c
JOIN dbo.TravelCards tc 
ON tc.ColonistId=c.Id
JOIN dbo.Journeys j
ON j.Id=TC.JourneyId
WHERE j.Purpose='Technical'

-- 10. Select The Fastest Spaceship
SELECT TOP(1)
	 s.[Name] AS SpaceshipName,
	 sp.[Name] AS SpaceportName
FROM dbo.Spaceships s
JOIN Journeys j
ON j.SpaceshipId=s.Id
JOIN Spaceports sp
ON sp.Id=j.DestinationSpaceportId
ORDER BY s.LightSpeedRate DESC

-- 11. Select Spaceships With Pilots
SELECT  
	s.[Name],
	s.Manufacturer
FROM dbo.Spaceships s
JOIN Journeys j
ON j.SpaceshipId=s.Id
JOIN TravelCards tc
ON tc.JourneyId=j.Id
JOIN Colonists c
ON c.Id=tc.ColonistId
WHERE tc.JobDuringJourney='Pilot' 
AND DATEDIFF(YEAR,Convert(Date,c.BirthDate,101),CONVERT(DATE,'01/01/2019',101))<30
ORDER BY s.[Name]

-- 12. Select All Educational Mission
SELECT 
	p.[Name] AS PlanetName,
	s.[Name] AS SpaceportName
FROM Planets p
JOIN Spaceports s
ON s.PlanetId=p.Id
JOIN Journeys j
ON j.DestinationSpaceportId=s.Id
WHERE j.Purpose='Educational'
ORDER BY SpaceportName DESC

-- 13. Planets And Journeys
SELECT 
	p.[Name] AS PlanetName,
	COUNT(j.Id) AS JourneysCount
FROM Planets p
JOIN Spaceports s
ON s.PlanetId=p.Id
JOIN Journeys j
ON j.DestinationSpaceportId=s.Id
GROUP BY p.[Name]
ORDER BY JourneysCount DESC, PlanetName

-- 14. Extract The Shortest Journey
SELECT TOP(1)
	j.Id,
	p.[Name] AS PlanetName,
	s.[Name] AS SpaceportName,
	j.Purpose AS JourneyPurpose
FROM Journeys j
JOIN Spaceports s
ON j.DestinationSpaceportId=s.Id
JOIN Planets p
ON s.PlanetId=p.Id
GROUP BY j.Id,p.[Name],s.[Name],j.Purpose
ORDER BY MIN(DATEDIFF(DAY,j.JourneyEnd,j.JourneyStart)) DESC

-- 15. Select The Less Popular Job
SELECT TOP(1) [k].[JourneyId], [tc].[JobDuringJourney]
    FROM (
  SELECT TOP(1) [j].[Id] AS [JourneyId]
    FROM [dbo].[Journeys] AS j
ORDER BY DATEDIFF(DAY, [j].[JourneyStart], [j].[JourneyEnd]) DESC) AS k
    JOIN [dbo].[TravelCards] AS tc ON [k].[JourneyId] = [tc].[JourneyId]
GROUP BY [tc].[JobDuringJourney], [k].[JourneyId]
ORDER BY COUNT([tc].[JobDuringJourney]);

