create procedure GARBAGE.getAutomoviles
as begin
	(select auto_id,auto_marca_id,marca_nombre,auto_mod_id,mod_nombre,auto_patente,auto_licencia,auto_rodado
	FROM GARBAGE.Automovil,GARBAGE.Marca,GARBAGE.Modelo
	WHERE auto_marca_id=marca_id and auto_mod_id = mod_id)
END
go

exec GARBAGE.getAutomoviles;

drop procedure GARBAGE.getAutomoviles