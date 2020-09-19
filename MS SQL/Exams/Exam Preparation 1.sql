CREATE DATABASE Airport
USE Airport


-- Section 1 DDL
CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL 
)

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin NVARCHAR(50) NOT NULL,
	Destination NVARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	PassportId NVARCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Type] NVARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(10,2) NOT NULL
)

-- 2.	Insert

INSERT INTO Planes([Name],Seats,[Range])
VALUES
('Airbus 336',112,5132),
('Airbus 330',432,5325),
('Boeing 369',231,2355),
('Stelt 297',254,2143),
('Boeing 338',165,5111),
('Airbus 558',387,1342),
('Boeing 128',345,5541)

INSERT INTO LuggageTypes([Type])
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

UPDATE t
SET t.Price+=t.Price*0.13 
FROM Tickets t
JOIN Flights f
ON  f.Id=t.FlightId
WHERE Destination='Carlsbad'

ALTER TABLE Tickets NOCHECK CONSTRAINT ALL 
DELETE FROM Flights WHERE Destination='Ayn Halagim'
ALTER TABLE TICKETS CHECK CONSTRAINT ALL

-- Section 3. Querying (40 pts)
SELECT 
	Id,
	[Name],
	Seats,
	[Range]
FROM Planes
WHERE [Name] Like '%tr%'
ORDER BY Id,[Name],Seats,[Range]

SELECT 
	FlightId,
	SUM(t.Price) Price 
FROM Flights f
JOIN Tickets t
ON t.FlightId=f.Id
GROUP BY FlightId
ORDER BY Price DESC,FlightId

SELECT 
	CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
	f.Origin,
	f.Destination 
FROM Flights f
JOIN Tickets t
ON t.FlightId=f.Id
JOIN Passengers p
ON p.Id=t.PassengerId
ORDER BY [Full Name],Origin,Destination

SELECT 
	FirstName,
	LastName,
	Age
FROM Passengers p
LEFT JOIN Tickets t
ON t.PassengerId=p.Id
WHERE t.Id IS NULL
ORDER BY Age DESC,FirstName,LastName

SELECT  
	CONCAT(FirstName,' ',LastName) AS [Full Name],
	pl.[Name] AS [Plane Name],
	CONCAT(f.Origin,' - ',f.Destination) AS Trip,
	lt.[Type] AS [Luggage Type] 
FROM LuggageTypes lt
JOIN Luggages l
ON l.LuggageTypeId=lt.Id
JOIN Tickets t
ON t.LuggageId=l.Id
JOIN Passengers p
ON p.Id=t.PassengerId
JOIN Flights f
ON f.Id=t.FlightId
Join Planes pl
ON pl.Id=f.PlaneId
ORDER BY [Full Name],[Plane Name],f.Origin,f.Destination,[Luggage Type]