CREATE DATABASE Parcial02
GO

USE Parcial02
GO

CREATE TABLE Productos(
Id INT PRIMARY KEY NOT NULL,
Nombre VARCHAR(100) NOT NULL,
Descripcion VARCHAR(100) NOT NULL,
Precio DECIMAL(10,2) NOT NULL,
Stock INT NOT NULL,
Marca VARCHAR(50) NOT NULL,
Categoria VARCHAR(50) NOT NULL
);
GO

INSERT INTO Productos (Id, Nombre, Descripcion, Precio, Stock, Marca, Categoria)
VALUES 
(1, 'Laptop', 'Laptop con pantalla de 15.6 pulgadas y procesador Intel i7', 1500.00, 20, 'HP', 'Computadoras'),
(2, 'Smartphone', 'Smartphone con pantalla AMOLED de 6.4 pulgadas y 128GB de almacenamiento', 899.99, 50, 'OnePlus', 'Teléfonos'),
(3, 'Tablet', 'Tablet de 10.5 pulgadas con soporte para lápiz óptico', 600.00, 35, 'Apple', 'Tabletas'),
(4, 'Auriculares', 'Auriculares inalámbricos con cancelación de ruido activa', 299.99, 100, 'Sony', 'Audio'),
(5, 'Smartwatch', 'Reloj inteligente con monitor de frecuencia cardíaca y GPS', 250.00, 45, 'Garmin', 'Wearables');
GO

SELECT * FROM Productos
