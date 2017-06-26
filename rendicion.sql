create procedure GARBAGE.getTurnosViajesByChofer(@chof_id int)
as
begin
	select distinct turno_id, turno_descripcion, turno_hora_inicio, turno_hora_fin, turno_precio_base, turno_valor_km, turno_habilitado
	from GARBAGE.Viaje
	join GARBAGE.Turno on viaje_turno_id = turno_id
	where viaje_chof_id = @chof_id
	order by turno_hora_inicio
end
go

create procedure GARBAGE.getViajesNoRendidos(@chof_id int, @turno_id int, @fecha datetime, @porcentaje_rendicion numeric(3,2))
as
begin

	declare @valorKmTurno numeric(18,2);
	declare @precioBaseTurno numeric(18,2);

	select @valorKmTurno = turno_valor_km, @precioBaseTurno = turno_precio_base from GARBAGE.Turno where turno_id = @turno_id

	select viaje_id, viaje_auto_id, viaje_cli_id, fecha_hora_ini, fecha_hora_fin, viaje_cant_km,
			cast(@precioBaseTurno + (@valorKmTurno * viaje_cant_km)  as numeric(18,2)) as valor_viaje, 
			cast(cast(@precioBaseTurno + (@valorKmTurno * viaje_cant_km)  as numeric(18,2)) 
					* @porcentaje_rendicion as numeric(18,2)) as valor_rendicion
	from GARBAGE.Viaje
	where viaje_chof_id = @chof_id and viaje_turno_id = @turno_id and 
	YEAR(@fecha) = YEAR(fecha_hora_ini) and MONTH(@fecha) = MONTH(fecha_hora_ini) and DAY(@fecha) = DAY(fecha_hora_fin) and 
	YEAR(@fecha) = YEAR(fecha_hora_fin) and MONTH(@fecha) = MONTH(fecha_hora_fin) and DAY(@fecha) = DAY(fecha_hora_fin) and
	viaje_rendido = 0
end

IF EXISTS (SELECT * FROM sys.table_types WHERE name ='ViajeType')
    drop type GARBAGE.ViajeType
GO

create type GARBAGE.ViajeType as table(
	viaje_id int not null
)
go

create procedure GARBAGE.generarRendicion(@chof_id int, @turno_id int, @fecha datetime, 
	@importe_total numeric(12,2), @viajes GARBAGE.ViajeType readonly)
as
begin
	
	if (select count(*) 
		from GARBAGE.Rendicion 
		where rend_fecha_pago = @fecha and rend_turno = @turno_id and rend_chofer = @chof_id) > 0
		throw 50000, 'Ya se ha rendido una rendicion este dia para este chofer en el turno seleccionado', 1;

	insert into GARBAGE.Rendicion (rend_fecha_pago, rend_chofer, rend_turno, rend_importe_total) 
	values (@fecha, @chof_id, @turno_id, @importe_total)

	update GARBAGE.Viaje set viaje_rendido = 1
	from @viajes V
	where V.viaje_id = GARBAGE.Viaje.viaje_id 
	
end

--exec GARBAGE.getViajesNoRendidos '32' ,'2', '2015-11-13', '0.3'

--select * from GARBAGE.Rendicion where  rend_turno = '2' and rend_chofer =  '32' and rend_fecha_pago = '2015-11-13'
--select * from GARBAGE.Viaje where viaje_chof_id = '32' and viaje_turno_id = '2' and fecha_hora_ini = '2015-11-13 00:00:00.000'
--update GARBAGE.Viaje set viaje_rendido = 0 where viaje_chof_id = '32' and viaje_turno_id = '2' 

--drop procedure GARBAGE.getViajesNoRendidos;
--drop procedure GARBAGE.getTurnosViajesByChofer