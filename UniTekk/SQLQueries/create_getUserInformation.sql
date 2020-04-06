create procedure getUserInformation(
@returnVal as int OUTPUT,
@password as varchar(50),
@username as varchar(50)
)
AS

BEGIN
	SET NOCOUNT OFF;
	IF EXISTS (SELECT * FROM Client WHERE Client.username = @username and Client.[password] = @password)
	BEGIN
		--INSERT INTO Client (username, password, address) VALUES ('test3', 'test3', 'test3');
		SET @returnVal = 2;
	END
	ELSE IF EXISTS (SELECT * FROM [Admin] WHERE [Admin].username = @username and [Admin].[password] = @password)
	BEGIN
		SET @returnVal = 1;
	END
	ELSE
	BEGIN
		SET @returnVal = 0;
	END;
	RETURN @returnVal;
END;
