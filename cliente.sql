create procedure GARBAGE.getClientes
as
begin
	(select * from GARBAGE.Cliente)
end
go

create procedure GARBAGE.getClienteById(@cli_id int)
as
begin
	(select * from GARBAGE.Cliente where cli_id = @cli_id)
end
go

create procedure GARBAGE.bajaLogicaCliente(@cli_id int)
as
begin
	
	update GARBAGE.Cliente set cli_activo = 0
	where cli_id = @cli_id;
	RETURN 1

end
go

create procedure GARBAGE.altaCliente(
            @cli_nombre varchar(255),
            @cli_apellido varchar(255),
            @cli_dni numeric (18,0),
            @cli_mail varchar(255),
            @cli_telefono numeric (18,0),
			@cli_direccion varchar(255),
			@cli_cp numeric (18,0) ,
            @cli_fecha_nacimiento datetime
			)
as
begin

	declare @error_message nvarchar(255);
	declare @cant int;
	declare @user_id int;
	declare @nombre_sugerido varchar(25);
	declare @id_rol_cliente int;

	set @cant = (SELECT COUNT (*) FROM GARBAGE.Cliente WHERE cli_telefono = @cli_telefono);
	
	if  @cant > 0 BEGIN
		set @error_message = 'El cliente ya existe';
		throw 50000, @error_message , 1;
		
	END

	SET @nombre_sugerido = GARBAGE.DevolverUsuarioValido(@cli_nombre , @cli_apellido)

	IF (@nombre_sugerido = 'NADA') BEGIN
		SET @nombre_sugerido = GARBAGE.GenerarUsuario(@cli_nombre , @cli_apellido)
	END


		-- Podria volver a agregarse en un futuro

	SET @id_rol_cliente = (select rol_id from GARBAGE.Rol WHERE rol_nombre = 'Cliente');


	-- ROL INHABILITADO
	IF ( (SELECT COUNT(*) FROM GARBAGE.Rol WHERE rol_id = @id_rol_cliente AND rol_activo = 0) > 0 ) BEGIN
	
		set @error_message = 'No se puede crear un cliente con un rol inactivo';
		throw 70000, @error_message , 1;

	END 

	-- Inserta tambien en tabla Usuario

	INSERT INTO GARBAGE.Usuario (usu_username,usu_password)
	VALUES (@nombre_sugerido, HASHBYTES('SHA2_256',GARBAGE.GenerarUsuario(@cli_nombre , @cli_apellido)))

	SET @user_id = scope_identity();

		-- INSERTA EN TABLA ROL_POR_USUARIO ( AL SER VALIDO ) 

	INSERT INTO GARBAGE.RolxUsuario (rol_usu_rol_id , rol_usu_usu_id)
	VALUES (@id_rol_cliente , @user_id)

	insert into GARBAGE.Cliente(cli_nombre,
							   cli_apellido,
							   cli_dni,
							   cli_mail,
							   cli_telefono,
							   cli_direccion,
							   cli_fecha_nacimiento,
							   cli_usu_id,
							   cli_activo,
							   cli_cp
							   )
	values (  @cli_nombre,
			  @cli_apellido,
			  @cli_dni, 
			  @cli_mail,
			  @cli_telefono,
			  @cli_direccion,
			  @cli_fecha_nacimiento,
			  @user_id,
			  1,
			  @cli_cp)

	RETURN 1
END
GO

create procedure GARBAGE.updateCliente(
			@cli_id numeric(18,0),
            @cli_nombre varchar(255),
            @cli_apellido varchar(255),
            @cli_dni numeric (18,0),
            @cli_mail varchar(255),
            @cli_telefono numeric (18,0),
			@cli_direccion varchar(255),
			@cli_cp numeric (18,0) ,
            @cli_fecha_nacimiento datetime ,
			@cli_activo bit
			)
as
begin

	declare @error_message nvarchar(255);
	declare @cant int;

	set @cant = (select COUNT(*) from GARBAGE.Cliente where cli_id = @cli_id );

	if  @cant = 0 BEGIN
		set @error_message = 'El chofer no existe';
		throw 50000, @error_message , 1;
	END

	-- Nota: No se actualiza el usuario.

	update GARBAGE.Cliente set cli_nombre = @cli_nombre,
							  cli_apellido = @cli_apellido,
							  cli_dni = @cli_dni,
							  cli_telefono = @cli_telefono,
							  cli_direccion = @cli_direccion,
							  cli_fecha_nacimiento = @cli_fecha_nacimiento,
							  cli_mail = @cli_mail,
							  cli_activo = @cli_activo,
							  cli_cp = @cli_cp
	where cli_id = @cli_id;

	RETURN 1

end
go


drop procedure GARBAGE.getClientes;
drop procedure GARBAGE.getClienteById;
drop procedure GARBAGE.bajaLogicaCliente;
drop procedure GARBAGE.altaCliente;
drop procedure GARBAGE.updateCliente;