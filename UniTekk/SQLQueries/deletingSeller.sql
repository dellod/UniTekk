create procedure deleteSeller(
@returnValue as int OUTPUT,
@sellerId as int
)

AS 

BEGIN
	DELETE From Sells where sellerID = @sellerId;
	DELETE FROM Seller where sellerID = @sellerId;
	SET @returnValue = 1;
	RETURN @returnValue;
END;