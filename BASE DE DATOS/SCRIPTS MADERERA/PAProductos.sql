CREATE OR ALTER PROCEDURE spListarProducto
AS
BEGIN
	SELECT p.idProducto, p.nombre, p.longitud, p.precioVenta, p.stock, t.nombre as tipo from PRODUCTO p
	inner join TIPO_PRODUCTO t on p.idTipo_Producto = t.idTipo_Producto;
END
GO

CREATE OR ALTER PROCEDURE spBuscarProducto(
	@campo varchar(40)
)
AS
BEGIN
	SELECT p.idProducto, p.nombre, p.longitud, p.precioVenta, p.stock, t.nombre as tipo from PRODUCTO p
	inner join TIPO_PRODUCTO t on p.idTipo_Producto = t.idTipo_Producto where CONCAT(p.nombre, ' ',p.longitud) LIKE '%'+@campo+'%' OR t.nombre LIKE @campo;
END
GO

