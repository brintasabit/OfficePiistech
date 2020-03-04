DECLARE @count INT;
DECLARE @count1 INT;
DECLARE @count2 INT;
DECLARE @count3 INT;
SET @count = 1;
SET @count1 = 23; 
SET @count2 = 1000;
SET @count3 = 84;
WHILE @count<= 13
BEGIN
   INSERT INTO EmployeeInfo5 VALUES('Paggy'+CAST(@count as varchar), 'Parker'+CAST(@count as varchar),CAST(@count2 as varchar),CAST(@count3 as varchar),CAST(@count1 as varchar))
   SET @count = @count + 1;
   SET @count1 = @count1 + 1;
   SET @count2 = @count2 + 1;
   SET @count3 = @count3 + 1;
END;

Select * from EmployeeInfo5

DECLARE @count INT;
SET @count = 1;
    
WHILE @count<= 10
BEGIN
   INSERT INTO EmployeeInfo VALUES('Car-'+CAST(@count as varchar), @count*100)
   SET @count = @count + 1;
END;



UPDATE EmployeeInfo5
SET LastName = 'Paggy12'
WHERE EmpId=12