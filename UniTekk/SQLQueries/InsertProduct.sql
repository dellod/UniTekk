create procedure insertNewProduct(
@returnVal as int OUTPUT,
@username as varchar(50),
@sellerName as varchar(50),
@link as varchar(50),
@availability as int,
@price as int,
@productName as varchar(50),
@type as varchar(50),
@attr1 as varchar(50),
@attr2 as varchar(50),
@attr3 as varchar(50),
@attr4 as varchar(50),
@attr5 as varchar(50)
)
AS

BEGIN
	DECLARE @sellerId as int;
	DECLARE @productId as int;
	SELECT @sellerId = sellerID FROM Seller WHERE link = @link and NAME = @sellerName;
	INSERT INTO Product(name,managing_admin_username) VALUES(@productName,@username);
	SELECT @productId = productId from Product where name = @productName  and managing_admin_username = @username;
	INSERT INTO Sells(sellerID,productID,availability,price) VALUES(@sellerId,@productId,@availability,@price);
	IF @type = 'Laptop'
	BEGIN
		INSERT INTO Laptop(productID,RAM,clock_frequency,height,width,thickness) VALUES(@productId,@attr1,@attr2,@attr3,@attr4,@attr5);
	END
	ELSE IF @type = 'Camera'
	BEGIN
		INSERT INTO Camera(productID,Aperture,shutter_speed,height,width,thickness) VALUES(@productId,@attr1,@attr2,@attr3,@attr4,@attr5);
	END
	ELSE IF @type = 'Phone'
	BEGIN
		INSERT INTO Phone(productID,height,width,thickness) VALUES(@productId,@attr1,@attr2,@attr3);
	END
	ELSE IF @type = 'TV'
	BEGIN
		INSERT INTO TV(productID,resolution,height,width,thickness) VALUES(@productId,@attr1,@attr2,@attr3,@attr4);
	END
	SET @returnVal = 1;
	RETURN @returnVal
END;