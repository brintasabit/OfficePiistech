DECLARE @count INT;
SET @count = 1;
    
WHILE @count<= 30000
BEGIN
   INSERT INTO EmployeeInfo VALUES('Carlos-'+CAST(@count as varchar), 'Carlos@hb.'+CAST(@count as varchar))
   SET @count = @count + 1;
END;

Select * from EmployeeInfo

DECLARE @count INT;
SET @count = 1;
    
WHILE @count<= 10
BEGIN
   INSERT INTO EmployeeInfo VALUES('Car-'+CAST(@count as varchar), @count*100)
   SET @count = @count + 1;
END;