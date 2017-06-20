create procedure GARBAGE.getFuncionalidades
as
begin
	(select * from GARBAGE.Funcionalidad)
end
go

create procedure GARBAGE.getFuncionalidadListByRolId(@rol_id int)
as
begin
	(select F.func_id, F.func_descripcion 
		from GARBAGE.Funcionalidad F 
        JOIN GARBAGE.FuncionalidadxRol RF ON RF.func_rol_func_id = F.func_id AND RF.func_rol_rol_id = @rol_id)
end