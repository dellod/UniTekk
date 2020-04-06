
CREATE PROCEDURE sendCriteria (
@successValue as int OUTPUT,
@clientUsername as varchar(255),
@price as int,
@address as varchar(255)
)
AS
BEGIN
	IF EXISTS (select * from CRITERIA where client_username = @clientUsername)
	BEGIN
		UPDATE Criteria
		SET price = @price, [address] = @address
		Where client_username = @clientUsername
	END
	ELSE
	BEGIN
		INSERT INTO Criteria(client_username, product_type,price,[address])
		VALUES(@clientUsername,1,@price,@address)
	END
	SET @successValue = 1
	RETURN @successValue
END;
