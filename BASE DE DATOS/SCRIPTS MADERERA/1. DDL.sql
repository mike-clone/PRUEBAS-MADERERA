USE MASTER 
GO
alter database [BD_PRUEBAS_MADERERA] set single_user with rollback immediate
DROP DATABASE [BD_PRUEBAS_MADERERA]
CREATE DATABASE [BD_PRUEBAS_MADERERA]
USE [BD_PRUEBAS_MADERERA]
GO

CREATE TABLE UBIGEO(
	idUbigeo VARCHAR(6) UNIQUE NOT NULL,
	departamento varchar(32) DEFAULT NULL,
	provincia varchar(32) DEFAULT NULL,
	distrito varchar(32) DEFAULT NULL
)
GO

CREATE TABLE PROVEEDOR(
	idProveedor int primary key identity,
	razonSocial varchar(40) not null,
	ruc varchar(11) null,
	correo varchar(40),
	telefono varchar(9) null,
	descripcion varchar (80),
	estProveedor bit default 1,
	idUbigeo VARCHAR(6) null

	constraint fk_Proveedor_Ubigeo foreign key (idUbigeo) references Ubigeo (idUbigeo)
)
GO

CREATE TABLE TIPO_PRODUCTO(
	idTipo_Producto int primary key identity,
	nombre varchar(30) not null,
)
GO
CREATE TABLE PRODUCTO(
	idProducto int primary key identity,
	nombre varchar(40) not null,
	longitud float not null,
	diametro float not null,
	precioVenta float default 0,
	stock int default 0,
	idTipo_Producto int not null,
	Activo bit default 1,

	constraint fk_Producto_Tipo foreign key (idTipo_Producto) references TIPO_PRODUCTO (idTipo_Producto)
)
GO

CREATE TABLE PROVEEDOR_PRODUCTO
(
  idProveedor int not null,
  idProducto int not null,
  precioCompra float not null,
 
  constraint pk_proveedor_producto primary key (idProveedor,idProducto),
  constraint fk_proveedor_producto_producto foreign key (idProducto) references PRODUCTO (idProducto),
  constraint fk_proveedor_producto_proveedor foreign key (idProveedor) references PROVEEDOR (idProveedor)
)
GO


CREATE TABLE ROL(
	idRol int primary key identity,
	descripcion varchar(50)
)
GO


CREATE TABLE Usuario(
	idUsuario int primary key identity,
	razonSocial varchar(40) not null,
	telefono varchar(9) null,
	direccion varchar(60) null,
	idUbigeo VARCHAR(6)null,
	fecCreacion datetime default getdate(),
	f_inicio date default getdate(),
    f_fin date NULL,
    salario float null,
	correo varchar(40) not null,
	userName varchar (20) not null,
	pass varchar(200) not null,
	idRol int,
	activo bit default 1,

	constraint fk_Usuario_Ubigeo foreign key (idUbigeo) references Ubigeo (idUbigeo),
	constraint fk_usuario_rol foreign key(idRol) references Rol (idRol)
)
GO

CREATE TABLE VENTA(
	idVenta int primary key identity,
	fecha datetime default getdate(),
	total float not null,
	estado varchar (10) default 'en proceso',
	idUsuario int not null

	constraint fk_Venta_Usuario foreign key (idUsuario) references Usuario (idUsuario)
)
GO

CREATE TABLE DETALLE_VENTA(
	idVenta int not null,
	IdProducto int,
	cantidad int not null,
	subTotal float not null
	
	constraint pk_detVenta primary key (idVenta,IdProducto), 
	constraint fk_detVenta_Venta foreign key (idVenta) references VENTA (idVenta),
	constraint fk_detVenta_Producto foreign key (IdProducto) references Producto (idProducto)
)
GO

CREATE TABLE COMPRA(
	idCompra int primary key identity,
	fecha date default getdate(),
	total float not null,
	idUsuario int not null,
	estado varchar(10) default 'en proceso',
	constraint fk_compra_usuario foreign key (idUsuario) references usuario (idUsuario)
)
GO

CREATE TABLE DETALLE_COMPRA(
	idCompra int not null,
	idProveedor int,
	IdProducto int,
	cantidad int not null,
	subTotal float not null,

	constraint pk_detCompra primary key (idCompra,idProveedor,IdProducto),
	constraint fk_detCompra_Compra foreign key (idCompra) references COMPRA (idCompra),
	constraint fk_detCompra_Prveedor_producto foreign key (idProveedor,IdProducto) references PROVEEDOR_PRODUCTO (idProveedor,idProducto)
)																						
GO

CREATE TABLE Temporary_products(
   idTemp int primary key identity,
   idProducto int,
   idProveedor int,
   idUsuario int not null,
   cantidad int not null,
   subtotal float,
   constraint fk_temporals_products_producto foreign key (idProducto) references PRODUCTO (idProducto),
   constraint fk_temporals_products_usuario foreign key (idUsuario) references usuario (idUsuario),
   constraint fk_temporals_products_proveedor_producto foreign key(idProveedor,idProducto) references proveedor_producto(idProveedor,idProducto)
)
go

--------------------------------------------RESTRICCIONES---------------------------------------------

--Usuario
CREATE  UNIQUE INDEX idx_UsuarioTelefono ON USUARIO (telefono) WHERE telefono IS NOT NULL;
ALTER TABLE Usuario ADD	CONSTRAINT CHK_Usuario_telefono CHECK(telefono LIKE '9[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' or telefono = '' or telefono LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');
ALTER TABLE Usuario ADD CONSTRAINT uq_Usuario_userName UNIQUE(userName);
ALTER TABLE Usuario ADD CONSTRAINT uq_Usuario_correo UNIQUE(correo);
--PROVEEDOR
CREATE  UNIQUE INDEX idx_ProveedorRuc ON PROVEEDOR (ruc) WHERE ruc IS NOT NULL;
CREATE  UNIQUE INDEX idx_ProveedorTelefono ON PROVEEDOR (telefono) WHERE telefono IS NOT NULL;
ALTER TABLE PROVEEDOR ADD CONSTRAINT CHK_PROVEEDOR_telefono CHECK(telefono LIKE '9[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' or telefono = '' or telefono LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9]');
ALTER TABLE PROVEEDOR ADD CONSTRAINT CHK_PROVEEDOR_ruc CHECK(ruc LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');
ALTER TABLE PROVEEDOR ADD CONSTRAINT CHK_estProveedor CHECK(estProveedor LIKE '[0-2]');
--COMPRA
ALTER TABLE COMPRA ADD CONSTRAINT chk_compra_estado CHECK(estado='en proceso' or estado='cancelado' or estado='entregado');
GO

