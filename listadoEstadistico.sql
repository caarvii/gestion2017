/* Funcion para saber numero del trimestre */

IF EXISTS (SELECT name FROM sysobjects WHERE name='calcular_trimestre' AND type in ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION calcular_trimestre
go
CREATE FUNCTION calcular_trimestre(@fecha datetime)
returns int
	
begin
	declare @respuesta int;

	set @respuesta = case
		when month(@fecha) IN (1, 2, 3) then 1
		when month(@fecha) IN (4, 5, 6) then 2
		when month(@fecha) IN (7, 8, 9) then 3
		when month(@fecha) IN (10, 11, 12) then 4
		end

return @respuesta
end

/* Choferes con mayor recaudacion */

go
IF EXISTS (SELECT name FROM sysobjects WHERE name='choferes_mayor_recaudacion' AND type='p')
DROP PROCEDURE choferes_mayor_recaudacion

go
CREATE PROCEDURE choferes_mayor_recaudacion(@trimestre int, @anio int)
AS
BEGIN
	select top 5 chof_id, chof_nombre, chof_dni, sum(item_fac_costo) as total_recaudado
	from GARBAGE.Chofer join GARBAGE.Viaje on chof_id = viaje_chof_id join GARBAGE.ItemxFactura on item_fac_viaje_id = viaje_id
	where YEAR(fecha_hora_ini) = @anio and dbo.calcular_trimestre(fecha_hora_ini) = @trimestre
	group by chof_id, chof_nombre, chof_dni
	order by sum(item_fac_costo) desc
END

go
EXECUTE dbo.choferes_mayor_recaudacion @trimestre = 1, @anio = 2015;

/* Choferes con viaje mas largo realizado */

IF EXISTS (SELECT name FROM sysobjects WHERE name='choferes_viaje_mas_largo' AND type='p')
DROP PROCEDURE choferes_viaje_mas_largo
go
CREATE PROCEDURE choferes_viaje_mas_largo(@trimestre int, @anio int)
AS
BEGIN

	select top 5 chof_id, chof_nombre, chof_dni, (select top 1 viaje_cant_km
												  from GARBAGE.Viaje V2
												  where v2.viaje_chof_id = C.chof_id
												  order by viaje_cant_km desc) as  viaje_mas_largo
	from GARBAGE.Chofer C join GARBAGE.Viaje V on viaje_chof_id = chof_id
	where YEAR(fecha_hora_ini) = @anio and dbo.calcular_trimestre(fecha_hora_ini) = @trimestre
	group by chof_id, chof_nombre, chof_dni
	order by sum(viaje_cant_km) desc

END

execute choferes_viaje_mas_largo @trimestre = 2, @anio = 2015;

/* Clientes con mayor consumo */ 

go
IF EXISTS (SELECT name FROM sysobjects WHERE name='clientes_mayor_consumo' AND type='p')
DROP PROCEDURE clientes_mayor_consumo
go
CREATE PROCEDURE clientes_mayor_consumo(@trimestre int, @anio int)
AS
BEGIN

	select top 5 cli_id, cli_nombre, cli_apellido, sum(fact_total) as total_cliente, sum(fact_cant_viajes) as cant_viajes
	from GARBAGE.Cliente join GARBAGE.Factura on fact_cli_id = cli_id
	where YEAR(fact_fecha_ini) = @anio and dbo.calcular_trimestre(fact_fecha_ini) = @trimestre
	group by cli_id, cli_nombre, cli_apellido
	order by sum(fact_total) desc
	
END

execute clientes_mayor_consumo @trimestre = 3, @anio = 2015;

/* Cliente que utilizo mas veces el mismo automovil en los viajes que realizo */

go
IF EXISTS (SELECT name FROM sysobjects WHERE name='clientes_mismo_auto' AND type='p')
DROP PROCEDURE clientes_mismo_auto
go
CREATE PROCEDURE clientes_mismo_auto(@trimestre int, @anio int)
AS
BEGIN

	select top 5 cli_id, cli_nombre, cli_apellido, cli_dni, auto_id, auto_patente, count(viaje_id) as cantidad_viajes
	from GARBAGE.Cliente join GARBAGE.Viaje on viaje_cli_id = cli_id join GARBAGE.Automovil on viaje_auto_id = auto_id
	where YEAR(fecha_hora_ini) = @anio and dbo.calcular_trimestre(fecha_hora_ini) = @trimestre
	group by cli_id, cli_nombre, cli_apellido, cli_dni, auto_id, auto_patente
	order by cantidad_viajes desc
	
END

execute clientes_mismo_auto @trimestre = 1, @anio = 2015;