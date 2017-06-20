create procedure GARBAGE.getRoles
as
begin
	(select * from GARBAGE.Rol)
end
go

create procedure GARBAGE.getRolById(@rol_id int)
as
begin
	(select * from GARBAGE.Rol where rol_id= @rol_id)
end
go

create procedure GARBAGE.deleteRol(@rol_id int)
as 
begin
	update GARBAGE.Rol set rol_activo = 0 
	where rol_id = @rol_id
end
go

create type GARBAGE.FuncionalidadType as table(
	funcionalidad_id int not null
)
go

create procedure GARBAGE.createRol(@rol_nombre nvarchar(30), @funcionalidades GARBAGE.FuncionalidadType readonly)
as 
begin

	if (select count(*) from GARBAGE.Rol where rol_nombre = @rol_nombre) > 0
		throw 50000, 'Ya existe un rol con ese nombre', 1;

	insert into GARBAGE.Rol(rol_nombre) values (@rol_nombre)
	
	declare @rol_id int
	set @rol_id = scope_identity()

	insert into GARBAGE.FuncionalidadxRol (func_rol_rol_id, func_rol_func_id) (
		select @rol_id, F.func_id
		from @funcionalidades as FUNC
		join GARBAGE.Funcionalidad F on F.func_id = FUNC.funcionalidad_id
	);

end
go


create procedure GARBAGE.updateRol(@rol_id int, @rol_nombre nvarchar(30), @rol_activo bit, 
	@funcionalidades GARBAGE.FuncionalidadType readonly)
as
begin

	update GARBAGE.Rol set rol_nombre = @rol_nombre, rol_activo = @rol_activo
	where rol_id = @rol_id

	delete GARBAGE.FuncionalidadxRol where func_rol_rol_id = @rol_id;

	insert into GARBAGE.FuncionalidadxRol (func_rol_rol_id, func_rol_func_id) (
		select @rol_id, F.func_id
		from @funcionalidades as FUNC
		join GARBAGE.Funcionalidad F on F.func_id = FUNC.funcionalidad_id
	);

end
go

create procedure GARBAGE.bajaLogica(@rol_id int)
as
begin
	update GARBAGE.Rol set rol_activo = 0 
	where rol_id = @rol_id
end
go

create trigger GARBAGE.deleteUsuariosRol
on GARBAGE.Rol instead of update
as
begin

	declare cursor_roles cursor for (select I.rol_id, I.rol_activo from inserted I)

	declare @rol_id int, @rol_activo bit;

	open cursor_roles

	fetch next from cursor_roles into @rol_id, @rol_activo;

	while(@@fetch_status = 0)
	begin
		if(@rol_activo = 0)
		begin
			delete GARBAGE.RolxUsuario where rol_usu_rol_id = @rol_id
		end
		fetch next from cursor_roles into @rol_id, @rol_activo;
	end

	update GARBAGE.Rol set rol_nombre = I.rol_nombre, rol_activo = I.rol_activo
	from inserted I
	where I.rol_id = GARBAGE.Rol.rol_id

	close cursor_roles
	deallocate cursor_roles

end


--drop procedure GARBAGE.createRol