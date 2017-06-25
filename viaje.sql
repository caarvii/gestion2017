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

	
	-- validar viajes duplicados , etc.



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



drop procedure GARBAGE.getTurnosByAutoId;
drop procedure GARBAGE.getAutomovilDisponible;
drop procedure GARBAGE.altaViaje;