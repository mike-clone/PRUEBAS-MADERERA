
 CREATE OR ALTER PROCEDURE spMostrarDetalleProveedorId
 (
 @idProveedor int
 )
 AS
 BEGIN
 SELECT prov.razonSocial,prov.descripcion,p.idproducto,prod.nombre,prod.longitud,p.precioCompra
 FROM PROVEEDOR PROV INNER JOIN PROVEEDOR_PRODUCTO P ON PROV.idProveedor=P.idProveedor
 inner join PRODUCTO prod on p.idproducto=prod.idProducto
 where p.idProveedor=@idProveedor
 END
 GO

 