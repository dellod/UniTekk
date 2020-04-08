create procedure browseProducts
AS
BEGIN
	SELECT pOne.[name], Sells.price, Seller.[name],
	CASE
		WHEN EXISTS (SELECT * FROM Camera where pOne.productID = Camera.productID) THEN 'Camera'
		WHEN EXISTS (SELECT * FROM Laptop where pOne.productID = Laptop.productID) THEN 'Laptop'
		WHEN EXISTS (SELECT * FROM Phone where pOne.productID = Phone.productID) THEN 'Phone'
		WHEN EXISTS (SELECT * FROM TV where pOne.productID = TV.productID) THEN 'TV'
		ELSE 'N/A'
	END AS Type
	FROM Product AS pOne, Sells, Seller
	WHERE Sells.productID = pOne.productID AND Sells.sellerID = Seller.sellerID
END;