CREATE DATABASE WSKAK;

CREATE TABLE Student (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(70),
);

CREATE TABLE Note (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	StudentId INT,
	Subject nvarchar(70),
	Note INT,

	CONSTRAINT FK__NOTE__ID FOREIGN KEY (StudentId) REFERENCES Student(Id),
);

INSERT INTO Student (Name) VALUES
	('Владимир Думской'),
	('Федор Наждачник'), 
	('Александр Твердолобов');

INSERT INTO Note (StudentId, Subject, Note) VALUES 
	(1, 'Коллективное интервьюирование', 4),
	(1, 'Основы геополитики и ее последствия для либеральной демократии', 5),
	(1, 'Основы права в сети', 1),
	(2, 'Основы кибернападения', 5),
	(2, 'Изучение декабристов', 3),
	(2, 'Публичный дискурс', 2),
	(3, 'Основы коммунистической партии', 5),
	(3, 'Физическая культура и ее последствия для интеллекта', 4),
	(3, 'Умение вести себя в кадре', 1);
