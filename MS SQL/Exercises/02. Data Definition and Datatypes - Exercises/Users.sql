CREATE DATABASE Users;
Use Users;

CREATE TABLE Users(
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] IMAGE,
[LastLoginTime] DATETIME,
[IsDeleted] VARCHAR(5) NOT NULL CHECK([IsDeleted] = 'true' OR [IsDeleted] = 'false')
);

INSERT INTO Users([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES ('Pesho', '1234', NULL, NULL, 'false'),
('Gosho', '12345', NULL, NULL, 'false'),
('Alex', '123456', NULL, NULL, 'true'),
('Iva', '1234567', NULL, NULL, 'true'),
('Nadya', '12345678', NULL, NULL, 'false');