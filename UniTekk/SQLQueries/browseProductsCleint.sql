create procedure browseProductsClient
(
	@username AS varchar(50),
	@password AS varchar(50)
)
AS
BEGIN
	SELECT subquery.[product_name], subquery.[price], subquery.[seller_name], subquery.[type]
	FROM
	(
	SELECT pOne.[name] as product_name, Sells.price, Seller.[name] as seller_name,
		CASE
			WHEN EXISTS (SELECT * FROM Camera where pOne.productID = Camera.productID) THEN 'Camera'
			WHEN EXISTS (SELECT * FROM Laptop where pOne.productID = Laptop.productID) THEN 'Laptop'
			WHEN EXISTS (SELECT * FROM Phone where pOne.productID = Phone.productID) THEN 'Phone'
			WHEN EXISTS (SELECT * FROM TV where pOne.productID = TV.productID) THEN 'TV'
			ELSE 'N/A'
		END AS [type]
		FROM Product AS pOne, Sells, Seller
		WHERE Sells.productID = pOne.productID AND Sells.sellerID = Seller.sellerID AND pOne.productID IN (SELECT sellsTwo.productID FROM Sells AS sellsTwo, Criteria WHERE Criteria.client_username = @username AND Criteria.price <= sellsTwo.price)
	) AS subquery, Criteria
	WHERE Criteria.client_username = @username AND Criteria.product_type = subquery.[type]
END;