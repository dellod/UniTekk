create procedure deleteSeller(
@returnValue as int OUTPUT,
@sellerId as int
)

AS 

BEGIN
	DELETE FROM Seller where sellerID = @sellerId;
	DELETE From Sells where sellerID = @sellerId;
	SET @returnValue = 1;
	RETURN @returnValue;
END;