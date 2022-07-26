CREATE DATABASE TP_04;
GO
USE TP_04;
GO
CREATE TABLE Datos_Clientes
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	apellido VARCHAR(50) NOT NULL,
	dni bigint NOT NULL,
	celular varchar(50) NOT NULL,
	mail varchar(50) NOT NULL
);
GO
INSERT INTO Datos_Clientes (nombre, apellido, dni, celular, mail) VALUES
	('franco', 'Buonfrate', 44158408, 1161679998, 'francobuonfrate@gmail.com'),
	('Alejandro', 'Magno', 4215344, 1100000001, 'alejandroMagno@gmail.com'),
	('Cristian', 'gray', 36406111, 1137219471, 'cristiangray@gmail.com'),
	('Liones', 'Messi', 38909032, 1151417834, 'aguanteLaEscalo@gmail.com'),
	('Susana', 'gimenez', 23091244, 1171530753, 'susanagimenez@gmail.com'),
	('Brandom', 'sanderson', 34895367, 1178432938, 'brandonSiempre@gmail.com'),
	('Frida', 'Kahlo', 23349890, 1110101212, 'fridakahlo@gmail.com');
