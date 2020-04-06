create procedure getUserInformation(
@returnVal as int,
@password as varchar(50),
@username as varchar(50)
)
AS

BEGIN
	SET NOCOUNT OFF;
	DECLARE @returnValue as int;
	SET @returnValue = 0;
	IF EXISTS (SELECT * FROM Client WHERE Client.username = 'hello' and Client.password = 'world')
	BEGIN
		SET @returnValue = 2;
	END
	ELSE IF EXISTS (SELECT * FROM [Admin] WHERE [Admin].username = 'MrMonopoly' and [Admin].password = 'money')
	BEGIN
		SET @returnValue = 1;
	END
	ELSE
	BEGIN
		SET @returnValue = 0;
	END;
	RETURN @returnValue;
END;
