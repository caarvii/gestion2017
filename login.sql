create procedure GARBAGE.Login(@username nvarchar(255), @password char(64)) 
as
begin
	declare @usu_id int
	declare @usu_username nvarchar(255)
	declare @usu_password char(32)
	declare @usu_activo bit
	declare @usu_intentos int
	--Busqueda de usuario
	select @usu_id = usu_id, @usu_username = usu_username, @usu_password = usu_password, 
			@usu_activo = usu_activo, @usu_intentos = usu_intentos
	from GARBAGE.Usuario
	where usu_username = @username
	
	IF @usu_username IS NULL BEGIN
		raiserror('No existe ningun usuario con ese username.', 11, 1)
		RETURN -1 
	END
	-- 
	IF @usu_activo = 0 BEGIN
		raiserror('El usuario se encuentra desahabilitado',16,1)
		RETURN -2
	END
	--Caso de contrasenia incorrecta
	IF @usu_password = @password BEGIN
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
		SET @usu_intentos = 0
		where usu_id = @usu_id
		RETURN @usu_id
	END
	
end