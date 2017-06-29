create procedure GARBAGE.getAutomoviles
as begin
	(select auto_id,auto_marca_id,marca_nombre,auto_mod_id,mod_nombre,auto_patente,auto_licencia,auto_rodado,auto_activo , chof_nombre
	FROM GARBAGE.Automovil,GARBAGE.Marca,GARBAGE.Modelo , GARBAGE.Chofer,GARBAGE.ChoferxAutomovil
	WHERE auto_marca_id=marca_id and auto_mod_id = mod_id and auto_id =  chof_auto_auto_id and chof_auto_chof_id=chof_id)
END
go



create procedure GARBAGE.bajaLogicaAutomovil(@auto_id int)
as
begin
update GARBAGE.Automovil set auto_activo=0 where auto_id=@auto_id;
update GARBAGE.ChoferxAutomovil set chof_auto_habilitado = 0 where chof_auto_auto_id=@auto_id;
RETURN 1
end
go



create procedure GARBAGE.getTurnosByAutomovilId (@auto_id int)
as begin
select * FROM GARBAGE.Turno,GARBAGE.TurnoxAutomovil
where @auto_id = turno_auto_auto_id and turno_auto_turno_id=turno_id
end
go




create procedure GARBAGE.getChoferByAutomovilId (@auto_id int)
as begin
select * FROM GARBAGE.Chofer,GARBAGE.ChoferxAutomovil,GARBAGE.Automovil 
where @auto_id = chof_auto_auto_id and chof_auto_chof_id=chof_id
end
go




create procedure GARBAGE.updateAutomovil(
            @auto_marca_id int,
            @auto_modelo_id int,
            @auto_patente varchar(10),
            @auto_licencia varchar(26),
            @auto_rodado varchar(10),
            @auto_chofer_id int,
			@turnos GARBAGE.TurnoType READONLY,
			@auto_id int,
			@auto_activo bit)
as
begin
declare @error_message_patente nvarchar(255)
declare @cant_patente int

declare @error_message_chofer nvarchar(255)
declare @cant_chofer int

set @cant_patente = (SELECT COUNT (*) FROM GARBAGE.Automovil WHERE auto_patente=@auto_patente and auto_id<>@auto_id);
set @cant_chofer = (SELECT COUNT (*) FROM GARBAGE.ChoferxAutomovil WHERE chof_auto_chof_id=@auto_chofer_id AND chof_auto_habilitado = 1 and chof_auto_auto_id<>@auto_id);


IF  (@cant_patente > 0) BEGIN
		set @error_message_patente = 'Ya existe automomovil registrado con esa patente';
		throw 50000, @error_message_patente , 1; 
END

IF  (@cant_chofer > 0) BEGIN
		set @error_message_chofer = 'El chofer seleccionado ya esta asignado a un automovil habilitado';
		throw 60000, @error_message_chofer , 1; 
END
ELSE

update GARBAGE.Automovil set auto_marca_id=@auto_marca_id,auto_mod_id=auto_mod_id,auto_patente=@auto_patente,auto_licencia=auto_licencia,auto_rodado=@auto_rodado,auto_activo=@auto_activo
where auto_id=@auto_id

update GARBAGE.ChoferxAutomovil set chof_auto_habilitado=@auto_activo, chof_auto_chof_id=@auto_chofer_id
where chof_auto_auto_id=@auto_id

delete from GARBAGE.TurnoxAutomovil where turno_auto_auto_id = @auto_id;

insert into GARBAGE.TurnoxAutomovil(turno_auto_auto_id, turno_auto_turno_id) (
		select @auto_id, T.turno_id
		from @turnos as TURNO join GARBAGE.Turno t on TURNO.turnoext_id = T.turno_id);

END
RETURN 1
go


if exists (select * from sys.table_types where name ='TurnoType')
    drop type GARBAGE.TurnoType
go


create type GARBAGE.TurnoType as table(
	turnoext_id int not null
)
go



create procedure GARBAGE.altaAutomovil(
		    @auto_marca_id int,
            @auto_modelo_id int,
            @auto_patente varchar(10),
            @auto_licencia varchar(26),
            @auto_rodado varchar(10),
            @auto_chofer_id int,
			@turnos GARBAGE.TurnoType READONLY)
as
begin
declare @error_message_patente nvarchar(255)
declare @cant_patente int

declare @error_message_chofer nvarchar(255)
declare @cant_chofer int

set @cant_patente = (SELECT COUNT (*) FROM GARBAGE.Automovil WHERE auto_patente=@auto_patente);
set @cant_chofer = (SELECT COUNT (*) FROM GARBAGE.ChoferxAutomovil WHERE chof_auto_chof_id=@auto_chofer_id AND chof_auto_habilitado = 1);


IF  (@cant_patente > 0) BEGIN
		set @error_message_patente = 'Ya existe automomovil registrado con esa patente';
		throw 50000, @error_message_patente , 1; 
END
	
IF  (@cant_chofer > 0) BEGIN
		set @error_message_chofer = 'El chofer seleccionado ya esta asignado a un automovil habilitado';
		throw 60000, @error_message_chofer , 1; 
END
ELSE


insert into GARBAGE.Automovil(auto_marca_id,auto_mod_id,auto_patente,auto_licencia,auto_rodado,auto_activo)
		values (@auto_marca_id,@auto_modelo_id,@auto_patente,@auto_licencia,@auto_rodado, 1)

declare @auto_id int
SET @auto_id = (SELECT auto_id FROM GARBAGE.Automovil 
				WHERE auto_marca_id=@auto_marca_id AND auto_mod_id=@auto_modelo_id AND auto_patente=@auto_patente AND auto_licencia=@auto_licencia AND auto_rodado=@auto_rodado);

insert into GARBAGE.ChoferxAutomovil(chof_auto_chof_id,chof_auto_auto_id,chof_auto_habilitado)
		values (@auto_chofer_id,@auto_id,1)

insert into GARBAGE.TurnoxAutomovil(turno_auto_auto_id, turno_auto_turno_id) (
		select @auto_id, T.turno_id
		from @turnos as TURNO join GARBAGE.Turno t on TURNO.turnoext_id = T.turno_id);

end
RETURN 1