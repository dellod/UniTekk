USE [Unitekk]
GO
/****** Object:  StoredProcedure [dbo].[insertNewProduct]    Script Date: 2020-04-08 12:38:21 PM ******/

CREATE procedure deleteProduct(
@returnVal as int OUTPUT,
@productId as int
)
AS

BEGIN
	DELETE from Sells where Sells.productID = @productId;
	DELETE from Laptop where Laptop.productID = @productId;
	DELETE from Camera where Camera.productID = @productId;
	DELETE from Phone where Phone.productID = @productId;
	DELETE from TV where TV.productID = @productId;
	DELETE from Product where Product.productID = @productId;
	set @returnVal = 1;
	RETURN @returnVal
END;