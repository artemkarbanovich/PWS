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
	('�������� �������'),
	('����� ���������'), 
	('��������� �����������');

INSERT INTO Note (StudentId, Subject, Note) VALUES 
	(1, '������������ ����������������', 4),
	(1, '������ ����������� � �� ����������� ��� ����������� ����������', 5),
	(1, '������ ����� � ����', 1),
	(2, '������ ��������������', 5),
	(2, '�������� �����������', 3),
	(2, '��������� �������', 2),
	(3, '������ ���������������� ������', 5),
	(3, '���������� �������� � �� ����������� ��� ����������', 4),
	(3, '������ ����� ���� � �����', 1);
