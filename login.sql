create procedure GARBAGE.Login(@username nvarchar(255), @password varbinary(64)) 
as
begin
	declare @usu_id int
	declare @usu_username nvarchar(255)
	declare @usu_password varbinary(64)
	declare @usu_activo bit
	declare @usu_intentos int

	declare @error_message nvarchar(255)

	--Busqueda de usuario
	select @usu_id = usu_id, @usu_username = usu_username, @usu_password = usu_password, 
			@usu_activo = usu_activo, @usu_intentos = usu_intentos
	from GARBAGE.Usuario
	where usu_username = @username
	
	IF @usu_username IS NULL BEGIN
		set @error_message = 'No existe ningun usuario con ese username ' + @username
		raiserror(@error_message, 11, 1)
		RETURN -1 
	END
	-- 
	IF @usu_activo = 0 BEGIN
		set @error_message = 'El usuario' + @username + 'se encuentra desahabilitado'
		raiserror(@error_message, 16, 1)
		RETURN -2
	END
	--Caso de contrasenia incorrecta
	IF @usu_password <> @password BEGIN
		SET @usu_intentos= @usu_intentos + 1
		IF  @usu_intentos = 3 
		BEGIN	--Si el usuario llega al max de intentos
			SET @usu_activo = 0		--queda deshabilitado
			SET @usu_intentos = 0 
		END
		UPDATE GARBAGE.Usuario
		SET usu_intentos = @usu_intentos, usu_activo = @usu_activo
		where usu_id = @usu_id
		raiserror('Contrasenia incorrecta',16,1)
		RETURN -3 
	END
	
	IF @usu_password = @password BEGIN
		UPDATE GARBAGE.Usuario
		SET usu_intentos = 0
		where usu_id = @usu_id
		RETURN @usu_id
	END
	
end
go

create procedure GARBAGE.getRolListByUserId(@user_id int)
as 
begin 
	(select R.rol_id, R.rol_nombre, R.rol_activo 
		from GARBAGE.Rol R 
		join GARBAGE.RolxUsuario RU ON R.rol_id = RU.rol_usu_rol_id and RU.rol_usu_usu_id = @user_id)
end
go

create procedure GARBAGE.getFuncionalidadListByRolId(@rol_id int)
as
begin
	(select F.func_id, F.func_descripcion 
		from GARBAGE.Funcionalidad F 
        JOIN GARBAGE.FuncionalidadxRol RF ON RF.func_rol_func_id = F.func_id AND RF.func_rol_rol_id = @rol_id)
end