CREATE DATABASE Mydatabase;
USE Mydatabase;

CREATE TABLE Student(
Id INT,
Name VARCHAR(20),
Age INT,
Grade VARCHAR(20)
);

INSERT INTO Student VALUES
(101,'Anch',22,'A'),
(102,'Pia',21,'S'),
(103,'Dhoni',44,'B'),
(104,'Virat',32,'A');

SELECT * FROM Student;

SELECT Name FROM Student WHERE Age<30;

SELECT AVG(Age) FROM Student;

SELECT COUNT(*) FROM Student WHERE Age>30;

INSERT INTO Student VALUES(105,'Kholi',34,'S');

SELECT Id,Name,Age,Grade FROM Student;

UPDATE Student SET Name='Nands' WHERE Id=105;

SELECT * FROM Student;

DELETE FROM Student WHERE Id=103;

SELECT * FROM Student;

SELECT * FROM Student ORDER BY Name ASC;

SELECT * FROM Student ORDER BY Id DESC;

SELECT * FROM Student ORDER BY Grade ASC, Age DESC;


