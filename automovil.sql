create procedure GARBAGE.getModelosListByMarca(@marca_id int)
as
begin
	(select * from GARBAGE.Automovil where auto_marca_id = @marca_id)
end
go

create procedure GARBAGE.getAutomoviles
as begin
	(select auto_id,auto_marca_id,marca_nombre,auto_mod_id,mod_nombre,auto_patente,auto_licencia,auto_rodado
	FROM GARBAGE.Automovil,GARBAGE.Marca,GARBAGE.Modelo
	WHERE auto_marca_id=marca_id and auto_mod_id = mod_id)
END
go


create procedure GARBAGE.altaAutomovil(
            @auto_marca_id int,
            @auto_modelo_id int,
            @auto_patente varchar(10),
            @auto_licencia varchar(26),
            @auto_rodado varchar(10),
            @auto_turno_id int,
            @auto_chofer_id int)
as
begin
declare @error_message_patente nvarchar(255)
declare @cant_patente int

declare @error_message_chofer nvarchar(255)
declare @cant_chofer int

set @cant_patente = (SELECT COUNT (*) FROM GARBAGE.Automovil WHERE auto_patente=@auto_patente);
set @cant_chofer = (SELECT COUNT (*) FROM GARBAGE.ChoferxAutomovil WHERE chof_auto_chof_id=@auto_chofer_id AND chof_auto_habilitado = 1);

/*
IF  (@cant_patente > 0) BEGIN
		set @error_message_patente = 'Ya existe autmomovil registrado con esa patente';
		throw 50000, @error_message_patente , 1; 
END
	
IF  (@cant_chofer > 0) BEGIN
		set @error_message_patente = 'El chofer seleccionado ya esta asignado a un automovil habilitado';
		throw 60000, @error_message_chofer , 1; 
END
ELSE
*/
insert into GARBAGE.Automovil(auto_marca_id,auto_mod_id,auto_patente,auto_licencia,auto_rodado,auto_activo)
		values (@auto_marca_id,@auto_modelo_id,@auto_patente,@auto_licencia,@auto_rodado, 1)


declare @auto_id int
SET @auto_id = (SELECT auto_id FROM GARBAGE.Automovil 
				WHERE auto_marca_id=@auto_marca_id AND auto_mod_id=@auto_modelo_id AND auto_patente=@auto_patente AND auto_licencia=@auto_licencia AND auto_rodado=@auto_rodado);


declare @cant_chofer_en_tabla_ChoferxAutomovil int
SET @cant_chofer_en_tabla_ChoferxAutomovil = (SELECT COUNT(*) FROM ChoferxAutomovil WHERE chof_auto_chof_id=@auto_chofer_id AND chof_auto_auto_id=@auto_id);


--si ya existe una linea con el chofer en la tabla la updateo, si no, inserto el chofer

if (@cant_chofer_en_tabla_ChoferxAutomovil>0) begin
update GARBAGE.ChoferxAutomovil set chof_auto_habilitado=1
where chof_auto_chof_id=@auto_chofer_id AND chof_auto_auto_id=@auto_id
end
ELSE begin
insert into GARBAGE.ChoferxAutomovil(chof_auto_chof_id,chof_auto_auto_id,chof_auto_habilitado)
		values (@auto_chofer_id,@auto_id,1)
end

insert into GARBAGE.TurnoxAutomovil (turno_auto_turno_id,turno_auto_auto_id)
		values (@auto_turno_id,@auto_id)
		
END
RETURN 1
