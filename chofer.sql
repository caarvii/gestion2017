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

create procedure GARBAGE.bajaLogicaChofer(@chof_id int)
as
begin
	
	update GARBAGE.Chofer set chof_activo = 0
	where chof_id = @chof_id;
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
            @chof_fecha_nacimiento datetime
			)
as
begin

	declare @error_message nvarchar(255);
	declare @cant int;
	declare @user_id int;
	declare @nombre_sugerido varchar(25);
	declare @id_rol_chofer int;


	set @cant = (SELECT COUNT (*) FROM GARBAGE.Chofer WHERE chof_telefono=@chof_telefono);
	
	if  @cant > 0 BEGIN
		set @error_message = 'El chofer ya existe';
		throw 50000, @error_message , 1;
		
	END

	SET @nombre_sugerido = GARBAGE.DevolverUsuarioValido(@chof_nombre , @chof_apellido)

	IF (@nombre_sugerido = 'NADA') BEGIN
		SET @nombre_sugerido = GARBAGE.GenerarUsuario(@chof_nombre , @chof_apellido)
	END

	-- Podria volver a agregarse en un futuro

	SET @id_rol_chofer = (select rol_id from GARBAGE.Rol WHERE rol_nombre = 'Chofer');


	-- ROL INHABILITADO
	IF ( (SELECT COUNT(*) FROM GARBAGE.Rol WHERE rol_id = @id_rol_chofer AND rol_activo = 0) > 0 ) BEGIN
	
		set @error_message = 'No se puede crear un chofer con un rol inactivo';
		throw 70000, @error_message , 1;

	END 

	-- INSERTA EN TABLA USUARIO

	INSERT INTO GARBAGE.Usuario (usu_username,usu_password)
	VALUES (@nombre_sugerido, HASHBYTES('SHA2_256',GARBAGE.GenerarUsuario(@chof_nombre , @chof_apellido)))

	SET @user_id = scope_identity();

	-- INSERTA EN TABLA ROL_POR_USUARIO ( AL SER VALIDO ) 

	INSERT INTO GARBAGE.RolxUsuario (rol_usu_rol_id , rol_usu_usu_id)
	VALUES (@id_rol_chofer , @user_id)

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
			  @chof_fecha_nacimiento,
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
            @chof_fecha_nacimiento datetime ,
			@chof_activo bit
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
							  chof_fecha_nacimiento = @chof_fecha_nacimiento,
							  chof_mail = @chof_mail,
							  chof_activo = @chof_activo
	where chof_id = @chof_id;

	RETURN 1

end
go

create function GARBAGE.DevolverUsuarioValido(@nombre varchar(255), @apellido varchar(255))
returns varchar(25)
AS BEGIN
	
	DECLARE @cant int;
	DECLARE @usuario_sugerido varchar(25);
	DECLARE @usu_id int;

	SET @cant = (SELECT COUNT(*) FROM GARBAGE.Usuario WHERE usu_username LIKE GARBAGE.GenerarUsuario( @nombre , @apellido) + '%') ;
	
	IF (@cant = 0) BEGIN
		SET @usuario_sugerido = 'NADA'

	END
	ELSE BEGIN

		SET @usuario_sugerido = CONCAT ( GARBAGE.GenerarUsuario(@nombre , @apellido), @cant )

	END

	RETURN @usuario_sugerido 

END
go

drop procedure GARBAGE.getChoferes;
drop procedure GARBAGE.getChoferById;
drop procedure GARBAGE.bajaLogicaChofer;
drop procedure GARBAGE.altaChofer;
drop procedure GARBAGE.updateChofer;
drop function GARBAGE.DevolverUsuarioValido;