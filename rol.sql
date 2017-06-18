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