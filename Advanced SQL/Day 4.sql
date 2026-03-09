-- Q1.
USE Company_SD;
DECLARE increase_salary_cursor CURSOR
FOR SELECT  SSN , Fname,Salary FROM [Human Resource].Employee
FOR UPDATE;

declare @SSN int
declare @Fname nvarchar(50)
declare @Salary int

OPEN increase_salary_cursor 
FETCH increase_salary_cursor INTO @SSN,@Fname,@Salary
BEGIN
	WHILE @@fetch_status=0
	BEGIN
		IF @Salary<3000
			BEGIN
				UPDATE [Human Resource].Employee 
				SET Salary= @Salary*1.10 
				WHERE CURRENT OF increase_salary_cursor 
				fetch increase_salary_cursor into @SSN,@Fname,@Salary
			END
		ELSE
			BEGIN
				UPDATE [Human Resource].Employee 
				SET Salary= @Salary*1.20 
				WHERE CURRENT OF increase_salary_cursor 
				FETCH increase_salary_cursor INTO @SSN,@Fname,@Salary
			END
	END
END
CLOSE increase_salary_cursor
DEALLOCATE increase_salary_cursor
-----
-- Q2.
USE ITI;
DECLARE display_departmentName_cursor CURSOR
FOR SELECT Dept_Name,Ins_Name FROM Department d, Instructor i
	WHERE d.Dept_Manager = i.Ins_Id
FOR READ ONLY  


DECLARE @departmentName NVARCHAR(50)
DECLARE @InstructorName NVARCHAR(50)
OPEN display_departmentName_cursor 
FETCH display_departmentName_cursor INTO @departmentName,@InstructorName
BEGIN
	WHILE @@fetch_status=0 
	BEGIN
		SELECT @departmentName,@InstructorName 
		FETCH display_departmentName_cursor INTO @departmentName,@InstructorName
	END
END
CLOSE display_departmentName_cursor
DEALLOCATE display_departmentName_cursor
---
-- Q3.Try to display all students first name in one cell separated by comma. Using Cursor 
USE ITI;
DECLARE students_name_cursor CURSOR
FOR SELECT St_Fname FROM Student
FOR READ ONLY

DECLARE @AllNames NVARCHAR(MAX) = ''
DECLARE @FnameS NVARCHAR(50)

OPEN students_name_cursor
FETCH students_name_cursor INTO @FnameS
BEGIN
	WHILE @@fetch_status=0
	BEGIN
		IF LEN(@AllNames) = 0 
			SET @AllNames = @FnameS
		ELSE 
			SET @AllNames = CONCAT(@AllNames,' , ',@FnameS)  
		FETCH students_name_cursor INTO @FnameS
	END;
END;

PRINT @AllNames
CLOSE students_name_cursor
DEALLOCATE students_name_cursor

---
-- Q4.Create full, differential Backup for SD30_Company DB.
-- I Added photo for this task to prove that i did it
-- tasks -> backup and choose the options
-- Q5. 5.	Create Login Named Ahmed and give permission to select and update from tables department , course on ITI
-- look at the photo while i was logging in
USE ITI;
GRANT SELECT, UPDATE ON Department TO misk1; -- username for login name Ahmed
GRANT SELECT, UPDATE ON dbo.course TO misk1;
-- Q6. 
USE AmiraCompany ;
CREATE TABLE DUMMYTABLE (
	EmpID int,
	ProjectID int,
	hours int,
);
INSERT INTO DUMMYTABLE VALUES (
 1,1,10
);

SELECT t.EmpID,t.ProjectID, SUM(hours)
FROM DUMMYTABLE t
GROUP BY ROLLUP(t.EmpID,t.ProjectID)

SELECT t.EmpID,t.ProjectID, SUM(hours)
FROM DUMMYTABLE t
GROUP BY CUBE(t.EmpID,t.ProjectID)

SELECT t.EmpID,t.ProjectID, SUM(hours)
FROM DUMMYTABLE t
GROUP BY GROUPING SETS(t.EmpID,t.ProjectID)
