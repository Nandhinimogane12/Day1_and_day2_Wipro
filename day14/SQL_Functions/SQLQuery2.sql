use Mydatabase;
CREATE TABLE Employees
(
    EmpID INT PRIMARY KEY,         
    FirstName VARCHAR(50),         
    LastName VARCHAR(50),           
    Department VARCHAR(50),         
    Salary INT                      
);
INSERT INTO Employees(EmpID, FirstName, LastName, Department, Salary)
VALUES
(101, 'John', 'Smith', 'IT', 60000),
(102, 'Emma', 'Johnson', 'HR', 50000),
(103, 'Michael', 'Brown', 'Finance', 55000),
(104, 'Sophia', 'Davis', 'IT', 65000),
(105, 'Daniel', 'Wilson', 'Sales', 48000);
SELECT * FROM Employees;

/* =========================================
   FUNCTION 1: Get Annual Salary
   Returns yearly salary based on monthly salary
========================================= */
CREATE FUNCTION GetAnnualSalary (@EmpID INT)
RETURNS INT
AS
BEGIN
    DECLARE @AnnualSalary INT

    -- Calculate Annual Salary (Monthly Salary * 12)
    SELECT @AnnualSalary = Salary * 12
    FROM Employees
    WHERE EmpID = @EmpID

    RETURN @AnnualSalary
END
GO


/* =========================================
   FUNCTION 2: Get Employees with Salary > Given Value
   Returns FirstName and LastName
========================================= */
CREATE FUNCTION GetEmployeeBySalary (@MinSalary INT)
RETURNS TABLE
AS
RETURN
(
    -- Select employees whose salary is greater than input value
    SELECT FirstName, LastName
    FROM Employees
    WHERE Salary > @MinSalary
)
GO


/* =========================================
   FUNCTION 3: Calculate Bonus
   Rules:
   IT      → 15%
   HR      → 12%
   Others  → 10%
========================================= */
CREATE FUNCTION GetBonus
(
    @Department VARCHAR(50),
    @Salary INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Bonus INT

    -- Apply bonus based on department
    IF @Department = 'IT'
        SET @Bonus = @Salary * 15 / 100
    ELSE IF @Department = 'HR'
        SET @Bonus = @Salary * 12 / 100
    ELSE
        SET @Bonus = @Salary * 10 / 100

    RETURN @Bonus
END
GO


/*******************************************
   SAMPLE USAGE (TESTING)
*******************************************/

-- Get Annual Salary of Employee
SELECT dbo.GetAnnualSalary(101) AS AnnualSalary;

-- Get Employees with Salary greater than 50000
SELECT * FROM dbo.GetEmployeeBySalary(50000);

-- Get Bonus for an IT Employee
SELECT dbo.GetBonus('IT', 60000) AS Bonus;