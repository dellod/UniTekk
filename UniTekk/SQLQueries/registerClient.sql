CREATE PROCEDURE registerClient (
@returnValue as int OUTPUT,
@username as varchar(255),
@password as int,
@address as varchar(255)
)
AS
BEGIN
	IF EXISTS (SELECT * FROM Client WHERE Client.username = @username)
	BEGIN
		SET @returnValue = 0; 
	END
	ELSE IF LEN(@password) < 8
	BEGIN
		SET @returnValue = 0;
	END
	ELSE
	BEGIN
		INSERT INTO Client (username, password, address) VALUES (@username, @password, @address);
		SET @returnValue = 1;
	END;
	RETURN @returnValue;
END;