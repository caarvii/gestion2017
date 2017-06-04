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
alter table GARBAGE.TurnoxAutomovil drop constraint FK_turno_auto_turno_id;
alter table GARBAGE.TurnoxAutomovil drop constraint FK_turno_auto_auto_id;

alter table GARBAGE.Factura drop constraint FK_fact_cli_id;

alter table GARBAGE.Viaje drop constraint FK_viaje_auto_id;
alter table GARBAGE.Viaje drop constraint FK_viaje_turno_id;
alter table GARBAGE.Viaje drop constraint FK_viaje_chof_id;
alter table GARBAGE.Viaje drop constraint FK_viaje_cli_id;

alter table GARBAGE.ItemxFactura drop constraint FK_fact_fact_id;
alter table GARBAGE.ItemxFactura drop constraint FK_fact_viaje_id;
go 


drop table GARBAGE.FuncionalidadxRol
drop table GARBAGE.Funcionalidad
drop table GARBAGE.RolxUsuario
drop table GARBAGE.Rol

drop table GARBAGE.ItemxFactura
drop table GARBAGE.Factura
drop table GARBAGE.Viaje



drop table GARBAGE.Cliente
drop table GARBAGE.Usuario
drop table GARBAGE.Chofer
drop table GARBAGE.Marca
drop table GARBAGE.Modelo
drop table GARBAGE.Automovil
drop table GARBAGE.ChoferxAutomovil
drop table GARBAGE.Turno
drop table GARBAGE.TurnoxAutomovil

drop function GARBAGE.GenerarUsuario;
drop function GARBAGE.RemoverTildes;

drop view GARBAGE.AutosChoferTurnoView;
drop view GARBAGE.FacturaViajeView;
drop view GARBAGE.RendicionViajeView;

drop procedure GARBAGE.SPMigracion;