--============CREAR PROVEEDOR=================
CREATE OR ALTER PROCEDURE spCrearProveedor
(
	@razonSocial varchar(40),
	@dni varchar(8),
	@correo varchar(40),
	@telefono varchar(9),
	@descripcion varchar (80),
	@estProveedor bit,
	@idUbigeo VARCHAR(6) null
)
AS
BEGIN
	INSERT INTO PROVEEDOR values (@razonSocial, @dni, @correo, @telefono, @descripcion, @estProveedor, @idUbigeo);
END
GO

--=====PROCEDIMIENTOS PARA PROVEEDOR_PRODUCTO================
CREATE OR ALTER PROCEDURE spCrearDetalleProveedor
(
	@idProveedor int,
	@idProducto int,
	@precioCompra float
)
AS
BEGIN
	INSERT INTO PROVEEDOR_PRODUCTO VALUES (@idProveedor,@idProducto,@precioCompra);
END
GO

