alter table GARBAGE.FuncionalidadxRol drop constraint FK_func_ron_rol_id;
alter table GARBAGE.FuncionalidadxRol drop constraint FK_func_ron_func_id;
alter table GARBAGE.RolxUsuario drop constraint FK_rol_usu_rol_id;
alter table GARBAGE.RolxUsuario drop constraint FK_rol_usu_usu_id;
alter table GARBAGE.Cliente drop constraint FK_cli_usu_id;
alter table GARBAGE.Chofer drop constraint FK_chof_usu_id;
alter table GARBAGE.Automovil drop constraint FK_auto_marca_id;
alter table GARBAGE.Automovil drop constraint FK_auto_mod_id;
alter table GARBAGE.ChoferxAutomovil drop constraint FK_chof_auto_chof_id;
alter table GARBAGE.ChoferxAutomovil drop constraint FK_chof_auto_auto_id;

drop table GARBAGE.FuncionalidadxRol
drop table GARBAGE.Funcionalidad
drop table GARBAGE.RolxUsuario
drop table GARBAGE.Rol
drop table GARBAGE.Cliente
drop table GARBAGE.Usuario
drop table GARBAGE.Chofer
drop table GARBAGE.Marca
drop table GARBAGE.Modelo
drop table GARBAGE.Automovil
drop table GARBAGE.ChoferxAutomovil

drop function GARBAGE.GenerarUsuario;
drop function GARBAGE.RemoverTildes;

drop view GARBAGE.AutosView;

drop procedure GARBAGE.SPMigracion;