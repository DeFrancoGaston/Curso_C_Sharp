/***Clase 10:				***/
--Ejercicio 1
Select Nombre, Apellido, NombreUsuario, Contraseña, Mail
  From Usuario
 Where NombreUsuario = 'tcasazza'

 --Ejercicio 2
Declare @NombreUsuario Varchar(20), @Contraseña Varchar(20)
Set @NombreUsuario = 'tcasazza'
Set @Contraseña = 'SoyTobiasCasazza'

Select Nombre, Apellido, NombreUsuario, Contraseña, Mail
  From Usuario
 Where NombreUsuario = @NombreUsuario
 And   Contraseña = @Contraseña

 --Ejercicio 3
Select Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario
  From Producto
 Where IdUsuario = 1

--Ejercicio 4
Insert Into Usuario
(Nombre, Apellido, NombreUsuario, Contraseña, Mail)
Values
('Gastón', 'De Franco', 'gdefranco', '12345678', 'gastondefranco@gmail.com')

--Ejercicio 5
Insert Into Producto
(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
Values
('Zapatilla', 2000, 5000, 10, 3)

Insert Into Producto
(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
Values
('Medias', 200, 500, 20, 3)

Insert Into Producto
(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
Values
('Guantes', 800, 1600, 30, 3)

Insert Into Producto
(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
Values
('Calza', 3000, 6000, 50, 3)

Insert Into Producto
(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
Values
('Ojotas', 700, 3600, 40, 3)

/***Clase 11:				***/
--Ejercicio 1
Update Usuario
   Set Contraseña = '12345678'
 Where Nombre = 'Tobias'

--Ejercicio 2
Delete From Usuario Where Apellido = 'Perez'

--Ejercicio 3
Update Producto
   Set Stock = 0
 Where Id = 6 -- 6 - Buzo

 --Ejercicio 4
Delete From Producto Where Descripciones = 'Musculosa'

--Ejercicio 5
Select PRO.Descripciones, USU.Apellido, USU.Nombre
  From Producto PRO
  Inner Join Usuario USU
  On PRO.IdUsuario = USU.Id

/*** Desafio Entregable 2				***/
--Ejercicio 1
Select VTA.Id As Nro_Venta,
       VEN.Id As Item,
	   VEN.Stock,
	   PRO.Descripciones,
	   PRO.PrecioVenta
  From Venta VTA
  Inner Join ProductoVendido VEN
  On VEN.IdVenta = VTA.Id
  Inner Join Producto PRO
  On PRO.Id = VEN.IdProducto

--Ejercicio 2
Select VTA.Id As Nro_Venta,
       VEN.Id As Item,
	   VEN.Stock,
	   PRO.Descripciones,
	   PRO.PrecioVenta
  From Venta VTA
  Inner Join ProductoVendido VEN
  On VEN.IdVenta = VTA.Id
  Inner Join Producto PRO
  On PRO.Id = VEN.IdProducto
Where PRO.PrecioVenta > 10000
And   PRO.Descripciones Like '%ina'

--Ejercicio 2'
Select VTA.Id As Nro_Venta,
       VEN.Id As Item,
	   VEN.Stock,
	   PRO.Descripciones,
	   PRO.PrecioVenta,
	   NombreUsuario
  From Venta VTA
  Inner Join ProductoVendido VEN
  On VEN.IdVenta = VTA.Id
  Inner Join Producto PRO
  On PRO.Id = VEN.IdProducto
  Inner Join Usuario USU
  On USU.Id = PRO.IdUsuario
Where PRO.PrecioVenta > 2000
And   USU.NombreUsuario Like '%azza'

--Ejercicio 3
Insert Into Producto
(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
Values
('Aceite de Girasol Cocinera', 350, 500, 30, 3)

Insert Into Venta (Comentarios) Values('Ejecicio de Venta')

Declare @IdProducto numeric(7), @IdVenta numeric(7)
Select @IdVenta = Max(id)
  From Venta

Select @IdProducto = Id
  From Producto
 Where Producto.Descripciones = 'Aceite de Girasol Cocinera'

Insert Into ProductoVendido (Stock, IdProducto, IdVenta) Values(20, @IdProducto, @IdVenta)
