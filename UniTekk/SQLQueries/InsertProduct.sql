create procedure insertNewProduct(
@returnVal as int OUTPUT,
@username as varchar(50),
@sellerName as varchar(50),
@link as varchar(50),
@availability as int,
@price as int,
@productName as varchar(50)
)
AS

BEGIN
	DECLARE @sellerId as int;
	DECLARE @productId as int;
	INSERT INTO Seller(link,name) VALUES(@link,@sellerName);
	SELECT @sellerId = sellerID FROM Seller WHERE link = @link and NAME = @sellerName;
	INSERT INTO Product(name,brandID,managing_admin_username) VALUES(@productName,@sellerId,@username);
	SELECT @productId = productId from Product where name = @productName and brandID = @sellerId and managing_admin_username = @username;
	INSERT INTO Sells(sellerID,productID,availability,price) VALUES(@productId,@sellerId,@availability,@price);
	SET @returnVal = 1;
	RETURN @returnVal
END;