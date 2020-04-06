/*
DECLARE @returnVal as int;

SELECT @returnVal=
	CASE 
	WHEN 'hello' = a.username and 'world' = a.[password] THEN 1 --returns 1 if an admin
	WHEN 'hello' = c.username and 'world' = c.[password] THEN 2 -- returns 2 if an client
	ELSE 0 --return 0 when verfication failed
	END
	FROM Admin as a, Client as c;

--SET @returnVal = 1;

IF EXISTS (SELECT * FROM Client WHERE Client.username = 'hello' and Client.password = 'world')
BEGIN
	SET @returnVal = 2;
END
ELSE IF EXISTS (SELECT * FROM Admin WHERE Admin.username = 'MrMonopoly' and Admin.password = 'money')
BEGIN
	SET @returnVal = 1;
END
ELSE
BEGIN
	SET @returnVal = 0;
END;


PRINT @returnVal;

--SELECT * FROM Client;

*/
INSERT INTO Client (username, password, address) 
VALUES ('hello', 'world', '1234 Hello World Street'), 
('DoubloonDan', 'iamapirate', '73 Millhouses Money Man-of-War'),
('etsuko_yakushimaru', 'stsr', '3214 Peppermint Avenue');
