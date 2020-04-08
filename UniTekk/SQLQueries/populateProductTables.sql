INSERT INTO Product (name , managing_admin_username) 
VALUES ('Macbook Pro', 'MrMonopoly'),
	   ('Canon EOS Rebel SL3', 'MrMonopoly'),
	   ('Samsung 55" 4K TV', 'MrMonopoly'),
	   ('IPhone 11', 'MrMonopoly'),
	   ('ASUS Chromebook', 'MrMonopoly');

INSERT INTO Seller (link, name)
VALUES ('https://www.apple.com/', 'Apple'),
	   ('https://www.bestbuy.ca/', 'BestBuy'),
	   ('https://www.canon.ca/', 'Canon');

INSERT INTO Sells (sellerID, productID, availability, price)
VALUES (1, 1, 1, 1699),
	   (1, 4, 1, 949),
	   (2, 3, 1, 600),
	   (2, 5, 1, 549),
	   (2, 4, 1, 980),
	   (3, 2, 1, 900);

INSERT INTO Laptop (productID, RAM, clock_frequency, width, thickness, height)
VALUES ('1', 'UNKNOWN', '1.4GHz', '406.4mm', 'UNKNOWN', 'UNKNOWN'),
	   ('5', '4GB', '1.1GHz', '355.6mm', 'UNKNOWN', 'UNKNOWN');

INSERT INTO Phone (productID, width, thickness, height)
VALUES ('4', '75.7mm', '150.99mm', '8.3mm');

INSERT INTO TV (productID, resolution, width, thickness, height)
VALUES ('3', '3840x2160', '1238.6mm', '261.3mm', '792.8mm');

INSERT INTO Camera (productID, Aperture, shutter_speed, width, thickness, height)
VALUES ('2', 'UNKNOWN', 'UNKNOWN', '62.4mm', 'UNKNOWN', '41.6mm');