--DROP DATABASE cursosdb;

CREATE DATABASE LaceUpDB;

USE LaceUpDB;

CREATE TABLE Orders (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CreateDate date NOT NULL,
    ItemCount int NOT NULL,
	TotalPrice int NOT NULL,
	CustomerName NVARCHAR(100) NOT NULL
);
CREATE TABLE Products (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    IdOrderFK int NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Price int NOT NULL,
	Quantity int NOT NULL,
	Comment NVARCHAR(200) NOT NULL,
    FOREIGN KEY (IdOrderFK) REFERENCES Orders (id)
);
--CREATE TABLE OrderDetails (
--  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
--  OrderNumberFk INT NOT NULL,
--  ProductNumberFk INT NOT NULL
--);