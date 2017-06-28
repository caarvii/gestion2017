create procedure GARBAGE.getViajesNoFacturados(@fecha datetime, @cli_id int)
as
begin
	select viaje_id, concat(ROW_NUMBER() OVER(ORDER BY fecha_hora_fin ASC), 
	'° viaje inicio ', fecha_hora_ini , ' hasta ' , fecha_hora_fin) as viaje_descripcion,
			cast(turno_precio_base + (turno_valor_km * viaje_cant_km) as numeric(18,2)) as valor_viaje 
	from GARBAGE.Viaje
	join GARBAGE.Turno on turno_id = viaje_turno_id
	where viaje_cli_id = @cli_id and MONTH(@fecha) = MONTH(fecha_hora_fin) and YEAR(@fecha) = YEAR(fecha_hora_fin)
	--and viaje_id not in (select item_fac_viaje_id from GARBAGE.ItemxFactura)
	order by fecha_hora_fin
end
go


if exists (select * from sys.table_types where name ='ItemFacturaType')
    drop type GARBAGE.ItemFacturaType
go

create type GARBAGE.ItemFacturaType as table(
	viaje_id int,
	viaje_desc varchar(255),
	viaje_costo decimal(12,2)
)
go

create procedure GARBAGE.Facturar(@fecha datetime, @cli_id int, @viajes GARBAGE.ItemFacturaType readonly)
as 
begin
	
	if (select count(*) 
		from @viajes
		where viaje_id in (select item_fac_viaje_id from GARBAGE.ItemxFactura)) > 0
		throw 50000, 'No se puede facturar un viaje que ya ha sido facturado previamente', 1;

	insert into GARBAGE.Factura (fact_fecha_ini, fact_fecha_fin, fact_cli_id, fact_total, fact_cant_viajes)
	values (DATEADD(MONTH, DATEDIFF(MONTH, 0, @fecha), 0),
			DATEADD(MONTH, DATEDIFF(MONTH, -1, @fecha), -1), @cli_id, 0, 0)

	declare @fact_id int = scope_identity()

	set identity_insert GARBAGE.ItemxFactura on

	insert into GARBAGE.ItemxFactura (item_fac_fac_id, item_fac_viaje_id, item_fac_descripcion, item_fac_costo)
	select @fact_id, viaje_id, viaje_desc, viaje_costo from @viajes

	set identity_insert GARBAGE.ItemxFactura off

	declare @cantidad_viajes int
	declare @total decimal(12,2)

	select @cantidad_viajes = count(*), @total = sum(viaje_costo)
	from @viajes

	update GARBAGE.Factura set fact_cant_viajes = @cantidad_viajes, fact_total = @total
	where fact_id = @fact_id
end

--exec GARBAGE.getViajesNoFacturados '2015-06-01' , '7'

--drop procedure GARBAGE.getViajesNoFacturados
--drop procedure GARBAGE.Facturar

