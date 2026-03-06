USE ITI;
GO
-- Q1.
CREATE VIEW StudentCourseView AS
SELECT s.St_Fname + ' ' + s.St_Lname AS FullName,
    c.Crs_Name
FROM Student s INNER JOIN Stud_Course e 
ON s.st_Id = e.st_Id
INNER JOIN Course c 
ON e.Crs_Id = c.Crs_Id
WHERE e.Grade > 50;
GO
-- Q2.
CREATE VIEW InstructorTopicsView
WITH ENCRYPTION
AS
SELECT 
    i.Ins_Name,
    t.Top_Name
FROM Instructor i INNER JOIN Ins_Course ic 
ON i.Ins_Id = ic.Ins_Id
INNER JOIN Course c
ON c.Crs_Id = ic.Crs_Id
INNER JOIN Topic t
ON t.Top_Id = c.Top_Id;
GO
-- Q3 
CREATE VIEW InstructorDeptView AS
SELECT 
    Ins_Name,
    d.Dept_Name
FROM Instructor i INNER JOIN Department d 
ON i.Dept_Id = d.Dept_Id
WHERE d.Dept_Name IN ('SD', 'Java');
-- Q4.
GO
CREATE VIEW V1 AS
SELECT st_id, St_Fname, st_address
FROM Student
WHERE st_address IN ('Alex', 'Cairo');
GO
-- Q5.
USE Company_SD;
GO
CREATE VIEW V2 AS
SELECT 
    p.Pname,
    COUNT(e.SSN) AS NumberOfEmployees
FROM Project p INNER JOIN Works_for ep 
ON p.Pnumber = ep.Pno
INNER JOIN Employee e 
ON ep.ESSn = e.SSN
GROUP BY p.Pname;
GO
-- Q6
-- 
-- CREATE CLUSTERED INDEX idx1  ON Departments ([MGRStart Date]);
-- Q7
CREATE INDEX idx2 ON [Human Resource].Employee (Age);

---------------------
-- Q2.
GO
CREATE SCHEMA Company;
GO
ALTER SCHEMA Company TRANSFER dbo.Departments;
ALTER SCHEMA Company TRANSFER dbo.Project;
GO
CREATE SCHEMA [Human Resource];
GO
ALTER SCHEMA [Human Resource] TRANSFER dbo.Employee;

-- Q3 
SELECT 
    CONSTRAINT_NAME,
    CONSTRAINT_TYPE
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME = 'Employee';

-- 4.	Create Synonym for table Employee as Emp and then run the following queries and describe the results
CREATE SYNONYM Emp 
FOR Company_SD.[Human Resource].Employee;

Select * from [Human Resource].Emp