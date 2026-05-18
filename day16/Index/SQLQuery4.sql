USE Mydatabase;

CREATE TABLE NewEmployee(
	EmpID INT PRIMARY KEY,
	Name VARCHAR(50),
	Salary INT,
	DeptID INT,
	Department VARCHAR(50)  
);
GO

INSERT INTO NewEmployee (EmpID, Name, Salary, DeptID, Department)
VALUES (1, 'Ravi Kumar', 75000, 201, 'IT'),
       (2, 'Priya Sharma', 82000, 202, 'Finance'),
       (3, 'Arjun Singh', 65000, 203, 'HR'),
       (4, 'Neha Patel', 65000, 201, 'IT'),
       (5, 'Vikram Reddy', 91000, 204, 'Marketing');
GO

-- Query 1: Before index
SELECT * FROM NewEmployee WHERE Department = 'IT';
GO

-- Create index on Department column
CREATE INDEX idx_dept ON NewEmployee(Department);
GO

-- Query 2: After index - check execution plan
SET STATISTICS IO ON;
SET STATISTICS TIME ON;
GO

SELECT * FROM NewEmployee WHERE Department = 'IT';

SET STATISTICS IO OFF;
SET STATISTICS TIME OFF;
GO