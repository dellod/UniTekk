create procedure insertBrand(
@returnValue as int OUTPUT,
@username as varchar(50),
@sellerName as varchar(50),
@link as varchar(50),
@productName as varchar(50),
@availability as int,
@price as int
)

AS

BEGIN
	DECLARE @sellerId as int;
	DECLARE @productId as int;
	SELECT @productId = productID FROM Product where name = @productName and brandID = @sellerId and managing_admin_username = @username;
	INSERT INTO Seller(link, name) VALUES (@link, @sellerName);
	SELECT @sellerId = sellerID FROM Seller WHERE link = @link and NAME = @sellerName;
	INSERT INTO Sells(sellerID, productID, availability, price) VALUES (@sellerId, @productId, @availability, @price);
	SET @returnValue = 1;
	RETURN @returnValue;
END;