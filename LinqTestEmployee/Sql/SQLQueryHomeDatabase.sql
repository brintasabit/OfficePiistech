DECLARE @count INT;
DECLARE @count1 INT;
DECLARE @count2 INT;
SET @count = 1;
SET @count1 = 21;
SET @count2 = 20000;
WHILE @count<= 100
BEGIN
   INSERT INTO EmployeeInfo2 VALUES(
								'Gorgie'+CAST(@count as varchar),
								'gorgie@go.'+CAST(@count as varchar),
								 CAST(@count1 as varchar),
								 CAST(@count2 as varchar)
								)
   SET @count = @count + 1;
   SET @count1 = @count1 + 1;
   SET @count2 = @count2 + 1;
END;

select * from EmployeeInfo2