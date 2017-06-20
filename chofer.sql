create procedure GARBAGE.getChoferes
as
begin
	(select * from GARBAGE.Chofer)
end
go

create procedure GARBAGE.getChoferById(@chofer_id int)
as
begin
	(select * from GARBAGE.Chofer where chof_id = @chofer_id)
end
go

create procedure GARBAGE.bajaLogicaChofer(@chofer_id int)
as
begin
	
	update GARBAGE.Chofer set chof_activo = 0
	where chof_id = @chofer_id;
	RETURN 1

end
go




create procedure GARBAGE.altaChofer(
            @chof_nombre varchar(255),
            @chof_apellido varchar(255),
            @chof_dni numeric (18,0),
            @chof_mail varchar(255),
            @chof_telefono numeric (18,0),
			@chof_direccion varchar(255),
            @chof_fecha_naciemiento datetime
			)
as
begin

	declare @error_message nvarchar(255);
	declare @cant int;
	declare @user_id int;

	set @cant = (SELECT COUNT (*) FROM GARBAGE.Chofer WHERE chof_telefono=@chof_telefono);
	
	if  @cant > 0 BEGIN
		set @error_message = 'El chofer ya existe';
		throw 50000, @error_message , 1;
		
	END

	-- TRIGGER DE CHOFER

	-- AQUI

	insert into GARBAGE.Chofer(chof_nombre,
							   chof_apellido,
							   chof_dni,
							   chof_mail,
							   chof_telefono,
							   chof_direccion,
							   chof_fecha_nacimiento,
							   chof_usu_id,
							   chof_activo)
	values (  @chof_nombre,
			  @chof_apellido,
			  @chof_dni, 
			  @chof_mail,
			  @chof_telefono,
			  @chof_direccion,
			  @chof_fecha_naciemiento,
			  @user_id,
			  1)

	RETURN 1
END
GO


create procedure GARBAGE.updateChofer(
			@chof_id numeric(18,0),
            @chof_nombre varchar(255),
            @chof_apellido varchar(255),
            @chof_dni numeric (18,0),
            @chof_mail varchar(255),
            @chof_telefono numeric (18,0),
			@chof_direccion varchar(255),
            @chof_fecha_naciemiento datetime ,
			@chof_habilitado bit
			)
as
begin

	declare @error_message nvarchar(255);
	declare @cant int;

	set @cant = (select COUNT(*) from GARBAGE.Chofer where chof_id = @chof_id );

	if  @cant = 0 BEGIN
		set @error_message = 'El chofer no existe';
		throw 50000, @error_message , 1;
	END

	-- Nota: No se actualiza el usuario.

	update GARBAGE.Chofer set chof_nombre = @chof_nombre,
							  chof_apellido = @chof_apellido,
							  chof_dni = @chof_dni,
							  chof_telefono = @chof_telefono,
							  chof_direccion = @chof_direccion,
							  chof_fecha_nacimiento = @chof_fecha_naciemiento,
							  chof_mail = @chof_mail,
							  chof_activo = @chof_habilitado
	where chof_id = @chof_id;

	RETURN 1

end
go



