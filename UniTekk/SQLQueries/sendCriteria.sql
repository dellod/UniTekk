
CREATE PROCEDURE sendCriteria (
@successValue int,
@clientUsername varchar(255),
@price int,
@address varchar(255),
@type varchar(255)
)
AS
BEGIN
	if EXISTS (select * from CRITERIA where client_username = @clientUsername)
		UPDATE Criteria
		SET price = @price, [address] = @address, product_type = @type
		Where client_username = @clientUsername
	ELSE
		INSERT INTO Criteria(client_username, product_type,price,[address])
		VALUES(@clientUsername,@type,@price,@address)
	SET @successValue = 1
	RETURN @successValue
END
GO
