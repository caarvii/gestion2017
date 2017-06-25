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

create procedure GARBAGE.getViajesNoRendidos(@chof_id int, @turno_id int, @fecha datetime)
as
begin
	select *
	from GARBAGE.Viaje
	where viaje_chof_id = @chof_id and viaje_turno_id = @turno_id and 
	YEAR(@fecha) = YEAR(fecha_hora_ini) and MONTH(@fecha) = MONTH(fecha_hora_ini) and DAY(@fecha) = DAY(fecha_hora_fin) and 
	YEAR(@fecha) = YEAR(fecha_hora_fin) and MONTH(@fecha) = MONTH(fecha_hora_fin) and DAY(@fecha) = DAY(fecha_hora_fin) and
	viaje_rendido = 1 --TODO change to 0
end


--exec GARBAGE.getViajesNoRendidos '32', '2', '2015-11-13 01:00:00.000'

--drop procedure GARBAGE.getViajesNoRendidos;
--drop procedure GARBAGE.getTurnosViajesByChofer