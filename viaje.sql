create procedure GARBAGE.getAutomovilDisponible(@chof_id int)
as
begin
	
	(SELECT *
	 FROM GARBAGE.Automovil A , GARBAGE.ChoferxAutomovil CA
	 WHERE A.auto_id = CA.chof_auto_auto_id AND
		   CA.chof_auto_chof_id = @chof_id AND
		   CA.chof_auto_habilitado = 1)

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
            @chof_nombre varchar(255),
            @chof_apellido varchar(255),
            @chof_dni numeric (18,0),
            @chof_mail varchar(255),
            @chof_telefono numeric (18,0),
			@chof_direccion varchar(255),
            @chof_fecha_nacimiento datetime
			)
as
begin





end
go



drop procedure GARBAGE.getTurnosByAutoId;
drop procedure GARBAGE.getAutomovilDisponible;
drop procedure GARBAGE.altaViaje;