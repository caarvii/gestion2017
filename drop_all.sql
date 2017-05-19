alter table GARBAGE.FuncionalidadxRol drop constraint FK_func_ron_rol_id;
alter table GARBAGE.FuncionalidadxRol drop constraint FK_func_ron_func_id;
alter table GARBAGE.RolxUsuario drop constraint FK_rol_usu_rol_id;
alter table GARBAGE.RolxUsuario drop constraint FK_rol_usu_usu_id;
alter table GARBAGE.Cliente drop constraint FK_cli_usu_id;

alter table GARBAGE.Factura drop constraint FK_fact_cli_id;

drop table GARBAGE.FuncionalidadxRol
drop table GARBAGE.Funcionalidad
drop table GARBAGE.RolxUsuario
drop table GARBAGE.Rol

drop table GARBAGE.ItemxFactura
drop table GARBAGE.Factura

drop table GARBAGE.Cliente
drop table GARBAGE.Usuario

drop function GARBAGE.GenerarUsuario;
drop function GARBAGE.RemoverTildes;

drop procedure GARBAGE.SPMigracion;