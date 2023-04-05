--==PROCEDIMIENTOS PARA PROVEEDOR =======

---====LISTAR PROVEEDOR====
CREATE OR ALTER PROCEDURE spListarProveedor
AS
BEGIN
	select p.idProveedor, p.razonSocial, p.dni, p.correo, p.telefono, p.descripcion, p.estProveedor,
	u.departamento,u.provincia, u.distrito from  PROVEEDOR p 
	inner join ubigeo u on p.idUbigeo = u.idUbigeo
	where p.estProveedor=1
END
GO
--=== BUSCAR PROVEEDOR======
CREATE OR ALTER PROCEDURE spBuscarProveedor(
	@Campo varchar(40)
)
AS
BEGIN
	Select p.idProveedor, p.razonSocial, p.dni, p.correo, p.telefono, p.descripcion, p.estProveedor,
	u.departamento,u.provincia, u.distrito from PROVEEDOR p 
	inner join ubigeo u on p.idUbigeo = u.idUbigeo
	where razonSocial like @Campo+'%'
	or dni like @Campo+'%'	
END
GO

CREATE OR ALTER PROCEDURE spBuscarIdProveedor(
	@idProveedor int
)
AS
BEGIN
	Select p.idProveedor, p.razonSocial, p.dni, p.correo, p.telefono, p.descripcion, p.estProveedor,
	u.departamento,u.provincia, u.distrito from PROVEEDOR p 
	inner join ubigeo u on p.idUbigeo = u.idUbigeo
	where idProveedor= @idProveedor;
	
END
GO

--======EDITAR PROVEEDOR ========

CREATE OR ALTER PROCEDURE spActualizarProveedor(
	@idProveedor int,	
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
	update PROVEEDOR set razonSocial = @razonSocial, dni = @dni, correo = @correo,
	telefono = @telefono, descripcion = @descripcion, estProveedor = @estProveedor, idUbigeo = @idUbigeo
	where idProveedor = @idProveedor;
END
GO

----==== ELIMINAR PROVEEDOR=== 

CREATE OR ALTER PROCEDURE spEliminarProveedor(@idProveedor int)
AS
BEGIN
    delete PROVEEDOR_PRODUCTO where @idProveedor=@idProveedor;
	delete PROVEEDOR where idProveedor = @idProveedor;
END
GO