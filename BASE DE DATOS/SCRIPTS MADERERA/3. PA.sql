-----------------PROCEDIMIENTOS ALAMCENADOS 
USE BD_PRUEBAS_MADERERA
GO

--====PROCEDIMIENTOS PARA EL SISTEMA =============
---===== PROCEDIMINETOS PARA USUARIO===========
----===INICIAR SESION========
CREATE OR ALTER PROCEDURE spIniciarSesion(@dato varchar(40), @contra varchar(200))
AS
BEGIN
	SELECT u.idUsuario,u.razonSocial,u.telefono,u.direccion,u.correo,u.userName,u.pass,u.idRol,u.activo, ub.distrito from USUARIO u
	left JOIN UBIGEO ub on u.idUbigeo = ub.idUbigeo
	where (userName = @dato or correo = @dato) and pass = @contra
END
GO
--====CREAL USUARIO===========
CREATE OR ALTER PROCEDURE spCrearCliente(
    @razonSocial varchar(40),
	@correo varchar(40),
	@userName varchar(20),
	@pass varchar(200),
	@idRol int
)
AS
BEGIN
    INSERT INTO USUARIO (razonSocial,correo,userName,pass, idRol) values (@razonSocial, @correo, @userName, @pass, @idRol);
END
GO


--===LISTAR USUARIO==
CREATE OR ALTER PROCEDURE spListarClientes
AS
BEGIN
	select c.idUsuario,c.razonSocial,c.telefono, c.correo,c.userName,c.pass,c.direccion, u.provincia,c.activo from USUARIO C 
	left join UBIGEO u on c.idUbigeo=u.idUbigeo
	where c.idRol=2
	order by c.activo desc;
	
END
GO
CREATE OR ALTER PROCEDURE spActualizarCliente(
	@idUsuario int,
	@razonSocial varchar(40),
	@userName varchar(40),
	@Activo bit
)
AS
BEGIN
	update USUARIO set razonSocial = @razonSocial,userName=@userName,activo=@Activo
	where idUsuario=@idUsuario;
END
GO
CREATE OR ALTER PROCEDURE spListarAdministradores
AS
BEGIN
	select c.idUsuario,c.razonSocial,c.telefono, c.correo,c.userName,c.pass,c.direccion, u.provincia,c.activo from USUARIO C 
	left join UBIGEO u on c.idUbigeo=u.idUbigeo
	where c.idRol=1
	order by c.activo desc;
END
GO



---===eliminar usuario===========
CREATE OR ALTER PROCEDURE spEliminarUsuarios(
	@idusuario int
)
AS
BEGIN
	delete USUARIO where idUsuario = @idusuario;
END
GO
--====buscar cleiente ===

CREATE OR ALTER PROCEDURE spBuscarClientes(
	@Campo varchar(40)
)
AS
BEGIN
	select c.idUsuario,c.razonSocial,c.telefono, c.correo,c.userName,c.pass,c.direccion, u.provincia,c.activo from USUARIO C 
	left join UBIGEO u on c.idUbigeo=u.idUbigeo
	where c.razonSocial like @Campo+'%'
	or c.userName like @Campo+'%' or c.correo like @Campo+'%' 
	AND c.idRol=2;
	
END
GO

CREATE OR ALTER PROCEDURE spBuscarAdministradores(@campo varchar(40))
as
begin
	select c.idUsuario,c.razonSocial,c.telefono, c.correo,c.userName,c.pass,c.direccion, u.provincia,c.activo from USUARIO C 
	left join UBIGEO u on c.idUbigeo=u.idUbigeo
	where c.razonSocial like @Campo+'%'
	or c.userName like @Campo+'%' or c.correo like @Campo+'%'
	and C.idRol=1;
end
go

--====ACTUALIZAR USUARIO====== --falta ubigeo
CREATE OR ALTER PROCEDURE spActualizarAdministrador( 
	@idUsuario int,
	@razonSocial varchar(40),
	@userName varchar(20),
	@telefono varchar(9),
	@direccion varchar (60),
	@idUbigeo varchar(10),
	@activo bit
)
AS
BEGIN
	UPDATE USUARIO set razonSocial = @razonSocial, userName = @userName,
	telefono = @telefono, direccion = @direccion,idUbigeo=@idUbigeo,activo = @activo 
	where idUsuario = @idUsuario;

END
GO

--====buscar USUARIO por id======
CREATE OR ALTER PROCEDURE spBuscarIdUsuario(
	@IdUsuario int
)
AS
BEGIN
	select u.idUsuario,u.razonSocial,u.telefono, u.correo,u.userName,u.pass,u.direccion,u.activo ,r.descripcion,ub.departamento,ub.provincia,ub.distrito from USUARIO u
	inner join ROL r on u.idRol=r.idRol
	inner join UBIGEO ub on u.idUbigeo=ub.idUbigeo
	where idUSUARIO = @IdUsuario;
	
END
GO

--===PROCEDIMIENTOS PARA UBIGEO======

---===LISTAR DISTRITOS====
CREATE OR ALTER PROCEDURE sp_ListaDistrito
As
BEGIN
    Select idUbigeo, distrito from Ubigeo where departamento='La Libertad' or departamento = 'Lima'
	order by distrito;
END
GO


CREATE OR ALTER PROCEDURE sp_ListaDistrito1(@idUbigeo int)
As
BEGIN
    select idUbigeo,distrito from ubigeo where idUbigeo=@idUbigeo
	union all
    Select idUbigeo, distrito from Ubigeo where departamento='La Libertad' or departamento = 'Lima'

END
GO


--======LISTA DEPARTAMENTO===========
CREATE OR ALTER PROCEDURE sp_ListaDepartamento
AS
BEGIN
    Select  distinct (Departamento) from Ubigeo;
END
GO

--=====LISTA PROVINCIA=========
CREATE OR ALTER PROCEDURE sp_ListaProvincia(@departamento varchar(32))
As
BEGIN
    Select distinct(Provincia) from Ubigeo
    where Departamento = @departamento;
END
GO

--==PROCEDIMIENTOS PARA PROVEEDOR =======

--============CREAR PROVEEDOR=================
CREATE OR ALTER PROCEDURE spCrearProveedor
(
	@razonSocial varchar(40),
	@ruc varchar(11),
	@correo varchar(40),
	@telefono varchar(9),
	@descripcion varchar (80),
	@estProveedor bit,
	@idUbigeo VARCHAR(6) null
)
AS
BEGIN
	INSERT INTO PROVEEDOR values (@razonSocial, @ruc, @correo, @telefono, @descripcion, @estProveedor, @idUbigeo);
END
GO

--=====PROCEDIMIENTOS PARA PROVEEDOR_PRODUCTO================


---====LISTAR PROVEEDOR====
CREATE OR ALTER PROCEDURE spListarProveedor
AS
BEGIN
	select p.idProveedor, p.razonSocial, p.ruc, p.correo, p.telefono, p.descripcion, p.estProveedor,
	u.departamento,u.provincia, u.distrito from  PROVEEDOR p 
	inner join ubigeo u on p.idUbigeo = u.idUbigeo
	order by estProveedor desc;
END
GO

CREATE OR ALTER PROCEDURE spSelectListProveedordat(@idpr int)
As
BEGIN
    select idProveedor,razonSocial,descripcion from PROVEEDOR where idProveedor=@idpr and estProveedor=1
	union all
   select idProveedor,razonSocial,descripcion from PROVEEDOR where estProveedor=1
END
GO

--CREATE OR ALTER PROCEDURE spSelectListProveedor
--AS
--BEGIN
--	select idProveedor,razonSocial,descripcion from PROVEEDOR 
--END
--GO
--=== BUSCAR PROVEEDOR======
CREATE OR ALTER PROCEDURE spBuscarProveedor(
	@Campo varchar(40)
)
AS
BEGIN
	Select p.idProveedor, p.razonSocial, p.ruc, p.correo, p.telefono, p.descripcion, p.estProveedor,
	u.departamento,u.provincia, u.distrito from PROVEEDOR p 
	inner join ubigeo u on p.idUbigeo = u.idUbigeo
	where razonSocial like @Campo+'%'
	or ruc like @Campo+'%'	
END
GO

CREATE OR ALTER PROCEDURE spBuscarIdProveedor(
	@idProveedor int
)
AS
BEGIN
	Select p.idProveedor, p.razonSocial, p.ruc, p.correo, p.telefono, p.descripcion, p.estProveedor,
	u.departamento,u.provincia, u.distrito from PROVEEDOR p 
	inner join ubigeo u on p.idUbigeo = u.idUbigeo
	where idProveedor= @idProveedor;
	
END
GO

--======EDITAR PROVEEDOR ========

CREATE OR ALTER PROCEDURE spActualizarProveedor(
	@idProveedor int,	
	@razonSocial varchar(40),
	@ruc varchar(11),
	@correo varchar(40),
	@telefono varchar(9),
	@descripcion varchar (80),
	@estProveedor bit,
	@idUbigeo VARCHAR(6) null
)
AS
BEGIN
	update PROVEEDOR set razonSocial = @razonSocial, ruc = @ruc, correo = @correo,
	telefono = @telefono, descripcion = @descripcion, estProveedor = @estProveedor, idUbigeo = @idUbigeo
	where idProveedor = @idProveedor;

END
GO

----==== ELIMINAR PROVEEDOR=== 

CREATE OR ALTER PROCEDURE spEliminarProveedor(@idProveedor int)
AS
BEGIN
    delete PROVEEDOR_PRODUCTO where idProveedor=@idProveedor;
	delete PROVEEDOR where idProveedor = @idProveedor;
END
GO

CREATE Or ALTER PROCEDURE spCrearProveedorProducto(@idProveedor int,@idProducto int,@precioCompra float)
AS
BEGIN
	INSERT INTO PROVEEDOR_PRODUCTO values (@idproveedor,@idproducto,@precioCompra)
END
GO

---===MOSTRAR DETALLE =================
CREATE OR ALTER PROCEDURE spMostrarDetalleProveedorId
 (
 @idProveedor int
 )
 AS
 BEGIN
 SELECT prov.idProveedor, prov.razonSocial,prov.descripcion,p.idproducto,prod.nombre,prod.longitud,prod.stock,p.precioCompra
 FROM PROVEEDOR PROV INNER JOIN PROVEEDOR_PRODUCTO P ON PROV.idProveedor=P.idProveedor
 inner join PRODUCTO prod on p.idproducto=prod.idProducto
 where p.idProveedor=@idProveedor
 END
 GO
CREATE OR ALTER PROCEDURE spEliminarDetalleProveedor(@idproveedor int,@idproducto int)
 AS
 BEGIN
	Delete from PROVEEDOR_PRODUCTO 
	WHERE idProveedor=@idproveedor and idProducto=@idproducto 
	update producto set activo=0 where idproducto=@idproducto and @idproveedor=null;
 END
 GO

 
------------------------------------PRODUCTO
CREATE OR ALTER PROCEDURE spCrearProducto(
    @id int out,
	@nombre varchar(40),
	@longitud float,
	@diametro float,
	@precioVenta float,
	@idTipo_Producto int
)
AS
BEGIN TRY
	begin transaction
		INSERT INTO PRODUCTO(nombre,longitud,diametro,precioVenta,idTipo_Producto) values (@nombre, @longitud,@diametro,@precioVenta, @idTipo_Producto);
		set @id=@@IDENTITY
	commit transaction
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	Set @id=-1;
END CATCH
GO

CREATE OR ALTER PROCEDURE spListarProducto
AS
BEGIN
	SELECT p.idProducto, p.nombre, tp.nombre AS tipo ,p.longitud, p.diametro, pr.razonSocial,  p.stock, pp.precioCompra, p.precioVenta,p.Activo
	from producto p left join PROVEEDOR_PRODUCTO pp on p.idProducto=pp.idProducto
    left join PROVEEDOR pr on pp.idProveedor=pr.idProveedor
    inner join TIPO_PRODUCTO tp on p.idTipo_Producto=tp.idTipo_Producto 
	order by p.Activo desc,p.idProducto
END
GO

CREATE OR ALTER PROCEDURE spBuscarProductoid(@prmintidProducto int)
AS
BEGIN
SELECT p.idProducto, p.nombre, tp.nombre AS tipo,tp.idTipo_Producto ,p.longitud, p.diametro, pr.razonSocial,pr.idProveedor,  p.stock, pp.precioCompra, p.precioVenta,p.Activo
	from producto p inner join PROVEEDOR_PRODUCTO pp on p.idProducto=pp.idProducto
    inner join PROVEEDOR pr on pp.idProveedor=pr.idProveedor
    inner join TIPO_PRODUCTO tp on p.idTipo_Producto=tp.idTipo_Producto 
	where p.idProducto=@prmintidProducto
END
GO


CREATE OR ALTER PROCEDURE spListarProductoParaVender
as
BEGIN
SELECT p.idProducto, p.nombre, tp.nombre AS tipo ,p.longitud, p.diametro, pr.razonSocial,  p.stock, p.precioVenta
from producto p inner join PROVEEDOR_PRODUCTO pp on p.idProducto=pp.idProducto
inner join PROVEEDOR pr on pp.idProveedor=pr.idProveedor
inner join TIPO_PRODUCTO tp on p.idTipo_Producto=tp.idTipo_Producto
where p.activo=1
END
Go
CREATE OR ALTER PROCEDURE spBuscarProducto
	@campo varchar(40)
AS
BEGIN
	SELECT p.idProducto, p.nombre, tp.nombre AS tipo ,p.longitud, p.diametro, pr.razonSocial,  p.stock, pp.precioCompra, p.precioVenta,p.Activo
	from producto p left join PROVEEDOR_PRODUCTO pp on p.idProducto=pp.idProducto
	left join PROVEEDOR pr on pp.idProveedor=pr.idProveedor
	inner join TIPO_PRODUCTO tp on p.idTipo_Producto=tp.idTipo_Producto
	WHERE CONCAT(p.nombre, ' ',p.longitud) LIKE '%'+@campo+'%' OR tp.nombre LIKE '%'+@campo+'%' or pr.razonSocial like '%'+@campo+'%'
END
GO
CREATE OR ALTER PROCEDURE spBuscarProductoParaVender
	@campo varchar(40)
AS
BEGIN
	SELECT p.idProducto, p.nombre, tp.nombre AS tipo ,p.longitud, p.diametro, pr.razonSocial,  p.stock, pp.precioCompra, p.precioVenta
	from producto p inner join PROVEEDOR_PRODUCTO pp on p.idProducto=pp.idProducto
	inner join PROVEEDOR pr on pp.idProveedor=pr.idProveedor
	inner join TIPO_PRODUCTO tp on p.idTipo_Producto=tp.idTipo_Producto
	WHERE (CONCAT(p.nombre, ' ',p.longitud) LIKE '%'+@campo+'%' OR tp.nombre LIKE '%'+@campo+'%' or pr.razonSocial like '%'+@campo+'%')
	and
	p.activo=1
END
GO



CREATE OR ALTER PROCEDURE spActualizarProducto
(
	@idproducto int,
	@nombre varchar(40),
	@longitud float,
	@diametro float,
	@precioVenta float,
	@idTipo_producto int,
	@Activo bit,
	@idProveedor int,
	@precioCompra float
	
)
AS
BEGIN
update PRODUCTO set nombre=@nombre,longitud=@longitud,diametro=@diametro,precioVenta=@precioVenta,idTipo_producto=@idTipo_producto,Activo=@Activo
where idProducto=@idproducto
update PROVEEDOR_PRODUCTO set idProveedor=@idProveedor,precioCompra=@precioCompra where idProducto=@idproducto
END
GO

---====LISTAR TIPO PRODUCTO ============
--CREATE OR ALTER PROCEDURE spSelectListTipoProducto
--AS
--BEGIN
--	SELECT *FROM TIPO_PRODUCTO;
--END
--GO

CREATE OR ALTER PROCEDURE spSelectListTipoProductodat(@id int)
AS
BEGIN
	SELECT *FROM TIPO_PRODUCTO where idTipo_Producto=@id
	union all
	SELECT*FROM TIPO_PRODUCTO
END
GO

CREATE OR ALTER PROCEDURE spEliminarProducto(@idProducto int)
AS
BEGIN
    delete PROVEEDOR_PRODUCTO where idProducto=@idProducto;
	delete PRODUCTO  where idProducto = @idProducto;
END
GO
--==== BUSCAR PRODUCTOS ADMIN===

----========ROL======---
--CREATE OR ALTER PROCEDURE spListarRol
--AS
--BEGIN
--select * from rol;
--END
--GO




















--------------------------------------VENTA
--CREATE OR ALTER PROCEDURE spCrearVenta(
--	@idventa int out,
--	@total float,
--	@idUSUARIO int
--)
--AS
--BEGIN TRY
--	BEGIN TRANSACTION
--	INSERT INTO VENTA (total,idUSUARIO)values (@total,@idUSUARIO);
--	Set @idventa=@@identity;
--	COMMIT TRANSACTION
--END TRY
--BEGIN CATCH
--	ROLLBACK TRANSACTION
--	Set @idventa=-1;
--END CATCH
--GO

--CREATE OR ALTER PROCEDURE spListarVenta
--(
--	@id int
--)
--AS
--BEGIN
--	 SELECT  v.idVenta,v.fecha,v.total,v.estado,c.idUSUARIO,c.razonSocial FROM Venta v inner join USUARIO c
--	 on v.idUSUARIO=c.idUSUARIO where v.idUSUARIO=@id;	
--END
--GO

--CREATE OR ALTER PROCEDURE spListarVentaPagada
--(
--@fecha date
--)
--AS
--BEGIN
--	 SELECT *FROM Venta v
--	where MONTH(fecha) = MONTH (@fecha) and YEAR(fecha) = YEAR (@fecha) and v.estado=1
--	order by idVenta desc
--END
--GO

--CREATE OR ALTER PROCEDURE spListarVentaNoPagada
--(
--@fecha date
--)
--AS
--BEGIN
--	 SELECT *FROM Venta v
--	where MONTH(fecha) = MONTH (@fecha) and YEAR(fecha) = YEAR (@fecha) and v.estado=0
--	order by idVenta desc
--END
--GO

--CREATE OR ALTER PROCEDURE spActualizarVenta(
--	@idVenta int,
--	@estado bit
--)
--AS
--BEGIN
--	update VENTA set estado = @estado where idVenta = @idVenta;
--END
--GO

------------------------------------COMPRA
CREATE OR ALTER PROCEDURE spCrearCompra(
	@id int out,
	@total float,
	@idUsuario int
)
AS
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO COMPRA (total,idUsuario)values (@total,@idUsuario);
		Set @id=@@identity;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
		Set @id=-1;
END CATCH
GO
CREATE OR ALTER PROCEDURE spCrearDetCompra(
	@idCompra int,
	@idProveedor int,
	@idProducto int,
	@cantidad int,
	@subTotal float
	
)
AS
BEGIN
	INSERT INTO DETALLE_COMPRA values (@idCompra,@idProveedor, @idProducto, @cantidad,@subTotal);
 
END
GO
--exec spListarCompra
----select * from temporary_products
--delete from compra
select * from DETALLE_COMPRA

select * from DETALLE_COMPRA det inner join producto p 
on det.idproducto=p.idProducto
CREATE OR ALTER PROCEDURE spListarCompra
AS
BEGIN
	Select idCompra, fecha,total,u.username,estado from COMPRA c
	inner join Usuario u on c.idUsuario=u.idUsuario
END
GO
--update compra set estado='entregado' where idcompra=3
--select * from producto where idproducto=1 or idproducto=2 or idproducto=3 or idproducto=4 or idproducto=5
CREATE OR ALTER PROCEDURE spCrearTemporaryProducts
(
	@idProducto int,
	@idUsuario int,
	@cantidad int,
	@subtotal float
)
AS
BEGIN
	insert into Temporary_products values(@idProducto,@idUsuario,@cantidad,@subtotal);
END
GO

CREATE OR ALTER PROCEDURE spListarTemporaryProducts
(
	@idUsuario int
)
as
begin
    select temp.idtemp,TEMP.idUsuario,p.idProducto,pr.idProveedor,p.nombre,tp.nombre as tipo,p.longitud,p.diametro,temp.cantidad,p.precioVenta,pp.precioCompra,pr.razonSocial,pr.descripcion,temp.subtotal 
	from Temporary_products temp
	inner join PRODUCTO p on temp.idProducto=p.idProducto
		inner join TIPO_PRODUCTO tp on tp.idTipo_Producto=p.idTipo_Producto 
	inner join PROVEEDOR_PRODUCTO pp on p.idProducto=pp.idProducto
	inner join PROVEEDOR pr on pp.idProveedor=pr.idProveedor
	where temp.idUsuario=@idUsuario
end
go

----select* from usuario
--select* from Temporary_products 
--delete from Temporary_products
--exec spListarTemporaryProducts 2
CREATE OR ALTER PROCEDURE spBuscarTemporaryProductsId(@idtemp int)
AS
BEGIN
select temp.idtemp,p.nombre,tp.nombre as tipo,p.longitud,p.diametro,temp.cantidad,p.precioVenta,pp.precioCompra,pr.razonSocial,pr.descripcion,temp.subtotal from Temporary_products temp
	inner join PRODUCTO p on temp.idProducto=p.idProducto
	inner join TIPO_PRODUCTO tp on tp.idTipo_Producto=p.idProducto 
	inner join PROVEEDOR_PRODUCTO pp on p.idProducto=pp.idProducto
	inner join PROVEEDOR pr on pp.idProveedor=pr.idProveedor
	where temp.idUsuario=@idtemp
END
GO

CREATE OR ALTER PROCEDURE spEliminarTemporaryProducts(@ids int)
as
begin
 delete from Temporary_products where idtemp=@ids;
end
go

--select * from Temporary_products
--exec spEliminarTemporaryProducts 4
CREATE OR ALTER procedure spEditarTemporaryProducts(@idtemp int,@cantidad int)
as
begin
	update Temporary_products set cantidad=@cantidad where idtemp=@idtemp;
end
go


CREATE OR ALTER TRIGGER tgInsertarCompra
	on Compra
after insert
as
begin
	declare @idusuario int;
	select @idusuario=inserted.idUsuario from inserted
	--inner join compra on inserted.idCompra=compra.idCompra;
	delete from Temporary_products where Temporary_products.idUsuario=@idusuario;
end
go


CREATE OR ALTER TRIGGER tgUpdateCompra
on compra
after update
as
begin
	declare @estado varchar(10)
	declare @idcompra int
	DECLARE @idc INT
	declare @idp int
    DECLARE @stock_origen int
    DECLARE @stock_destino int

	select @estado=inserted.estado,@idcompra=inserted.idCompra from inserted
	
	if @estado='entregado'
	begin
		DECLARE cursor_actualizar CURSOR FOR
		SELECT idProducto,cantidad
		FROM DETALLE_COMPRA
		where idCompra=@idcompra

		OPEN cursor_actualizar

		FETCH NEXT FROM cursor_actualizar INTO @idp, @stock_origen

		WHILE @@FETCH_STATUS = 0
		BEGIN
		   UPDATE PRODUCTO
		   SET stock +=@stock_origen
		   WHERE idProducto = @idp
		   FETCH NEXT FROM cursor_actualizar INTO @idp, @stock_origen
		END
		CLOSE cursor_actualizar
		DEALLOCATE cursor_actualizar
	 end
end
go


--/*CREATE OR ALTER PROCEDURE spReporteCompra
--AS
--BEGIN
--    select c.idCompra, c.fecha, p.nombre, p.longitud, det.cantidad, det.preUnitario, det.subTotal from COMPRA c 
--	inner join DETALLE_COMPRA det on c.idCompra = det.idCompra
--	inner join PRODUCTO p on det.idProducto = p.idProducto
--END
--GO*/

--CREATE OR ALTER PROCEDURE spEliminarCompra(
--	@idCompra int
--)
--AS
--BEGIN
--    delete DETALLE_COMPRA where idCompra= @idCompra;
--	delete COMPRA where idCompra = @idCompra;
--END
--GO

--CREATE OR ALTER PROCEDURE spBuscarCompra(
--	@Campo varchar(40)
--)
--AS
--BEGIN
--	Select c.idCompra, c.fecha, c.total, c.IdProveedor, p.descripcion from COMPRA c inner join PROVEEDOR p
--	on p.idProveedor = c.idProveedor
--	where p.descripcion like @Campo+'%'
--	or dni like @Campo+'%'	
--END
--GO

--------------------------------------DETALLE_COMPRA


--/*CREATE OR ALTER PROCEDURE spMostrarReporteCompra(
--	@idCompra int	
--)
--AS
--BEGIN
--	Select det.idCompra as CODIGO, p.razonSocial as PROVEEDOR , c.fecha as FECHA, pro.nombre as DESCRIPCIÓN, 
--	concat (pro.longitud, ' ','MTS') as LONGITUD, det.cantidad as CANTIDAD,det.preUnitario as PRECIO_UNITARIO, 
--	det.subTotal as SUBTOTAL from DETALLE_COMPRA det
	
--	inner join COMPRA c on det.idCompra = c.idCompra
--	inner join PROVEEDOR p on c.idProveedor = p.idProveedor
--	inner join PRODUCTO pro on det.idProducto = pro.idProducto
--	where c.idCompra = @idCompra;
--END
--GO*/
--------------------------------------DETALLE_VENTA
--CREATE OR ALTER PROCEDURE spCrearDetVenta(
--	@idVenta int,
--	@idProducto int,
--	@cantidad int,
--	@subTotal float
	
--)
--AS
--BEGIN
--	INSERT INTO DETALLE_VENTA values (@idVenta, @idProducto, @cantidad,@subTotal);
--	update Producto set stock -= @cantidad 
--	where idProducto = @idProducto;
--END
--GO

--CREATE OR ALTER PROCEDURE spMostrarReporteVentas(
--	@idVenta int	
--)
--AS
--BEGIN
--	Select det.idventa as CODIGO, cli.razonSocial as USUARIO , v.fecha as FECHA, pro.nombre as DESCRIPCIÓN, 
--	concat (pro.longitud, ' ','MTS') as LONGITUD, det.cantidad as CANTIDAD, 
--	det.subTotal as SUBTOTAL from DETALLE_VENTA det
	
--	inner join VENTA v on det.idVenta = v.idVenta
--	inner join USUARIO cli on v.idUSUARIO = cli.idUSUARIO
--	inner join PRODUCTO pro on det.idProducto = pro.idProducto
--	where v.idVenta = @idVenta;
--END
--go

--CREATE OR ALTER PROCEDURE spReturnID(
--    @tipo varchar(10)
--)
--AS
--BEGIN
--    SELECT IDENT_CURRENT(@tipo);
--END
--GO

------------------------------------------CONSULTAS
--CREATE OR ALTER PROCEDURE spDashboardDatos
--	@totVentas float out,--Establecer parametros de salida para mostrarlo posteriormente
--	@totCompras float out,
--	@cantVentas int out,
--	@cantCompras int out,
--	@cantProveedor int out,
--	@cantUSUARIO int out
--AS
--BEGIN
--	set @totVentas = (select sum(total) as TotalVentas from VENTA); --set permite establecer un valor para los parametros establecidos
--	set @totCompras = (select sum(total) as TotalCompra from COMPRA);
--	set @cantVentas = (select count(idVenta) as CantidadVentas from VENTA);
--	set @cantCompras = (select count(idCompra) as CantidadCompras from COMPRA);
--	set @cantProveedor = (select count(idProveedor) as CantidadProveedores from PROVEEDOR
--	where estProveedor = 0);
--	set @cantUSUARIO = (select count(idUSUARIO) as CantidadUSUARIOs from USUARIO);

--END
--GO

--Productos preferidos
--CREATE OR ALTER PROCEDURE spProductosPreferidos
--AS
--BEGIN
--	Select top 3 p.nombre as NombreMadera, count(dv.idProducto) as CantidadSalidas from DETALLE_VENTA dv
--	inner join PRODUCTO p on p.idProducto = dv.idProducto
--	group by dv.idProducto, p.nombre
--	order by count(2) desc; 
--END
--GO

