USE ITI;
-- 1.
SELECT COUNT(ST_Age)
FROM Student;
-- 2.
SELECT DISTINCT Ins_Name
FROM Instructor ;
-- 3.
SELECT  St_Id AS [Student ID], 
	CONCAT(st_fname,' ',St_Lname) AS [Student Full Name],
	d.Dept_Name AS [Department name]
FROM Student s INNER JOIN
Department d 
ON s.Dept_Id = d.Dept_Id;
-- 4.
SELECT s.Ins_Name,
	d.Dept_Name
FROM Department d INNER JOIN Instructor s 
ON d.Dept_Id = s.Dept_Id;
-- 5.
SELECT CONCAT(st_fname,' ',St_Lname) AS [Student Full Name],
	c.Crs_Name
FROM Student s INNER JOIN
Stud_Course sc 
ON s.St_Id = sc.St_Id AND sc.Grade IS NOT NULL
INNER JOIN Course c
ON sc.Crs_Id = c.Crs_Id;
-- 6.
SELECT DISTINCT t.Top_Name,
COUNT(c.Crs_Id) OVER (PARTITION BY t.Top_Name)
FROM Topic t INNER JOIN Course c 
ON t.Top_Id = c.Top_Id;
-- other solution 
SELECT t.Top_Name,COUNT(c.Crs_Id)
FROM Topic t INNER JOIN Course c 
ON t.Top_Id = c.Top_Id
GROUP BY t.Top_Name;
-- 7.
SELECT MAX(salary) AS maxSalary, MIN(salary) AS minSalary
FROM Instructor;
-- 8.
SELECT *
FROM Instructor
WHERE salary < (SELECT AVG(ISNULL(salary,0)) AS avgSalary
FROM Instructor);
-- 9.
SELECT s.Ins_Name,
	d.Dept_Name
FROM Department d INNER JOIN Instructor s 
ON d.Dept_Id = s.Dept_Id
WHERE s.salary = (SELECT MIN(SALARY) FROM Instructor);
-- 10/
SELECT salary
FROM (
SELECT salary,
	ROW_NUMBER() OVER (ORDER BY salary DESC) AS rn
FROM Instructor
) as t
WHERE t.rn IN (1, 2);
-- 11
SELECT 
    Ins_Name,
    COALESCE(CAST(salary AS VARCHAR), 'bonus') AS [salary or bonus]
FROM instructor;
-- 12.
SELECT AVG(salary) 
FROM Instructor;
-- 13.
SELECT m.St_Fname as Supervisor, s.St_Fname as Student
FROM Student m INNER JOIN  Student s
ON m.St_Id = s.St_super;
-- 14.  
SELECT *
FROM (
SELECT Dept_Id, salary,
	RANK() OVER (PARTITION BY Dept_Id ORDER BY salary DESC) AS rn
FROM Instructor
) as t
WHERE t.rn IN (1, 2);
-- 15.
SELECT Dept_Id,St_Fname,St_Id
FROM (
    SELECT 
        Dept_Id,
        St_Id,
        St_Fname,
        RANK() OVER (
            PARTITION BY Dept_Id 
            ORDER BY NEWID()
        ) AS rn
    FROM Student 
) AS t
WHERE rn = 1;

------------------------------------------------
-- Part-2: 
USE AdventureWorks2012;
-- 1.
SELECT SalesOrderID, ShipDate
FROM Sales.SalesOrderHeader
WHERE ShipDate BETWEEN '2002-07-28' AND '2014-07-29';
-- 2.
SELECT ProductID, Name
FROM Production.Product
WHERE StandardCost < 110.00;
-- 3.
SELECT ProductID, Name
FROM Production.Product
WHERE Weight IS NULL;
-- 4.
SELECT ProductID, Name,Color
FROM Production.Product
WHERE Color IN ('RED','black','Silver');
-- 5.
SELECT ProductID, Name
FROM Production.Product
WHERE LEFT(NAME,1) = 'b';
-- 6.
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

SELECT ProductDescriptionID, Description
FROM Production.ProductDescription
WHERE Description LIKE '%[_]%';

-- 7.
SELECT OrderDate,
SUM(TotalDue) OVER (PARTITION BY OrderDate) As [total]
FROM Sales.SalesOrderHeader 
WHERE OrderDate BETWEEN '2001-07-01' AND '2014-07-31';
-- 8. 
SELECT DISTINCT HireDate
FROM HumanResources.Employee
ORDER BY HireDate;
-- 9. 
SELECT AVG(DISTINCT ListPrice) AS AvgUniqueListPrice
FROM Production.Product;
-- 10.
SELECT 
    CONCAT('The ' , Name , ' is only! ' , ListPrice) AS ProductInfo
FROM  Production.Product
WHERE ListPrice BETWEEN 100 AND 120
ORDER BY ListPrice;
-- 11. 
CREATE TABLE store_Archive ( 
rowguid UNIQUEIDENTIFIER, 
Name NVARCHAR(100), 
SalesPersonID INT, 
Demographics XML 
);

INSERT INTO store_Archive (
rowguid,
Name, 
SalesPersonID, 
Demographics
) 
SELECT rowguid, 
    Name, 
    SalesPersonID, 
    Demographics 
FROM Sales.Store;

SELECT COUNT(*) 
FROM store_Archive;

SELECT COUNT(*)
FROM Sales.Store;
-- 12.



