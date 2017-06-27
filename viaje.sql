create procedure GARBAGE.getAutomovilDisponible(@chof_id int)
as
begin
	
	(SELECT *
	 FROM GARBAGE.Automovil A , GARBAGE.ChoferxAutomovil CA , GARBAGE.Marca,GARBAGE.Modelo
	 WHERE A.auto_id = CA.chof_auto_auto_id AND
		   CA.chof_auto_chof_id = @chof_id AND
		   CA.chof_auto_habilitado = 1 AND 
		   A.auto_marca_id= marca_id AND A.auto_mod_id = mod_id)

end
go

create procedure GARBAGE.getTurnosByAutoId(@auto_id int)
as
begin
	-- Trae los turnos habilitados nomas.
	(SELECT *
	 FROM GARBAGE.Turno T , GARBAGE.TurnoxAutomovil TA
	 WHERE T.turno_id = TA.turno_auto_turno_id AND
			TA.turno_auto_auto_id = @auto_id AND
			T.turno_habilitado = 1)

end
go

create procedure GARBAGE.altaViaje(
            @viaje_auto_id int,
			@viaje_turno_id int,
			@viaje_chof_id int ,
			@viaje_cant_km numeric(18,2) ,
			@fecha_hora_ini datetime ,
			@fecha_hora_fin datetime,
			@viaje_cli_id int
			)
as
begin

	declare @viaje_duplicado int;
	declare @error_message nvarchar(255);
	declare @solapado int;

	
	set @viaje_duplicado = (SELECT COUNT(*) FROM GARBAGE.Viaje WHERE 
														viaje_auto_id = @viaje_auto_id AND
														viaje_turno_id = @viaje_turno_id AND
														viaje_chof_id = @viaje_chof_id AND
														viaje_cant_km = @viaje_cant_km AND
														fecha_hora_ini = @fecha_hora_ini AND
														fecha_hora_fin= @fecha_hora_fin AND
														viaje_cli_id = @viaje_cli_id)
	if  @viaje_duplicado > 0 BEGIN
		set @error_message = 'El viaje ya existe';
		throw 50000, @error_message , 1;
		
	END

	set @solapado = (select COUNT (*) 
					from GARBAGE.Viaje
					where ( ( (fecha_hora_ini <= @fecha_hora_ini AND  fecha_hora_fin >= @fecha_hora_fin) or 
							  (fecha_hora_ini >= @fecha_hora_ini AND fecha_hora_fin > @fecha_hora_fin and @fecha_hora_fin > fecha_hora_ini) or
							  (fecha_hora_ini <= @fecha_hora_ini AND fecha_hora_fin < @fecha_hora_fin and @fecha_hora_ini < fecha_hora_fin) or
							  (fecha_hora_ini >= @fecha_hora_ini AND  fecha_hora_fin <= @fecha_hora_fin) 
							)
						  AND (viaje_cli_id = @viaje_cli_id OR viaje_chof_id = @viaje_chof_id )
						  AND YEAR(@fecha_hora_ini) = YEAR(fecha_hora_ini) and MONTH(@fecha_hora_ini) = MONTH(fecha_hora_ini) and DAY(@fecha_hora_ini) = DAY(fecha_hora_fin)
					))
	
	-- VIAJES SOLAPADOS

	if  @solapado > 0  BEGIN
		set @error_message = 'El viaje no puede agregarse o editarse solapando a otro viaje';
		throw 60000, @error_message , 1;
		
	END


	INSERT INTO GARBAGE.Viaje(	viaje_auto_id
								,viaje_turno_id
								,viaje_chof_id
								,viaje_cant_km
								,fecha_hora_ini
								,fecha_hora_fin
								,viaje_cli_id
								)
	VALUES (
			 @viaje_auto_id
			,@viaje_turno_id
			,@viaje_chof_id
			,@viaje_cant_km 
			,@fecha_hora_ini
			,@fecha_hora_fin
			,@viaje_cli_id
				)

	RETURN 1

end
go

execute GARBAGE.altaViaje '5' , '3' , '1' , '11' , '2017-06-27 18:16:37.000' , '2017-06-27 20:16:37.000', '1'




drop procedure GARBAGE.getTurnosByAutoId;
drop procedure GARBAGE.getAutomovilDisponible;
drop procedure GARBAGE.altaViaje;