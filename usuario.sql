create procedure GARBAGE.getUsuarioById(@user_id int)
as
begin
	(select * from GARBAGE.Usuario where usu_id = @user_id)
end






----------------------alta cliente----------------------------

create procedure GARBAGE.altaCliente(
            @cli_nombre varchar(255),
            @cli_apellido varchar(255),
            @cli_dni numeric (18,0),
            @cli_mail varchar(255),
            @cli_telefono numeric (18,0),
            @cli_direccion varchar(255),
            @cli_cp numeric (18,0),
            @cli_fechanac varchar(255),
            @usu_usuario nvarchar(25),
            @usu_password char(64))
as
begin
--valido que no exista el cliente

declare @error_message_cliente nvarchar(255)
declare @cant_cliente int
declare @error_message_usuario nvarchar(255)
declare @cant_usuario int

set @cant_cliente = (SELECT COUNT (*) FROM GARBAGE.Cliente WHERE cli_telefono=@cli_telefono);
set @cant_usuario = (SELECT COUNT (*) FROM GARBAGE.Usuario WHERE usu_username=@usu_usuario);


IF  (@cant_cliente > 0) BEGIN
		set @error_message_cliente = 'Ya existe un cliente registrado con ese telefono';
		throw 50000, @error_message_cliente , 1; 
END
ELSE IF (@cant_usuario > 0) BEGIN 
		set @error_message_usuario = 'Ya existe un cliente registrado con ese usuario';
		throw 60000, @error_message_usuario , 1;
END 

ELSE

insert into GARBAGE.Usuario(usu_username,usu_password,usu_activo,usu_intentos)
					values (@usu_usuario,@usu_password,1,0)

declare @cli_usu_id int
set @cli_usu_id = (SELECT usu_id FROM GARBAGE.Usuario WHERE usu_username=@usu_usuario)

insert into GARBAGE.Cliente(cli_nombre,cli_apellido,cli_dni,cli_mail,cli_telefono,cli_direccion,cli_cp,cli_fecha_nacimiento,cli_usu_id,cli_activo)
					values ( @cli_nombre, @cli_apellido, @cli_dni, @cli_mail,@cli_telefono, @cli_direccion, @cli_cp,@cli_fechanac,@cli_usu_id,1)

END
return 1


---------------------------update cliente----------------------


create procedure GARBAGE.updateCliente(
			@cli_id int,
            @cli_nombre varchar(255),
            @cli_apellido varchar(255),
            @cli_dni numeric (18,0),
            @cli_mail varchar(255),
            @cli_telefono numeric (18,0),
            @cli_direccion varchar(255),
            @cli_cp numeric (18,0),
            @cli_fechanac varchar(255))
as
begin
--valido que no exista cliente con mismo telefono

declare @error_message_cliente nvarchar(255)
declare @cant_cliente int


set @cant_cliente = (SELECT COUNT (*) FROM GARBAGE.Cliente WHERE cli_telefono=@cli_telefono AND cli_id<>@cli_id);


IF  (@cant_cliente > 0) BEGIN
		set @error_message_cliente = 'Ya existe un cliente registrado con ese telefono';
		throw 50000, @error_message_cliente , 1; 
END
ELSE 

UPDATE GARBAGE.Cliente set cli_nombre=@cli_nombre
							,cli_apellido=cli_apellido,
							cli_dni=@cli_dni,
							cli_mail=@cli_dni,
							cli_telefono=@cli_telefono,
							cli_direccion=@cli_direccion,
							cli_cp=@cli_cp,
							cli_fecha_nacimiento=@cli_fechanac
WHERE @cli_id=cli_id;

END
return 1



------------------------- baja cliente --------------------------

create procedure GARBAGE.bajaLogicaCliente(@cli_id int)
as
begin
	
	update GARBAGE.Cliente set cli_activo = 0
	where cli_id = @cli_id;
	RETURN 1

end

