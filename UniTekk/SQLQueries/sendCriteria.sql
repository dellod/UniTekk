
CREATE PROCEDURE sendCriteria (
@successValue int,
@clientUsername varchar(255),
@price int,
@address varchar(255)
)
AS
BEGIN
	if EXISTS (select * from CRITERIA where client_username = @clientUsername)
		UPDATE Criteria
		SET price = @price, [address] = @address
		Where client_username = @clientUsername
	ELSE
		INSERT INTO Criteria(client_username, product_type,price,[address])
		VALUES(@clientUsername,1,@price,@address)
	SET @successValue = 1
	RETURN @successValue
END
GO
