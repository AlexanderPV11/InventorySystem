create DataBase Ventas_Alarmed
go 
use Ventas_Alarmed
go


---Tabla Proveedores--
create table Proveedores
(
Id_Proveedor int identity(1,1) primary key not null,
Codigo varchar(15) not null,
Nombre varchar(50) not null,
RUC_Proveedor varchar(100) not null,
Direccion varchar(150) not null,
Telefono varchar(15) not null,
Email varchar(50)not null
)
go

---Tabla Clientes--
create table Clientes
(
Id_Cliente int identity(1,1) primary key not null,
Codigo varchar(15) not null,
Nombre varchar(50) not null,
Cedula varchar(15) not null,
Direccion varchar(150) not null,
Telefono varchar(15) not null,
Email varchar(20)not null,
Borrado bit not null
)
go

--Tabla productos--
create table Productos
(
Id_Productos int identity(1,1) primary key not null,
CodigoBarra varchar(50) not null,
Codigo varchar(15) not null,
Nombre varchar(50) not null,
Descripcion varchar(100) not null,
Presentacion varchar(20) not null,
Costo_unitario decimal(12,2) not null,
Precio_venta decimal(12,2)not null,
Tipo_cargo varchar(10) not null,
Borrado bit not null
)
go

--Tabla invetario--
create table Inventario
(
Id_invetario int not null,
Codigo varchar(15) not null,
Nombre varchar(50) not null,
Cantidad int not null,
Costo_unitario decimal(12,2) not null,
Precio_venta decimal(12,2) not null,
Monto_total decimal(12,2) not null,
Tipo_cargo varchar(10) not null,
Borrado bit not null
)
go

--Tabla Ingreso de productos--
create table Ingreso_Productos
(
Id_Ingreso int identity(1,1) primary key,
No_Ingreso varchar(15) not null,
Id_Proveedor int not null,
Fecha_Ingreso date not null,
Comprobante varchar(20) not null,
Monto_Total decimal(12,2) not null,
Estado varchar(10) not null
)
go

--Tabla Detalles de Ingreso--
create table Detalle_Ingreso
(
Id_Detalle int identity(1,1) primary key,
Id_Ingreso int not null,
Id_Productos int not null,
Nombre varchar(20) not null,
Cantidad int not null,
Costo_Unitario decimal(12,2) not null,
Sub_Total decimal(12,2) not null,
Borrado bit not null
)
go

--Tabla ventas --
create table Ventas
(
Id_Venta int identity(1,1) primary key not null,
Id_Cliente int not null,
No_Factura nvarchar(15) not null,
Fecha_Venta date not null,
Fecha_Validez date not null,
Comprobante nvarchar(20) not null,
Sub_Total decimal(12,2) not null,
Descuento decimal(12,2) not null,
Iva decimal(12,2) not null,
Monto_Total decimal(12,2) not null,
Estado varchar(10),
Id_Usuario int
)
go

--Tabla detalle venta--
create table Detalle_Venta
(
Id_Detalle int identity(1,1) primary key not null,
Id_Venta int not null,
Id_Productos int not null,
Presentacion varchar(20) not null,
Cantidad int not null,
Precio_Venta decimal(12,2) not null,
Sub_Total decimal(12,2) not null,
Descuento decimal(12,2) not null,
Iva decimal(12,2) not null,
Monto_Total decimal(12,2) not null
)
go


-- tabla usuarios --

create table Usuarios
(
Id_Usuario int identity(1,1) primary key,
Nombre varchar(50) not null,
Apellidos varchar(50) not null,
Usuario varchar(30) not null,
Password varchar(20) not null
)
go

--TABLA TIPO DE COMPROBANTE --
Create table Tipos_Comprobante
(
Id_Comprobante int identity(1,1) primary key,
Nombre_Comprobante varchar(50),
Tipo_Comprobante varchar(4),
Correlativo int
)
go



----------PROCEDIMIENTOS ALMACENADOS-------
---Agregar producto------------------------
create proc AgregarProducto
@CodigoBarra varchar(50),
@Codigo varchar(15),
@Nombre varchar(50),
@Descripcion varchar(100),
@Presentacion varchar(20),
@Costo_unitario decimal(12,2),
@Precio_venta decimal(12,2),
@Tipo_cargo varchar(10),
@Borrado bit = "false"
as
	insert into Productos(CodigoBarra, Codigo, Nombre, Descripcion, Presentacion, Costo_unitario, Precio_venta, Tipo_cargo, Borrado)
	values(@CodigoBarra, @Codigo, @Nombre, @Descripcion, @Presentacion, @Costo_unitario, @Precio_venta, @Tipo_cargo, @Borrado)
go
--------------------------------------------


---Editar producto------------------------
create proc EditarProducto
@Id_Productos int,
@CodigoBarra varchar(50),
@Codigo varchar(15),
@Nombre varchar(50),
@Descripcion varchar(100),
@Presentacion varchar(20),
@Costo_unitario decimal(12,2),
@Precio_venta decimal(12,2),
@Tipo_cargo varchar(10),
@Borrado bit = "false"
as
	update Productos set CodigoBarra = @CodigoBarra, Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, Presentacion=@Presentacion, 
			Costo_unitario=@Costo_unitario, Precio_venta=@Precio_venta, Tipo_cargo=@Tipo_cargo, Borrado=@Borrado
			where Id_Productos=@Id_Productos
go
-------------------------------------------

---Eliminar producto------------------------
create proc EliminarProducto
@Id_Productos int
as
	update Productos set Borrado=1 where Id_Productos=@Id_Productos
go

--TRIGGER PARA AGREGAR UN PRODUCTO AL INVENTARIO--
create trigger Tr_agregar_Producto_Inventario
on Productos for insert
as
declare @Id_inventario int
declare @Codigo varchar(15)
declare @Nombre varchar(50)
declare @Cantidad int
declare @Costo_unitario decimal(12,2)
declare @Precio_venta decimal (12,2)
declare @Monto_total decimal (12,2)
declare @Tipo_cargo varchar(10)
declare @Borrado bit 
select @Id_inventario=Id_Productos, @Codigo=Codigo, @Nombre=Nombre, @Cantidad=0, @Costo_unitario=Costo_unitario,
@Precio_venta=Precio_venta, @Monto_total=(@Cantidad * @Costo_unitario), @Tipo_cargo=Tipo_cargo, @Borrado=0 from inserted
insert into Inventario(Id_invetario, Codigo, Nombre, Cantidad, Costo_unitario, Precio_venta, Monto_total, Tipo_cargo, Borrado)
values(@Id_inventario, @Codigo, @Nombre, @Cantidad, @Costo_unitario, @Precio_venta, @Monto_total, @Tipo_cargo, @Borrado)
go

--TRIGGER PARA EDITAR UN PRODUCTO AL INVENTARIO--
create trigger Tr_editar_Producto_Inventario
on Productos for update
as
set Nocount on
declare @Id_inventario int
declare @Codigo varchar(15)
declare @Nombre varchar(50)
declare @Cantidad int
declare @Costo_unitario decimal(12,2)
declare @Precio_venta decimal (12,2)
declare @Monto_total decimal (12,2)
declare @Tipo_cargo varchar(10)
declare @Borrado bit
select @Id_inventario=Id_Productos, @Codigo=Codigo, @Nombre=Nombre, @Cantidad=0, @Costo_unitario=Costo_unitario,
@Precio_venta=Precio_venta, @Monto_total=(@Cantidad * @Costo_unitario), @Tipo_cargo=Tipo_cargo, @Borrado=0 from inserted
select @Cantidad = Cantidad from Inventario where Id_invetario = @Id_inventario
update Inventario set Inventario.Codigo = @Codigo, Inventario.Nombre = @Nombre,
Inventario.Costo_unitario = @Costo_unitario, Inventario.Precio_venta = @Precio_venta, Inventario.Monto_total = (@Cantidad * @Costo_unitario), Inventario.Tipo_cargo = @Tipo_cargo
where Id_invetario = @Id_inventario
go




--TRIGGER PARA ELIMINAR UN PRODUCTO EN EL INVENTARIO--
create trigger Tr_eliminar_Producto_Inventario
on Productos for insert
as
set nocount on
declare @Id_inventario int
declare @Cantidad int
select @Id_inventario = Id_Productos from deleted
delete from Inventario where Id_invetario = @Id_inventario
go

--BUSCAR UN PRODUCTO POR EL CODIGO
create proc  Buscar_producto_codigo
@Buscar varchar (50)
as
select * from Productos where Codigo like @Buscar + '%'
go

--BUSCAR UN PRODUCTO POR EL NOMBRE
create proc  Buscar_producto_nombre
@Buscar varchar (50)
as
select * from Productos where Nombre like @Buscar + '%'
go

--BUSCAR UN PRODUCTO POR EL PRESENTACION
create proc  Buscar_producto_presentacion
@Buscar varchar (50)
as
select * from Productos where Presentacion like @Buscar + '%'
go

--*************************************************************************--
-------------------------------PROC ALM PROVEEDORES---------------------------
----------PROCEDIMIENTOS ALMACENADOS-------
---Agregar Proveedor------------------------
create proc AgregarProveedor
@Codigo varchar(15),
@Nombre varchar(50),
@RUC_Proveedor varchar(100),
@Direccion varchar(150),
@Telefono varchar(15),
@Email varchar(50)
as
	insert into Proveedores(Codigo, Nombre, RUC_Proveedor, Direccion, Telefono, Email)
	values(@Codigo, @Nombre, @RUC_Proveedor, @Direccion, @Telefono, @Email)
go
--------------------------------------------

---Editar Proveedor------------------------
create proc EditarProveedor
@Id_Proveedor int,
@Codigo varchar(15),
@Nombre varchar(50),
@RUC_Proveedor varchar(100),
@Direccion varchar(150),
@Telefono varchar(15),
@Email varchar(50)
as
	update Proveedores set Codigo=@Codigo, Nombre=@Nombre, RUC_Proveedor=@RUC_Proveedor, Direccion=@Direccion, 
			Telefono=@Telefono, Email=@Email
			where Id_Proveedor=@Id_Proveedor
go
-------------------------------------------

---Eliminar Proveedor------------------------
create proc EliminarProveedor
@Id_Proveedor int
as
	delete from Proveedores where Id_Proveedor = @Id_Proveedor
go

--BUSCAR UN PROVEEDOR POR EL CODIGO
create proc  Buscar_proveedor_codigo
@Buscar varchar (50)
as
select * from Proveedores where Codigo like @Buscar + '%'
go

--BUSCAR UN PROVEEDOR POR EL NOMBRE
create proc  Buscar_proveedor_nombre
@Buscar varchar (50)
as
select * from Proveedores where Nombre like @Buscar + '%'
go

--BUSCAR UN PROVEEDOR POR EL RUC
create proc  Buscar_proveedor_RUC
@Buscar varchar (50)
as
select * from Proveedores where RUC_Proveedor like @Buscar + '%'
go

--*************************************************************************--
-------------------------------PROC ALM CLIENTES---------------------------
----------PROCEDIMIENTOS ALMACENADOS-------
---Agregar Cliente------------------------
create proc AgregarCliente
@Codigo varchar(15),
@Nombre varchar(50),
@Cedula varchar(100),
@Direccion varchar(150),
@Telefono varchar(15),
@Email varchar(50),
@Borrado bit = "false"
as
	insert into Clientes(Codigo, Nombre, Cedula, Direccion, Telefono, Email, Borrado)
	values(@Codigo, @Nombre, @Cedula, @Direccion, @Telefono, @Email, @Borrado)
go
--------------------------------------------



---Editar Cliente------------------------
create proc EditarCliente
@Id_Cliente int,
@Codigo varchar(15),
@Nombre varchar(50),
@Cedula varchar(100),
@Direccion varchar(150),
@Telefono varchar(15),
@Email varchar(50),
@Borrado bit = "false"
as
	update Clientes set Codigo=@Codigo, Nombre=@Nombre, Cedula=@Cedula, Direccion=@Direccion, 
			Telefono=@Telefono, Email=@Email, Borrado = @Borrado
			where Id_Cliente=@Id_Cliente
go
-------------------------------------------

---Eliminar Cliente------------------------
create proc EliminarCliente
@Id_Cliente int
as
	update Clientes set Borrado=1 where Id_Cliente=@Id_Cliente
go

--BUSCAR UN CLIENTE POR EL CODIGO
create proc  Buscar_cliente_codigo
@Buscar varchar (50)
as
select * from Clientes where Codigo like @Buscar + '%'
go

--BUSCAR UN CLIENTE POR EL NOMBRE
create proc  Buscar_cliente_nombre
@Buscar varchar (50)
as
select * from Clientes where Nombre like @Buscar + '%'
go

--BUSCAR UN CLIENTE POR CEDULA
create proc  Buscar_cliente_cedula
@Buscar varchar (50)
as
select * from Clientes where Cedula like @Buscar + '%'
go


--*************************************************************************--
-------------------------------PROC ALM INGRESO  PRODUCTOS---------------------------
----------PROCEDIMIENTOS ALMACENADOS-------
---Agregar ingreso productos------------------------
create proc Agregar_Ingreso_Productos
@No_Ingreso varchar(15),
@Id_Proveedor int,
@Fecha_Ingreso date,
@Comprobante varchar(20),
@Monto_Total decimal(12,2),
@Estado varchar(10)
as
insert into Ingreso_Productos(No_Ingreso, Id_Proveedor, Fecha_Ingreso, Comprobante, Monto_Total, Estado)
	values(@No_Ingreso, @Id_Proveedor, @Fecha_Ingreso, @Comprobante, @Monto_Total, @Estado)
go

---anular ingreso productos------------------------
create proc Anular_Ingreso_Productos
@No_Ingreso varchar(15),
@Id_Ingreso int,
@Id_Proveedor int,
@Fecha_Ingreso date,
@Comprobante varchar(20),
@Monto_Total decimal(12,2),
@Estado varchar(10)
as
update Ingreso_Productos set No_Ingreso = @No_Ingreso, Id_Proveedor = @Id_Proveedor, Fecha_Ingreso = @Fecha_Ingreso, Comprobante = @Comprobante, Monto_Total = @Monto_Total, Estado = @Estado
	where Id_Ingreso = @Id_Ingreso
go

--*************************************************************************--
-------------------------------PROC ALM DETALLE DE INGRESO---------------------------
----------PROCEDIMIENTOS ALMACENADOS-------

--Agregar detalles de ingreso--
create proc Agregar_Detalle_Ingreso
@Id_Ingreso int,
@Id_Productos int,
@Nombre varchar(20),
@Cantidad int,
@Costo_Unitario decimal(12,2),
@Sub_Total decimal(12,2),
@Borrado bit = "false"
as
insert into Detalle_Ingreso (Id_Ingreso, Id_Productos, Nombre, Cantidad, Costo_Unitario, Sub_Total, Borrado)
values (@Id_Ingreso, @Id_Productos, @Nombre, @Cantidad, @Costo_Unitario, @Sub_Total, @Borrado)
go



--anular detalles de ingreso--
create proc Anular_Detalle_Ingreso
@Id_Detalle int,
@Id_Ingreso int,
@Id_Productos int,
@Nombre varchar(20),
@Cantidad int,
@Costo_Unitario decimal(12,2),
@Sub_Total decimal(12,2)
as
update Detalle_Ingreso set Id_Ingreso = @Id_Ingreso, Id_Productos = @Id_Productos, Nombre = @Nombre, Cantidad = @Cantidad, Costo_Unitario = @Costo_Unitario, Sub_Total = @Sub_Total
where Id_Detalle = @Id_Detalle
go

--TRIGGER PARA AGREGAR LOS PRODUCTOS INGRESADOS AL INVENTARIO--
create trigger Tr_Balancear_Productos_Inventario
on Detalle_Ingreso for insert
as
set nocount on
declare @Id_Inventario int
declare @Cantidad int
declare @Stock_Actual int
declare @Costo_Unitario decimal(12,2)
declare @Monto_Total decimal(12,2)
declare @Balance_Actual decimal(12,2)
select @Id_Inventario = Id_Productos, @Cantidad = Cantidad, @Costo_Unitario = Costo_Unitario, @Monto_Total = (@Cantidad * @Costo_Unitario)
from inserted 
select @Stock_Actual = Cantidad, @Balance_Actual = Monto_Total from Inventario where Id_invetario = @Id_Inventario
update Inventario set Inventario.Cantidad = @Cantidad + @Stock_Actual, Inventario.Monto_total = @Monto_Total + @Balance_Actual
where Inventario.Id_invetario = @Id_Inventario
go

--TRIGGER PARA DISMINUIR LOS PRODUCTOS INGRESADOS AL INVENTARIO--
create trigger Tr_Reducir_Productos_Inventario
on Detalle_Ingreso for update
as
set nocount on
declare @Id_Inventario int
declare @Cantidad int
declare @Stock_Actual int
declare @Costo_Unitario decimal(12,2)
declare @Monto_Total decimal(12,2)
declare @Balance_Actual decimal(12,2)
select @Id_Inventario = Id_Productos, @Cantidad = Cantidad
from inserted 
select @Stock_Actual = Cantidad, @Costo_Unitario = Costo_unitario, @Balance_Actual = Monto_total from Inventario where Id_invetario = @Id_Inventario
update Inventario set Inventario.Cantidad = @Stock_Actual - @Cantidad, Inventario.Monto_total = @Balance_Actual - (@Cantidad * @Costo_Unitario)
where Inventario.Id_invetario = @Id_Inventario
go

--TRIGGER PARA EDITAR LOS PRODUCTOS INGRESADOS AL INVENTARIO--
create trigger Tr_Editar_Productos_Inventario
on Productos for update
as
set nocount on
declare @Id_Inventario int
declare @Codigo varchar(15)
declare @Nombre varchar(50)
declare @Cantidad int
declare @Costo_Unitario decimal(12,2)
declare @Precio_Venta decimal(12,2)
declare @Monto_Total decimal(12,2)
declare @Tipo_Cargo varchar(10)
select @Id_Inventario = Id_Productos, @Codigo = Codigo, @Nombre = Nombre, @Costo_Unitario = Costo_unitario,
@Precio_Venta = Precio_venta, @Tipo_Cargo = Tipo_cargo from inserted
select @Cantidad = Cantidad from Inventario where Id_invetario = @Id_Inventario
update Inventario set Inventario.Codigo = @Codigo, Inventario.Nombre = @Nombre,
Inventario.Costo_unitario = @Costo_Unitario, Inventario.Precio_venta = @Precio_Venta, Inventario.Monto_total = (@Cantidad * @Costo_Unitario),
Inventario.Tipo_cargo = @Tipo_Cargo
where Inventario.Id_invetario = @Id_Inventario
go


--MOSTRAR DETALLES DE INGRESOS--
create proc Mostrar_Ingreso
as
select Ing.Id_Ingreso, Ing.Id_Proveedor, Ing.No_Ingreso, Pro.Nombre as 'Nombre Proveedor', Ing.Fecha_Ingreso, Ing.Comprobante, Ing.Monto_Total, Ing.Estado 
from Ingreso_Productos ing inner join Proveedores Pro
on Ing.Id_Proveedor = Pro.Id_Proveedor
go


-- MOSTRAR INGRESO PRODUCTOS --
create proc Mostrar_Ingreso_Productos
@Id_Ingreso int 
as
select Ing.No_Ingreso, Prov.Nombre as 'Proveedor', Ing.Fecha_Ingreso, Ing.Comprobante, Ing.Estado, DetIng.Nombre,
DetIng.Cantidad, DetIng.Costo_Unitario, DetIng.Sub_Total as 'Total'
from Ingreso_Productos Ing inner join Detalle_Ingreso DetIng on Ing.Id_Ingreso = DetIng.Id_Ingreso
inner join Proveedores Prov on Ing.Id_Proveedor = Prov.Id_Proveedor
where Ing.Id_Ingreso = @Id_Ingreso
go

--MOSTRAR PRODUTOS PARA LA VENTA--
create proc Mostrar_Productos_Ventas
as
select Pro.Id_Productos, Pro.CodigoBarra, Pro.Codigo, Pro.Nombre as 'Nombre Producto', Pro.Precio_venta,
Pro.Tipo_cargo as 'IVA' ,Inv.Cantidad, Pro.Presentacion
from Productos Pro inner join Inventario Inv on Pro.Id_Productos = Inv.Id_invetario
go


--BUSCAR INGRESO PRODUCTO POR PROVEEDOR--
create proc Buscar_IngresoProducto_Proveedor
@Buscar nvarchar(100)
as
select Ing.Id_Ingreso, Ing.No_Ingreso, Pro.Nombre as 'Nombre Proveedor', Ing.Fecha_Ingreso, Ing.Comprobante, Ing.Monto_Total, Ing.estado
from Ingreso_Productos Ing inner join Proveedores Pro on Ing.Id_Proveedor = Pro.Id_Proveedor
where Nombre like @Buscar + '%'
go

--BUSCAR INGRESO PRODUCTO POR FECHA--
create proc Buscar_IngresoProducto_Fecha
@Buscar nvarchar(100)
as
select Ing.Id_Ingreso, Ing.No_Ingreso, Pro.Nombre as 'Nombre Proveedor', Ing.Fecha_Ingreso, Ing.Comprobante, Ing.Monto_Total, Ing.estado
from Ingreso_Productos Ing inner join Proveedores Pro on Ing.Id_Proveedor = Pro.Id_Proveedor
where Fecha_Ingreso like @Buscar + '%'
go

--BUSCAR INGRESO PRODUCTO POR COMPROBANTE--
create proc Buscar_IngresoProducto_Comprobante
@Buscar nvarchar(100)
as
select Ing.Id_Ingreso, Ing.No_Ingreso, Pro.Nombre as 'Nombre Proveedor', Ing.Fecha_Ingreso, Ing.Comprobante, Ing.Monto_Total, Ing.estado
from Ingreso_Productos Ing inner join Proveedores Pro on Ing.Id_Proveedor = Pro.Id_Proveedor
where Comprobante like @Buscar + '%'
go


--*************************************************************************--
-------------------------------PROC ALM VENTA---------------------------
----------PROCEDIMIENTOS ALMACENADOS-------
create proc AgregarVenta
@Id_Cliente int,
@No_Factura nvarchar(15),
@Fecha_Venta date,
@Fecha_Validez date,
@Comprobante varchar(20),
@Sub_Total decimal(12,2),
@Descuento decimal(12,2),
@Iva decimal(12,2),
@Monto_Total decimal(12,2),
@Estado varchar(10),
@Id_Usuario int
as
	insert into Ventas(Id_Cliente, No_Factura, Fecha_Venta, Fecha_Validez, Comprobante, Sub_Total, Descuento, Iva, Monto_Total, Estado, Id_Usuario)
	values(@Id_Cliente, @No_Factura, @Fecha_Venta, @Fecha_Validez, @Comprobante, @Sub_Total, @Descuento, @Iva, @Monto_Total, @Estado, @Id_Usuario)
go

create proc AnularVenta
@Id_Venta int,
@Id_Cliente int,
@No_Factura nvarchar(15),
@Fecha_Venta date,
@Fecha_Validez date,
@Comprobante varchar(20),
@Sub_Total decimal(12,2),
@Descuento decimal(12,2),
@Iva decimal(12,2),
@Monto_Total decimal(12,2),
@Estado varchar(10),
@Id_Usuario int
as
	update Ventas set Id_Cliente = @Id_Cliente, No_Factura = @No_Factura, Fecha_Venta = @Fecha_Venta, Fecha_Validez = @Fecha_Validez, 
	Comprobante = @Comprobante, Sub_Total = @Sub_Total, Descuento = @Descuento, Iva = @Iva, Monto_Total = @Monto_Total, Estado = @Estado, Id_Usuario = @Id_Usuario
	where Id_Venta = @Id_Venta
go
-------------------------------------
create proc AgregarDetalleVenta
@Id_Venta int,
@Id_Productos int,
@Presentacion varchar(20),
@Cantidad int,
@Precio_Venta decimal(12,2),
@Sub_Total decimal(12,2),
@Descuento decimal(12,2),
@Iva decimal(12,2),
@Monto_Total decimal(12,2)
as
	insert into Detalle_Venta(Id_Venta, Id_Productos, Presentacion, Cantidad, Precio_Venta, Sub_Total, Descuento, Iva, Monto_Total)
	values (@Id_Venta, @Id_Productos, @Presentacion, @Cantidad, @Precio_Venta, @Sub_Total, @Descuento, @Iva, @Monto_Total)
go

create proc AnularDetalleVenta
@Id_Detalle int,
@Id_Venta int,
@Id_Productos int,
@Presentacion varchar(20),
@Cantidad int,
@Precio_Venta decimal(12,2),
@Sub_Total decimal(12,2),
@Descuento decimal(12,2),
@Iva decimal(12,2),
@Monto_Total decimal(12,2)
as
	update Detalle_Venta set Id_Venta = @Id_Venta, Id_Productos = @Id_Productos, Presentacion = @Presentacion, 
	Cantidad = @Cantidad, Precio_Venta = @Precio_Venta, Sub_Total = @Sub_Total, Descuento = @Descuento, Iva = @Iva, Monto_Total = @Monto_Total
	where Id_Detalle = @Id_Detalle
go


create trigger Tr_Disminuir_Producto_Inventario
on Detalle_Venta for insert
as
set nocount on
declare @Id_Inventario int
declare @Cantidad int
declare @Stock_Actual int 
declare @Costo_Unitario decimal(12,2)
declare @Monto_Total decimal(12,2)
declare @Balance_Actual decimal(12,2)
select @Id_Inventario = Id_Productos, @Cantidad = Cantidad from inserted
select @Stock_Actual = Cantidad, @Costo_Unitario = Costo_unitario, @Balance_Actual = Monto_total from Inventario where Id_invetario = @Id_Inventario
update Inventario set Inventario.Cantidad = @Stock_Actual - @Cantidad, Inventario.Monto_total = @Balance_Actual - @Cantidad * @Costo_Unitario
where Inventario.Id_invetario = @Id_Inventario
go

create trigger Tr_Aumentar_Producto_Inventario
on Detalle_Venta for update
as
set nocount on
declare @Id_Inventario int
declare @Cantidad int
declare @Stock_Actual int 
declare @Costo_Unitario decimal(12,2)
declare @Monto_Total decimal(12,2)
declare @Balance_Actual decimal(12,2)
select @Id_Inventario = Id_Productos, @Cantidad = Cantidad from inserted
select @Stock_Actual = Cantidad, @Costo_Unitario = Costo_unitario, @Balance_Actual = Monto_total from Inventario where Id_invetario = @Id_Inventario
update Inventario set Inventario.Cantidad = @Stock_Actual + @Cantidad, Inventario.Monto_total = @Balance_Actual + @Cantidad * @Costo_Unitario
where Inventario.Id_invetario = @Id_Inventario
go

--MOSTRAR DETALLE DE LAS VENTAS----
create proc Mostrar_Detalle_Ventas
@Id_Venta int
as
select DV.Id_Detalle, P.Nombre, DV.Presentacion, DV.Cantidad, DV.Precio_Venta,DV.Descuento, DV.Iva,
 (DV.Cantidad * DV.Precio_Venta) as 'Sub Total'
from Detalle_Venta DV inner join Productos P
on DV.Id_Productos = P.Id_Productos
where DV.Id_Venta = @Id_Venta
go


-- MOSTRA VENTAS --
create proc MostrarVentas
as
select V.Id_Venta, V.No_Factura, C.Nombre, V.Fecha_Venta, V.Fecha_Validez, V.Comprobante, V.Sub_Total, V.Descuento, V.Iva, V.Monto_Total,
Us.Usuario, V.Estado
from Ventas V 
inner join Clientes C on V.Id_Cliente = C.Id_Cliente
inner join Usuarios Us on V.Id_Usuario = Us.Id_Usuario
go


--BUSCAR VENTAS CLIENTE --
create proc BuscarVentaCliente
@Buscar nvarchar(100)
as
select C.Nombre, V.No_Factura, V.Fecha_Venta, V.Fecha_Validez, V.Comprobante, V.Sub_Total, V.Descuento, V.Iva, V.Monto_Total,
Us.Usuario
from Ventas V 
inner join Clientes C on V.Id_Cliente = C.Id_Cliente
inner join Usuarios Us on V.Id_Usuario = Us.Id_Usuario
where C.Nombre like @Buscar + '%'
go


--BUSCAR VENTAS COMPROBANTE --
create proc BuscarVentaComprobante
@Buscar nvarchar(100)
as
select C.Nombre, V.No_Factura, V.Fecha_Venta, V.Fecha_Validez, V.Comprobante, V.Sub_Total, V.Descuento, V.Iva, V.Monto_Total,
Us.Usuario
from Ventas V 
inner join Clientes C on V.Id_Cliente = C.Id_Cliente
inner join Usuarios Us on V.Id_Usuario = Us.Id_Usuario
where Comprobante like @Buscar + '%'
go

--MOSTRAR VENTAS PRODUCTO
create proc MostrarVentaProducto
@Id_Venta int
as
select V.No_Factura, V.Fecha_Venta, V.Fecha_Validez, V.Comprobante, V.Sub_Total as 'Sub Total', V.Descuento, V.Iva,
V.Monto_Total, V.Estado, Us.Usuario, Dvent.Presentacion, Dvent.Cantidad,
Dvent.Precio_Venta as 'Precio', Dvent.Sub_Total as 'Importe', Dvent.Descuento, Dvent.Iva, Dvent.Monto_Total as 'Total',
Cli.Nombre as 'Nombre Cliente', Cli.Cedula, Cli.Direccion
from Ventas V inner join Detalle_Venta Dvent
on V.Id_Venta = Dvent.Id_Venta
inner join Productos Pro on Dvent.Id_Productos = Pro.Id_Productos
inner join Clientes Cli on V.Id_Cliente = Cli.Id_Cliente
inner join Usuarios Us on V.Id_Usuario = Us.Id_Usuario
where V.Id_Venta = @Id_Venta
go


-- MOSTRA DETALLE DE INGRESO --
create proc MostrarDetalleIngreso
@Id_Ingreso int
as
select Det.Id_Detalle, Det.Id_Ingreso, Det.Id_Productos, Pro.Nombre, Det.Cantidad, Det.Costo_Unitario,
(Det.Cantidad * Det.Costo_Unitario) as 'Sub Total'
from Detalle_Ingreso Det inner join Productos Pro on Det.Id_Productos = Pro.Id_Productos
where Id_Ingreso = @Id_Ingreso
go

-------------------------------------------------------------------
------------------PROCEDIMIENTOS TIPOS DE COMPROBANTES ---------

 --AGREGAR TIPOS DE COMPROBANTES --
create proc AgregarTipoComprobante
@Nombre varchar(50),
@Tipo_Comprobante varchar(4),
@Correlativo int
as 
insert into Tipos_Comprobante (Nombre_Comprobante, Tipo_Comprobante, Correlativo)
values (@Nombre, @Tipo_Comprobante, @Correlativo)
go

 --EDITAR TIPOS DE COMPROBANTES --
create proc EditarTipoComprobante
@Id_Comprobante int,
@Nombre varchar(50),
@Tipo_Comprobante varchar(4),
@Correlativo int
as 
update Tipos_Comprobante set Nombre_Comprobante = @Nombre, Tipo_Comprobante = @Tipo_Comprobante,
Correlativo = @Correlativo where Id_Comprobante = @Id_Comprobante
go

--EDITAR COMPROBANTE--
Create Proc ActualizarComprobante
@Id_Comprobante int,
@Correlativo int
as
Update Tipos_Comprobante Set Correlativo=@Correlativo Where Id_Comprobante=@Id_Comprobante
go



-------------------------------------------
create proc SP_Mostrar_Factura
@Id_Venta int
as
select Cli.Nombre, Cli.Direccion, Vent.No_Factura, Vent.Fecha_Venta, Tip.Nombre_Comprobante as 'Tipo de Comprobante', Vent.Comprobante,
Vent.Sub_Total, Vent.Iva, Vent.Monto_Total, Vent.Estado, (Us.Nombre +' '+ Us.Apellidos) as Usuario,
pro.Nombre as 'Descripcion', Dvent.Presentacion as 'Presentacion', Dvent.Cantidad,
Dvent.Precio_Venta, Dvent.Descuento, Dvent.Iva, Dvent.Monto_Total as 'Total'
from Ventas Vent inner join Detalle_Venta Dvent on Vent.Id_Venta = Dvent.Id_Venta
inner join Clientes Cli on Vent.Id_Cliente = Cli.Id_Cliente
inner join Productos Pro on Dvent.Id_Productos = Pro.Id_Productos
inner join Usuarios Us on Vent.Id_Usuario = Us.Id_Usuario
cross join Tipos_Comprobante Tip
where Vent.Id_Venta = @Id_Venta
go

----------------------PROCEDIMIENTO PARA USUARIOS-------------------
create proc SP_Agregar_Usuario
@Nombre varchar(50),
@Apellidos varchar(50),
@Usuario varchar(30),
@Password varchar(20)
as
insert into Usuarios (Nombre, Apellidos, Usuario, Password)
values (@Nombre, @Apellidos, @Usuario, @Password)
go

create proc SP_Editar_Usuario
@Id_Usuario int,
@Nombre varchar(50),
@Apellidos varchar(50),
@Usuario varchar(30),
@Password varchar(20)
as
update Usuarios set Nombre = @Nombre, Apellidos = @Apellidos, Usuario = @Usuario, Password = @Password
where Id_Usuario = @Id_Usuario
go


create proc SP_Eliminar_Usuario
@Id_Usuario int
as
delete from Usuarios where Id_Usuario = @Id_Usuario
go

create proc SP_Login
as
select * from Usuarios
go

Create Proc Buscar_Producto_por_CodigoBarra
@xTBox varchar(50)
as
Select Pro.*,Inv.Cantidad From Productos Pro inner join Inventario Inv on
Pro.Id_Productos=Inv.Id_invetario
Where CodigoBarra=@xTBox
go

create proc Buscar_inventario_nombre
@Buscar nvarchar(100)
as
select inv.Codigo, inv.Nombre, inv.Cantidad, inv.Costo_unitario, inv.Precio_venta, inv.Monto_total, inv.Tipo_cargo
from Inventario inv 
where inv.Nombre like @Buscar + '%'
go

exec Buscar_inventario_nombre 'cigarrillo'