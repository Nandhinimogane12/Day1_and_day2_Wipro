
USE Mydatabase;

-- Creating Students Table
CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(50),
    department VARCHAR(50)
);

-- Inserting Data into Students
INSERT INTO Students (student_id, student_name, department)
VALUES
(1, 'Arun', 'CSE'),
(2, 'Meena', 'ECE'),
(3, 'Ravi', 'EEE'),
(4, 'Divya', 'IT');

-- To View Students Table
SELECT * FROM Students;


-- Create Courses Table
CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    student_id INT,
    course_name VARCHAR(50)
);

-- Inserting Data into Courses
INSERT INTO Courses (course_id, student_id, course_name)
VALUES
(101, 1, 'Data Structures'),
(102, 1, 'DBMS'),
(103, 3, 'Circuits'),
(104, 2, 'Signals');

--To View Courses Table
SELECT * FROM Courses;

--JOINS

--INNER JOIN (Only matching records)
SELECT 
s.student_name AS Student_Name,
c.course_name AS Course_Name
FROM Students s
INNER JOIN Courses c 
ON s.student_id = c.student_id;


--LEFT JOIN (All students + matching courses)
SELECT 
s.student_name AS Student_Name,
c.course_name AS Course_Name
FROM Students s
LEFT JOIN Courses c 
ON s.student_id = c.student_id;


--RIGHT JOIN (All courses + matching students)
SELECT 
s.student_name AS Student_Name,
c.course_name AS Course_Name
FROM Students s
RIGHT JOIN Courses c 
ON s.student_id = c.student_id;