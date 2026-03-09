USE ITI;
GO
-- Q1
CREATE PROCEDURE StudentsCount 
AS
BEGIN
	SELECT d.Dept_Name, 
		   COUNT(s.St_Id) AS [Students Count] 
	FROM Department d LEFT JOIN Student s 
	ON d.Dept_Id = s.Dept_Id 
	GROUP BY d.Dept_Name;
END;
EXEC StudentsCount;
---
-- Q2
GO
CREATE PROCEDURE PrintEventValue (
@num1 int,@num2  int)
AS
BEGIN 
IF(@num1 <= @num2)
BEGIN
	DECLARE @currentNum int =@num1;  
	WHILE @currentNum <= @num2
	BEGIN	
		IF @currentNum % 2 = 0
			PRINT @currentNum
		SET @currentNum = @currentNum + 1
	END
END;
ELSE
BEGIN
	SET @currentNum  = @num2  
	WHILE @currentNum <= @num1
	BEGIN	
		IF @currentNum % 2 = 0
			PRINT @currentNum
		SET @currentNum = @currentNum + 1
	END;
END;
END;

EXEC PrintEventValue 1, 10;

---
-- Q3
GO
USE Company_SD;
GO
ALTER PROCEDURE CheckNoEmp (@Pno int) 
AS
BEGIN
	DECLARE @EmpCount INT;
	SET @EmpCount = (
	SELECT COUNT(ESSN)
    FROM Works_for
    WHERE Pno = 100);
	PRINT @EmpCount
	IF @EmpCount >= 3
		PRINT 'The number of employees in the project 100 is 3 or more';
	ELSE
	BEGIN
		PRINT 'The following employees work for the project 100';
		SELECT E.Fname, E.Lname
        FROM [Human Resource].Employee E
        INNER JOIN Works_for W
            ON E.SSN = W.ESSN
        WHERE W.Pno = @Pno;
	END;
END;

EXEC CheckNoEmp 700;

-- Q4
GO
use ITI;
GO
CREATE PROCEDURE GetStudentNames (@type VARCHAR(20))
AS
BEGIN
    IF @type = 'first name'
        SELECT ISNULL(S.St_Fname, '') [FirstName]
        FROM Student S
    ELSE IF @type = 'last name'
        SELECT ISNULL(St_Lname, '') [LastName]
        FROM Student;
    ELSE IF @type = 'full name'
        SELECT Isnull(St_Fname, '') + ' ' + Isnull(St_Lname, '') [FullName]
        FROM Student;
END;
-- Q5
-- Q6
GO
USE Company_SD;
GO
create Procedure UpdateEmployeeInProject ( @OldEmp int, @NewEmp int,@ProjNo int)
AS
BEGIN 
    IF NOT EXISTS ( SELECT * FROM Works_for
                WHERE  ESSn = @NewEmp)
        PRINT 'EROR'
ELSE
BEGIN
    Update Works_for
    SET ESSn = @NewEmp
    Where ESSn = @OldEmp
    And Pno = @ProjNo;
End;
-- Q7
ALTER TABLE Project
ADD Budget MONEY;


GO
CREATE TABLE Project_Budget_Audit
(
    ProjectNo      int,
    UserName       VARCHAR(100),
    ModifiedDate   DATETIME,
    Budget_Old     MONEY,
    Budget_New     MONEY
);
GO
CREATE OR ALTER TRIGGER TriggerBudget
ON Project
AFTER UPDATE
AS
BEGIN
	PRINT 'TRIGGER -->';
    INSERT INTO Project_Budget_Audit
    SELECT d.Pnumber,
        SYSTEM_USER,
        GETDATE(),
        d.Budget,
        i.Budget
    FROM deleted d
    INNER JOIN inserted i
        ON d.Pnumber = i.Pnumber
   WHERE ISNULL(d.Budget,0) <> ISNULL(i.Budget,0);
 
END;

UPDATE Project
SET Budget = 2311
WHERE Pnumber = 100;

SELECT * FROM Project_Budget_Audit;

-- Q8
GO
USE ITI;
GO
CREATE TRIGGER Trig_Prevent_Insert
ON Department
INSTEAD OF INSERT
AS 
BEGIN
PRINT 'can’t insert a new record in that table';
END;

INSERT INTO Department(Dept_Id,Dept_Name) Values(90,'amira')
-- 
-- Q9
GO
USE Company_SD;
GO
CREATE TRIGGER Trig_Prevent_Insert_march
ON [Human Resource].Employee
INSTEAD OF INSERT
AS 
BEGIN
	IF MONTH(GETDATE()) = 3
		PRINT 'can’t insert a new record in that table';
	ELSE
		INSERT INTO [Human Resource].Employee
		SELECT * FROM inserted;
END;
-- Q10
GO
USE ITI;
GO
CREATE TABLE Student_Audit
(
	ServerUserName VARCHAR(MAX),
	AuditDate Date,
	Note VARCHAR(MAX)
);
GO
CREATE OR ALTER TRIGGER trig_isert_stud_audit
ON Student
AFTER INSERT 
AS
BEGIN
	INSERT INTO Student_Audit (ServerUserName, AuditDate, Note)
    SELECT 
        SUSER_SNAME(),          
        GETDATE(),           
        CONCAT(SUSER_SNAME() , ' Insert New Row with' 
        , CAST(i.St_Id AS VARCHAR(10)) , ' ID')
    FROM inserted i;
END;

INSERT INTO Student (St_Id,St_Fname,St_Lname) VALUES (0,'amira','nasser')

SELECT * FROM Student_Audit
-- Q11
GO
CREATE TRIGGER trig1
ON STUDENT
INSTEAD OF DELETE
AS
BEGIN

	   INSERT INTO Student_Audit (ServerUserName, AuditDate, Note)
	   SELECT 
        SUSER_SNAME(), 
        GETDATE(),
        CONCAT(SUSER_SNAME() , ' Delte Row with' 
        , CAST(d.St_Id AS VARCHAR(10)) , ' ID')
       FROM deleted d;
END;
------------ 
-- UPDATE 
-- Q5
GO
USE Company_SD;
UPDATE Project
SET Budget = ISNULL(Budget,0)*1.1
FROM [Human Resource].Employee m,[Human Resource].Employee  e
WHERE m.SSN = e.Superssn AND m.SSN = 10102   
--Q6
Update Departments
SET Dname = 'Sales'
WHERE Dnum = ( 
SELECT e.Dno FROM [Human Resource].Employee e 
WHERE e.Fname = 'James')

-- Q7
UPDATE Departments
SET [MGRStart Date] = '2007-12-12'
FROM [Human Resource].Employee e
WHERE e.SSN = (SELECT Pnumber FROM Project
  WHERE Pname = 'p1')
  AND e.Dno = 
  (SELECT Dnum FROM Departments
  WHERE Dname = 'Sales');
-- Q8 REPEAT
DELETE FROM Works_for
WHERE ESSn IN (
    SELECT ESSn FROM Departments , Employee e
    WHERE e. AND Dlocation = 'KW'
);