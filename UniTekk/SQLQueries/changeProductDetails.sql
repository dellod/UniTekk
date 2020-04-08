create procedure changeProductDetails(
@returnValue as int OUTPUT,
@type as varchar(50),
@username as varchar(50),
@productId as int,
@productName as varchar(50),
@price as int,
@availability as int
)
AS
BEGIN
	IF @type = 'name'
	BEGIN
		UPDATE Product
		SET name = @productName
		WHERE @productId = Product.productID
	END
	ELSE IF @type = 'price'
	BEGIN
		UPDATE Sells
		SET Sells.price = @price
		WHERE @productId = Sells.productID
	END
	ELSE IF @type = 'availability'
	BEGIN
		UPDATE Sells
		SET Sells.availability = @availability
		WHERE @productId = Sells.productID
	END
	SET @returnValue = 1;
	RETURN @returnValue;
END;