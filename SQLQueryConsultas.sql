
--Obtener la lista de precios de todos los productos
select nombre as Producto, precio from producto

--Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)
select Nombre as Producto, Cantidad from Producto
where Producto.Cantidad <= 5

-- Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000
select Nombre, Apellido, Cedula from Cliente
Join Factura on Factura.ClienteId = ClienteId
where (Factura.Creado BETWEEN '2000/02/01' AND '2000/05/25') 
and Cliente.Edad <= 35 

--Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar en qué fecha podría volver a comprar.
select Nombre, Apellido, Cedula ,FechaUltimaCompra, DATEADD(DAY,FrecuenciaCompra,FechaUltimaCompra) as 'fecha estimada proxima compra'  from Cliente
where Cliente.Id = 1