create procedure compareProducts(
@username as varchar(50),
@type as varchar(50),
@productName1 as varchar(50),
@productName2 as varchar(50)
)
AS
BEGIN

	IF @type = 'Laptop'
	BEGIN
		SELECT Product.name, Sells.availability, Sells.price, Laptop.RAM,Laptop.clock_frequency,Laptop.width,Laptop.thickness,Laptop.height
		FROM Product,Laptop,Sells
		WHERE Product.productID = Laptop.productID AND Product.productID = Sells.productID
		AND (Product.name = @productName1 OR Product.name = @productName2);
	END
	ELSE IF @type = 'Camera'
	BEGIN
		SELECT Product.[name], Sells.availability, Sells.price, Camera.Aperture, Camera.shutter_speed, Camera.width, Camera.thickness, Camera.height
		FROM Product, Camera, Sells
		WHERE Product.productID = Camera.productID AND Product.productID = Sells.productID AND (Product.[name] = @productName1 OR Product.[name] = @productName2) 
	END
	ELSE IF @type = 'Phone'
	BEGIN
		SELECT Product.[name], Sells.availability, Sells.price, Phone.thickness, Phone.width, Phone.height
		From Product, Phone, Sells
		WHERE Product.productID = Phone.productID AND Product.productID = Sells.productID AND (Product.[name] = @productName1 OR Product.[name] = @productName2)
	END
	ELSE IF @type = 'TV'
	BEGIN
		SELECT Product.[name], Sells.availability, Sells.price, TV.resolution, TV.width, TV.thickness
		FROM Product, TV, Sells
		WHERE Product.productID = TV.productID AND Product.productID = Sells.productID AND (Product.[name] = @productName1 OR Product.[name] = @productName2)
	END

END;