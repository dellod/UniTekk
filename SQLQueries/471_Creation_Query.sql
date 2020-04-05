
-- 1) The statement below will create the Database named Unitekk,
--    highlight the following statement below and execute or press F5

CREATE DATABASE Unitekk;


-- 2) Switch your branch from master to Unitekk (It should be the drop-down menu to the left to the execute button) 
--   The following tables do not have any pre-existing tables and can be created first (highlight and press F5)

CREATE TABLE Client (
    username varchar(255) PRIMARY KEY,
    password varchar(255) NOT NULL,
    address varchar(255)
); 

CREATE TABLE [Admin] (
    username varchar(255) PRIMARY KEY,
    [password] varchar(255) NOT NULL,
    [address] varchar(255)
); 

CREATE TABLE Seller (
    sellerID int IDENTITY(1,1) PRIMARY KEY,
    link varchar(255) NOT NULL,
    [name] varchar(255) NOT NULL
); 

-- 3) The following tables all have references to pre-existing tables(highlight and press F5 after required tables created, see step 1)

CREATE TABLE Product (
	productID int IDENTITY(1,1) PRIMARY KEY,
	[name] varchar(255) NOT NULL,
	brandID int NOT NULL,
	[managing_admin_username] varchar(255) NOT NULL,
	[browsing_client_username] varchar(255)
	FOREIGN KEY ([browsing_client_username]) REFERENCES Client(username),
	FOREIGN KEY ([managing_admin_username]) REFERENCES [Admin](username)
);

CREATE TABLE Criteria (
	client_username varchar(255) NOT NULL,
	product_type varchar(255) PRIMARY KEY,
	price int,
	[address] varchar(255) NOT NULL,
	FOREIGN KEY (client_username) REFERENCES Client(username)
);

CREATE TABLE Sells (
	sellerID int NOT NULL,
	productID int NOT NULL,
	[availability] BIT NOT NULL,
	price int NOT NULL,
	FOREIGN KEY (sellerID) REFERENCES [Seller](sellerID),
	FOREIGN KEY (productID) REFERENCES Product(productID)
);

CREATE TABLE TV ( 
	productID int NOT NULL,
	resolution varchar(255),
	width varchar(255),
	thickness varchar(255),
	height varchar(255),
	FOREIGN KEY (productID) REFERENCES Product(productID)
);

CREATE TABLE Camera(
	productID int NOT NULL,
	Aperture varchar(255),
	shutter_speed int NOT NULL,
	width varchar(255),
	thickness varchar(255),
	height varchar(255)
	FOREIGN KEY (productID) REFERENCES Product(productID)
);

CREATE TABLE Laptop(
	productID int NOT NULL,
	RAM int,
	clock_frequency int NOT NULL,
	width varchar(255),
	thickness varchar(255),
	height varchar(255)
	FOREIGN KEY (productID) REFERENCES Product(productID)
);

CREATE TABLE Phone(
	productID int NOT NULL,
	width varchar(255),
	thickness varchar(255),
	height varchar(255)
	FOREIGN KEY (productID) REFERENCES Product(productID)
);