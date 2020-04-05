create procedure getUserInformation(
@returnVal as int,
@password as varchar(50),
@username as varchar(50)
)
AS

BEGIN

	
	SELECT @returnVal=
	CASE 
	WHEN @username = a.username and @password = a.[password] THEN 1 --returns 1 if an admin
	WHEN @username = c.username and @password = c.[password] THEN 2 -- returns 2 if an client
	ELSE 0 --return 0 when verfication failed
	END
	from Admin as a, Client as c
	RETURN @returnVal
END;