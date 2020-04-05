
--FOR RESETTING TABLES WHEN SOMETHING GOES WRONG

--DROP TABLE [dbo].[Admin];
--DROP TABLE [dbo].[Client];
--DROP TABLE [dbo].[Criteria];
--DROP TABLE [dbo].[Brand];
--DROP TABLE [dbo].[Product];
--DROP TABLE [dbo].[Seller];
--DROP TABLE [dbo].[Sells];
--DROP TABLE [dbo].[TV];
--DROP TABLE [dbo].[Camera];
--DROP TABLE [dbo].[Laptop];
--DROP TABLE [dbo].[Phone];

CREATE TABLE [dbo].[Admin]
(
	[username] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [password] VARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[Client]
(
	[username] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [password] VARCHAR(50) NOT NULL, 
    [address] VARCHAR(50) NULL
);

CREATE TABLE [dbo].[Criteria]
(
	[client_username] VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Client(username),
	[product_type] VARCHAR(50) NOT NULL,
	[price] int NULL,
	[address] VARCHAR(50) NULL,
	CONSTRAINT primary_key_criteria PRIMARY KEY (client_username, product_type)
);

CREATE TABLE [dbo].[Brand]
(
	[brandID] int NOT NULL PRIMARY KEY,
	[name] VARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[Product]
(
	[productID] int NOT NULL PRIMARY KEY,
	[name] VARCHAR(50) NOT NULL,
	[brandID] int NOT NULL FOREIGN KEY REFERENCES Brand(brandID),
	[managing_admin_username] VARCHAR(50) NULL REFERENCES Admin(username),
	[browsing_client_username] VARCHAR(50) NULL REFERENCES Client(username)
);

CREATE TABLE [dbo].[Seller]
(
	[sellerID] int NOT NULL PRIMARY KEY,
	[link] VARCHAR(50) NULL,
	[name] VARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[Sells]
(
	[sellerID] int NOT NULL FOREIGN KEY REFERENCES Seller(sellerID),
	[productID] int NOT NULL FOREIGN KEY REFERENCES Product(productID),
	[availability] int NOT NULL,
	[price] int NOT NULL,
	CONSTRAINT primary_key_sells PRIMARY KEY (sellerID, productID)
);

CREATE TABLE [dbo].[TV]
(
	[productID] int NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Product(ProductID),
	[resolution] int NULL,
	[thickness] int NULL,
	[width] int NULL,
	[height] int NULL
);

CREATE TABLE [dbo].[Camera]
(
	[productID] int NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Product(ProductID),
	[aperture] int NULL,
	[shutter_speed] int NULL,
	[thickness] int NULL,
	[width] int NULL,
	[height] int NULL
);

CREATE TABLE [dbo].[Laptop]
(
	[productID] int NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Product(ProductID),
	[RAM] int NULL,
	[clock_frequency] int NULL,
	[thickness] int NULL,
	[width] int NULL,
	[height] int NULL,
);

CREATE TABLE [dbo].[Phone]
(
	[productID] int NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Product(ProductID),
	[thickness] int NULL,
	[width] int NULL,
	[height] int NULL
);