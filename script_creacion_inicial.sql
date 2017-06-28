use [GD1C2017]
go

--creacion esquema del grupo
if not exists(select * from sys.schemas where name = 'GARBAGE')
	execute('create schema [GARBAGE] authorization [gd]')
else 
	print('El esquema GARBAGE ya existe.')
go

/****************************************************************/
/*********** DROP ALL PROCEDURES, FUNCTIONS AND VIEWS ***********/
/****************************************************************/

declare @objectName varchar(500)
declare @type char(2)
declare @typeName varchar(30)

declare cursorObjectsDB cursor for 
	select sys.objects.name, sys.objects.type
	from sys.objects 
	join sys.schemas on sys.schemas.schema_id = sys.objects.schema_id and sys.schemas.name = 'GARBAGE' 
	where type = 'p' or type in (N'FN', N'IF', N'TF', N'FS', N'FT') or type = 'V' or type= 'TT'

open cursorObjectsDB
fetch next from cursorObjectsDB into @objectName, @type
while @@fetch_status = 0
begin

	if(@type = 'P')
	begin
		set @typeName = 'procedure'
	end
	if(@type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	begin
		set @typeName = 'function'
	end
	if(@type = 'V')
	begin
		set @typeName = 'view'
	end

	exec('drop ' + @typeName + ' GARBAGE.' + @objectName )
	print('drop ' + @typeName + ' GARBAGE.' + @objectName )

    fetch next from cursorObjectsDB into @objectName, @type
end
close cursorObjectsDB
deallocate cursorObjectsDB
go

/************************************************/
/*********** DROP ALL TABLE IF EXISTS ***********/
/************************************************/

create function GARBAGE.existeTabla(@nombreTabla varchar(50))
returns bit
as begin
 return (select count(*) 
		from INFORMATION_SCHEMA.TABLES 
		where TABLE_SCHEMA = 'GARBAGE' and TABLE_NAME = @nombreTabla)
end
go

if(GARBAGE.existeTabla('ItemxFactura') = 1)
begin
	drop table GARBAGE.ItemxFactura
end
go

if(GARBAGE.existeTabla('Factura') = 1)
begin
	drop table GARBAGE.Factura
end
go

if(GARBAGE.existeTabla('Rendicion') = 1)
begin
	drop table GARBAGE.Rendicion
end
go

if(GARBAGE.existeTabla('Viaje') = 1)
begin
	drop table GARBAGE.Viaje
end
go

if(GARBAGE.existeTabla('TurnoxAutomovil') = 1)
begin
	drop table GARBAGE.TurnoxAutomovil
end
go

if(GARBAGE.existeTabla('Turno') = 1)
begin
	drop table GARBAGE.Turno
end
go

if(GARBAGE.existeTabla('ChoferxAutomovil') = 1)
begin	
	drop table GARBAGE.ChoferxAutomovil
end
go

if(GARBAGE.existeTabla('Automovil') = 1)
begin
	drop table GARBAGE.Automovil
end
go

if(GARBAGE.existeTabla('Modelo') = 1)
begin
	drop table GARBAGE.Modelo
end
go

if(GARBAGE.existeTabla('Marca') = 1)
begin
	drop table GARBAGE.Marca
end
go

if(GARBAGE.existeTabla('Chofer') = 1)
begin
	drop table GARBAGE.Chofer
end
go

if(GARBAGE.existeTabla('Cliente') = 1)
begin
	drop table GARBAGE.Cliente
end
go

if(GARBAGE.existeTabla('RolxUsuario') = 1)
begin
	drop table GARBAGE.RolxUsuario
end
go

if(GARBAGE.existeTabla('Usuario') = 1)
begin
	drop table GARBAGE.Usuario
end
go

if(GARBAGE.existeTabla('FuncionalidadxRol') = 1)
begin
	drop table GARBAGE.FuncionalidadxRol
end
go

if(GARBAGE.existeTabla('Rol') = 1)
begin
	drop table GARBAGE.Rol
end
go

if(GARBAGE.existeTabla('Funcionalidad') = 1)
begin
	drop table GARBAGE.Funcionalidad
end
go

/******************************************** INICIO - CREACION DE TABLAS ******************************************/

create table GARBAGE.Rol(
	rol_id int constraint PK_rol_id primary key identity(1,1),
	rol_nombre nvarchar(30) unique not null,
	rol_activo bit default 1 not null)
go


create table GARBAGE.Funcionalidad(
	func_id int constraint PK_func_id primary key identity(1,1),
	func_descripcion nvarchar(50) unique not null)
go


create table GARBAGE.FuncionalidadxRol(
	func_rol_rol_id int not null, --foreign key references [GARBAGE].Rol(rol_id) not null,
	func_rol_func_id int not null, --foreign key references [GARBAGE].Funcionalidad(func_id) not null
	constraint PK_func_x_rol primary key(func_rol_rol_id, func_rol_func_id))
go


create table GARBAGE.Usuario(
	usu_id int constraint PK_usu_id primary key identity (1,1),
	usu_username nvarchar(25) unique not null,
	usu_password varbinary(64) not null,
	usu_activo bit default 1 not null,
	usu_intentos int default 0 not null)
go


create table GARBAGE.RolxUsuario(
	rol_usu_rol_id int not null, --foreign key references [GARBAGE].Rol(rol_id) not null,
	rol_usu_usu_id int not null, --foreign key references [GARBAGE].Usuario(usu_id) not null
	constraint PK_rol_x_usu primary key(rol_usu_rol_id, rol_usu_usu_id))
go


create table GARBAGE.Cliente(
	cli_id int constraint PK_cli_id primary key identity (1,1),
	cli_nombre varchar(255) not null,
	cli_apellido varchar(255) not null,
	cli_dni numeric(18,0) not null,
	cli_telefono numeric(18,0) unique not null,
	cli_direccion varchar(255) not null,
	cli_fecha_nacimiento datetime not null,
	cli_cp numeric(18,0) default 1 not null,
	cli_mail varchar(255), 
	cli_activo bit default 1 not null,
	cli_usu_id int )
go

create table GARBAGE.Chofer(
	chof_id int constraint PK_chof_id primary key identity (1,1),
	chof_nombre varchar(255) not null,
	chof_apellido varchar(255) not null,
	chof_dni numeric(18,0) not null,
	chof_telefono numeric(18,0) not null,
	chof_direccion varchar(255) not null,
	chof_fecha_nacimiento datetime not null,
	chof_mail varchar(255) not null,
	chof_activo bit default 1 not null,
	chof_usu_id int)
go

create table GARBAGE.Marca(
	marca_id int constraint PK_marca_id primary key identity (1,1),
	marca_nombre varchar(255) not null)
go

create table GARBAGE.Modelo(
	mod_id int constraint PK_mod_id primary key identity (1,1),
	mod_nombre varchar(255) not null)
go

create table GARBAGE.Automovil(
	auto_id int constraint PK_auto_id primary key identity (1,1),
	auto_marca_id int not null,
	auto_mod_id int not null,
	auto_patente varchar(10) unique not null,
	auto_licencia varchar(26) not null,
	auto_rodado varchar(10) not null,
	auto_activo bit default 1 not null)
go

create table GARBAGE.ChoferxAutomovil(
	chof_auto_chof_id int not null,
	chof_auto_auto_id int not null,
	chof_auto_habilitado bit default 1 not null,
	constraint PK_chof_auto_id primary key(chof_auto_auto_id, chof_auto_chof_id))
go

create table GARBAGE.Turno(
	turno_id int constraint PK_turno_id primary key identity (1,1),
	turno_hora_inicio numeric(18,0) not null,
	turno_hora_fin numeric(18,0) not null,
	turno_descripcion varchar(255) not null,
	turno_valor_km numeric(18,2) not null,
	turno_precio_base numeric(18,2) not null,
	turno_habilitado bit default 1 not null)
go

create table GARBAGE.TurnoxAutomovil(
	turno_auto_turno_id int not null,
	turno_auto_auto_id int not null,
	constraint PK_turno_auto_id primary key(turno_auto_turno_id, turno_auto_auto_id))
go


create table GARBAGE.Viaje(
	viaje_id int constraint PK_viaje_id primary key identity(1,1) NOT NULL,
	viaje_auto_id int NOT NULL,
	viaje_turno_id int NOT NULL,
	viaje_chof_id int NOT NULL,
	viaje_cant_km numeric(18, 2) NOT NULL,
	fecha_hora_ini datetime NOT NULL,
	fecha_hora_fin datetime NOT NULL,
	viaje_cli_id int NOT NULL,
	viaje_rendido bit NOT NULL, 
	viaje_duplicado int default 0 not null)
go

create table GARBAGE.Rendicion(
	rend_id int constraint PK_rend_id primary key identity (1,1),
	rend_fecha_pago datetime not null,
	rend_chofer int,
	rend_turno int,
	rend_importe_total numeric(12,2),
	rend_importe_duplicado numeric(12,2) default 0 )
go

create table GARBAGE.ItemxFactura(
	item_fac_id int not null identity (1,1),
	item_fac_fac_id int not null ,
	item_fac_viaje_id int not null,
	item_fac_costo decimal(12,2),
	item_fac_descripcion varchar(255),
	item_fac_duplicado int  default 0 not null,
	constraint PK_item_x_factura primary key(item_fac_id, item_fac_fac_id, item_fac_viaje_id)
)
go

create table GARBAGE.Factura(
	fact_id int constraint PK_fact_id primary key identity (1,1),
	fact_fecha_ini datetime not null,
	fact_fecha_fin datetime not null,
	fact_cli_id int,
	fact_total decimal (12,2),
	fact_cant_viajes int
)
go



/******************************************** FIN - CREACION DE TABLAS *********************************************/

/******************************************** INICIO - FOREING KEY *************************************************/

alter table GARBAGE.FuncionalidadxRol
add constraint FK_func_ron_rol_id foreign key (func_rol_rol_id) references GARBAGE.Rol(rol_id),
	constraint FK_func_ron_func_id foreign key (func_rol_func_id) references GARBAGE.Funcionalidad(func_id);
go

alter table GARBAGE.RolxUsuario
add constraint FK_rol_usu_rol_id foreign key (rol_usu_rol_id) references GARBAGE.Rol(rol_id),
	constraint FK_rol_usu_usu_id foreign key (rol_usu_usu_id) references GARBAGE.Usuario(usu_id);	
go

alter table GARBAGE.Cliente
add constraint FK_cli_usu_id foreign key (cli_usu_id) references GARBAGE.Usuario(usu_id);
go

alter table GARBAGE.Factura
add constraint FK_fact_cli_id foreign key (fact_cli_id) references GARBAGE.Cliente(cli_id);
go

alter table GARBAGE.Automovil
add constraint FK_auto_marca_id foreign key (auto_marca_id) references GARBAGE.Marca(marca_id),
	constraint FK_auto_mod_id foreign key (auto_mod_id) references GARBAGE.Modelo(mod_id);
go

alter table GARBAGE.ChoferxAutomovil
add constraint FK_chof_auto_chof_id foreign key (chof_auto_chof_id) references GARBAGE.Chofer(chof_id),
	constraint FK_chof_auto_auto_id foreign key (chof_auto_auto_id) references GARBAGE.Automovil(auto_id);	
go

alter table GARBAGE.TurnoxAutomovil
add constraint FK_turno_auto_turno_id foreign key (turno_auto_turno_id) references GARBAGE.Turno(turno_id),
	constraint FK_turno_auto_auto_id foreign key (turno_auto_auto_id) references GARBAGE.Automovil(auto_id);	
go 

alter table GARBAGE.Viaje  
add  constraint [FK_viaje_auto_id] foreign key (viaje_auto_id) references GARBAGE.Automovil (auto_id),
	 constraint [FK_viaje_chof_id] foreign key (viaje_chof_id) references GARBAGE.Chofer (chof_id),
	 constraint [FK_viaje_cli_id] foreign key (viaje_cli_id) references GARBAGE.Cliente (cli_id),
	 constraint [FK_viaje_turno_id] foreign key (viaje_turno_id) references GARBAGE.Turno (turno_id);
go

alter table GARBAGE.ItemxFactura
add constraint FK_fact_fact_id foreign key (item_fac_fac_id) references GARBAGE.Factura(fact_id),
	constraint FK_fact_viaje_id foreign key (item_fac_viaje_id) references GARBAGE.Viaje(viaje_id);
go

alter table GARBAGE.Chofer
add constraint FK_chof_usu_id foreign key (chof_usu_id) references GARBAGE.Usuario(usu_id);
go

alter table GARBAGE.Rendicion
add constraint FK_rend_chofer_id foreign key (rend_chofer) references GARBAGE.Chofer(chof_id),
 constraint FK_rend_turno_id foreign key (rend_turno) references GARBAGE.Turno(turno_id);
go

/******************************************** FIN - FOREING KEY ****************************************************/

create function GARBAGE.RemoverTildes(@cadena varchar(25))
returns varchar(25)
as begin
    return replace(replace(replace(replace(replace(replace(@cadena, ' ', ''), 'á', 'a'), 'é','e'), 'í', 'i'), 'ó', 'o'), 'ú','u')
end
go

create function GARBAGE.GenerarUsuario(@nombre varchar(255), @apellido varchar(255))
returns varchar(25)
as begin	
	return GARBAGE.RemoverTildes(lower(substring(@nombre, 1,19) + '.' + substring(@apellido, 1,19)))
end
go

create view GARBAGE.AutosChoferTurnoView (patente, marca, modelo, licencia, rodado, chofer_dni, turno_desc) 
as (select distinct Auto_Patente, Auto_Marca, Auto_Modelo, Auto_Licencia, Auto_Rodado, Chofer_Dni, Turno_Descripcion
	from gd_esquema.Maestra
	where Auto_Patente is not null);
go

create view GARBAGE.FacturaViajeView (patente , chofer_dni , viaje_km , viaje_fecha , turno_desc,cli_dni , fact_nro, repetido) 
as 
	(SELECT Auto_Patente,Chofer_Dni,Viaje_Cant_Kilometros,Viaje_Fecha,Turno_Descripcion,Cliente_Dni, Factura_Nro ,Count(*) as repetido
	FROM gd_esquema.Maestra
	WHERE Rendicion_Nro is null AND Factura_Nro is not null
	GROUP BY Auto_Patente,Chofer_Dni,Viaje_Cant_Kilometros,Viaje_Fecha,Turno_Descripcion,Cliente_Dni, Factura_Nro)
go

create view GARBAGE.RendicionViajeView (patente , chofer_dni , viaje_km , viaje_fecha , turno_desc,cli_dni ,rend_nro , rend_fecha, rend_importe , repetido) 
as 
	(SELECT Auto_Patente,Chofer_Dni,Viaje_Cant_Kilometros,Viaje_Fecha,Turno_Descripcion,Cliente_Dni, Rendicion_Nro,Rendicion_Fecha, Rendicion_Importe, Count(*) as repetido
	FROM gd_esquema.Maestra
	WHERE Rendicion_Nro is not null AND Factura_Nro is null
	GROUP BY Auto_Patente,Chofer_Dni,Viaje_Cant_Kilometros,Viaje_Fecha,Turno_Descripcion,Cliente_Dni, Rendicion_Nro,Rendicion_Fecha, Rendicion_Importe )
go


create procedure GARBAGE.SPMigracion
as
begin

declare @ROL_ADMIN char(13);
set @ROL_ADMIN = 'Administrador';

declare @ROL_CLIENTE char(7);
set @ROL_CLIENTE = 'Cliente';

declare @ROL_CHOFER char(6)
set @ROL_CHOFER = 'Chofer';

insert into GARBAGE.Rol(rol_nombre) values (@ROL_ADMIN), (@ROL_CLIENTE), (@ROL_CHOFER);

print('Insertando Roles.');


insert into GARBAGE.Funcionalidad(func_descripcion)
	values
	('ABM de Rol'),
	('ABM de Clientes'),
	('ABM de Automóvil'),
	('ABM de Chofer'),
	('ABM de Turno'),
	('Registrar Viaje'),
	('Rendicion de Viajes'),
	('Facturacion a Cliente'),
	('Listado Estadístico')


print('Insertando Funcionalidades.');

--El Rol Administrador posee todas las funcionalidades
insert into GARBAGE.FuncionalidadxRol 
	select rol_id, func_id 
	from GARBAGE.Rol, GARBAGE.Funcionalidad 
	where rol_id = 1;

--El cliente solo puede facturarse y el chofer solo puede registrar un viaje.
insert into GARBAGE.FuncionalidadxRol values (2,8), (3,6);

print('Insertando Funcionalidades x Rol.');


declare @hash_algorithm char(8)
set @hash_algorithm = 'SHA2_256';

insert into GARBAGE.Usuario(usu_username,usu_password)
values
	('admin', HASHBYTES(@hash_algorithm,'w23e')),
	('david', HASHBYTES(@hash_algorithm,'david')),
	('fede', HASHBYTES(@hash_algorithm,'fede')),
	('nico', HASHBYTES(@hash_algorithm,'nico')),
	('fer', HASHBYTES(@hash_algorithm,'fer'));

print('Insertando Usuarios base.');

insert into GARBAGE.RolxUsuario(rol_usu_rol_id , rol_usu_usu_id)
(
	select R.rol_id, S.usu_id
	from GARBAGE.Usuario S 
	join GARBAGE.Rol R on R.rol_nombre = @ROL_ADMIN
);

insert into GARBAGE.RolxUsuario(rol_usu_rol_id , rol_usu_usu_id)
(
	select R.rol_id, S.usu_id
	from GARBAGE.Usuario S 
	join GARBAGE.Rol R on R.rol_nombre = @ROL_CLIENTE
	where S.usu_username <> 'admin'
);

print('Insertando Usuarios admin.');

insert into GARBAGE.Cliente (cli_nombre, cli_apellido, cli_dni, cli_telefono, 
		cli_direccion, cli_fecha_nacimiento, cli_mail, cli_cp)
(	
	select distinct left(Cliente_Nombre,1) + lower(substring(Cliente_Nombre,2,len(Cliente_Nombre))), 
		Cliente_Apellido, Cliente_Dni, Cliente_Telefono, Cliente_Direccion, Cliente_Fecha_Nac, Cliente_Mail, 0
	from gd_esquema.Maestra
);

print('Insertando Clientes.');

insert into GARBAGE.Usuario(usu_username, usu_password) (
	select GARBAGE.GenerarUsuario(cli_nombre, cli_apellido), 
		   HASHBYTES(@hash_algorithm, GARBAGE.GenerarUsuario(cli_nombre, cli_apellido))
	from GARBAGE.Cliente);

print('Creando los Usuarios de los clientes.');

insert into GARBAGE.RolxUsuario(rol_usu_rol_id, rol_usu_usu_id)(
	select rol_id, usu_id
	from GARBAGE.Rol, GARBAGE.Usuario
	where rol_nombre = @ROL_CLIENTE and usu_id not in (select rol_usu_usu_id from GARBAGE.RolxUsuario));

print('Seteando el Rol Cliente de los Usuarios clientes.');

update GARBAGE.Cliente set cli_usu_id = usu_id
from GARBAGE.Usuario, GARBAGE.Cliente
where usu_username = GARBAGE.GenerarUsuario(cli_nombre, cli_apellido)

print('Actualizando los clientes con los Usuarios que les corresponden.');

alter table GARBAGE.Cliente alter column cli_usu_id int not null

insert into GARBAGE.Chofer(chof_nombre, chof_apellido, chof_dni, chof_telefono, 
		chof_direccion, chof_fecha_nacimiento, chof_mail)
(	
	select distinct left(Chofer_Nombre,1) + lower(substring(Chofer_Nombre,2,len(Chofer_Nombre))),
				Chofer_Apellido, Chofer_Dni, Chofer_Telefono, Chofer_Direccion, Chofer_Fecha_Nac, Chofer_Mail
	from gd_esquema.Maestra
);

print('Insertando Choferes.');

insert into GARBAGE.Usuario(usu_username, usu_password) (
	select GARBAGE.GenerarUsuario(chof_nombre, chof_apellido), 
		   HASHBYTES(@hash_algorithm, GARBAGE.GenerarUsuario(chof_nombre, chof_apellido))
	from GARBAGE.Chofer);

print('Creando los Usuarios de los choferes.');

insert into GARBAGE.RolxUsuario(rol_usu_rol_id, rol_usu_usu_id)(
	select rol_id, usu_id
	from GARBAGE.Rol, GARBAGE.Usuario
	where rol_nombre = @ROL_CHOFER and usu_id not in (select rol_usu_usu_id from GARBAGE.RolxUsuario));

print('Seteando el Rol Chofer de los Usuarios choferes.');

update GARBAGE.Chofer set chof_usu_id = usu_id
from GARBAGE.Usuario, GARBAGE.Chofer
where usu_username = GARBAGE.GenerarUsuario(chof_nombre, chof_apellido)

print('Actualizando los choferes con los Usuarios que les corresponden.');

alter table GARBAGE.Chofer alter column chof_usu_id int not null

/************************************************************************/

insert into GARBAGE.Marca(marca_nombre)(select distinct Auto_Marca from gd_esquema.Maestra)

print('Insertando Marcas.');

insert into GARBAGE.Modelo(mod_nombre)(select distinct Auto_Modelo from gd_esquema.Maestra)

print('Insertando Modelos.');

insert into GARBAGE.Automovil(auto_patente, auto_licencia, auto_rodado, auto_marca_id, auto_mod_id)
	(select distinct patente, 
					 licencia, 
					 rodado, 
					 (select marca_id from GARBAGE.Marca where marca_nombre = marca),
					 (select mod_id from GARBAGE.Modelo where mod_nombre = modelo)
	from GARBAGE.AutosChoferTurnoView)

print('Insertando Autos.');

insert into GARBAGE.ChoferxAutomovil(chof_auto_chof_id,chof_auto_auto_id)
	(select distinct chof_id, auto_id
	 from GARBAGE.AutosChoferTurnoView, GARBAGE.Automovil, GARBAGE.Chofer
	 where patente = auto_patente and chofer_dni = chof_dni);

print('Insertando los choferes con sus autos correspondientes.');

SET IDENTITY_INSERT GARBAGE.Factura ON

insert into GARBAGE.Factura(fact_id,fact_fecha_ini,fact_fecha_fin)(
	select DISTINCT  Factura_Nro,Factura_Fecha_Inicio , Factura_Fecha_Fin
	from gd_esquema.Maestra
	WHERE Factura_Nro IS NOT NULL
);

print ('Agregando facturas');

SET IDENTITY_INSERT GARBAGE.Factura OFF

update GARBAGE.Factura set fact_cli_id = cli_id
	from GARBAGE.Factura, GARBAGE.Cliente , gd_esquema.Maestra M
	where fact_id = M.Factura_Nro AND cli_dni = M.Cliente_Dni

print ('Agregando clientes a facturas.');

alter table GARBAGE.Factura alter column fact_cli_id int not null;




insert into GARBAGE.Turno (turno_descripcion, turno_hora_inicio, turno_hora_fin, 
						   turno_valor_km, turno_precio_base)
(	
	select distinct Turno_Descripcion, Turno_Hora_Inicio, Turno_Hora_Fin, 
					Turno_Valor_Kilometro, Turno_Valor_Kilometro
	from gd_esquema.Maestra
)

print ('Agregando Turnos.');

insert into GARBAGE.TurnoxAutomovil (turno_auto_auto_id, turno_auto_turno_id)
(	
	select A.auto_id, turno_id
	from GARBAGE.AutosChoferTurnoView V, GARBAGE.Automovil A, GARBAGE.Turno
	where V.patente = A.auto_patente and V.turno_desc = turno_descripcion
)

print ('Agregando los autos con sus turnos correspondientes.');


INSERT INTO GARBAGE.Viaje ([viaje_auto_id], [viaje_chof_id], [viaje_cant_km], 
       [fecha_hora_ini], [fecha_hora_fin], [viaje_turno_id], [viaje_cli_id] , viaje_duplicado, viaje_rendido) 
       
(SELECT  A.auto_id, chof_id, Viaje_Cant_Kilometros, Viaje_Fecha, Viaje_Fecha, turno_id, cli_id , COUNT(*), 1
  FROM gd_esquema.Maestra W, GARBAGE.Automovil A, GARBAGE.Chofer, GARBAGE.Turno T, GARBAGE.Cliente C
  WHERE Rendicion_Nro is null AND Factura_Nro is null
  and W.Auto_Patente = A.auto_patente and W.Chofer_Dni = chof_dni and W.Turno_Descripcion = T.turno_descripcion 
  and W.Cliente_Dni = C.cli_dni
  GROUP BY A.auto_id, chof_id, Viaje_Cant_Kilometros, Viaje_Fecha, Viaje_Fecha, turno_id, cli_id)

print ('Agregando viajes');

alter table GARBAGE.Viaje add default 0 for viaje_rendido;

SET IDENTITY_INSERT GARBAGE.Rendicion ON

insert into GARBAGE.Rendicion (rend_id ,rend_fecha_pago, rend_importe_total , rend_chofer , rend_turno ,rend_importe_duplicado)

(
	select rend_nro , rend_fecha , SUM(rend_importe), CH.chof_id , T.turno_id , SUM(((RVV.repetido - 1)* RVV.rend_importe)) as rend_importe_duplicado
	from GARBAGE.RENDICIONVIAJEVIEW RVV, GARBAGE.Chofer CH , GARBAGE.Turno T 
	where RVV.chofer_dni = ch.chof_dni AND RVV.turno_desc = T.turno_descripcion
	GROUP BY rend_nro , rend_fecha ,  CH.chof_id , T.turno_id 
)

SET IDENTITY_INSERT GARBAGE.Rendicion OFF

print ('Agregando rendiciones');


insert into GARBAGE.ItemxFactura (item_fac_fac_id,item_fac_viaje_id,item_fac_duplicado , item_fac_costo)
	(
		
	SELECT F.fact_id , V.viaje_id , FVV.repetido , (T.turno_precio_base + (V.viaje_cant_km*T.turno_valor_km))
	FROM GARBAGE.FacturaViajeView FVV , GARBAGE.Viaje V , GARBAGE.Factura F , GARBAGE.TURNO T
	WHERE (SELECT auto_id FROM GARBAGE.Automovil WHERE FVV.patente = auto_patente) = v.viaje_auto_id AND
		   FVV.viaje_km = V.viaje_cant_km AND
		   FVV.viaje_fecha = V.fecha_hora_fin AND
		   (SELECT cli_id FROM GARBAGE.Cliente WHERE FVV.cli_dni = cli_dni) = V.viaje_cli_id AND
		   (SELECT chof_id FROM GARBAGE.Chofer WHERE FVV.chofer_dni = chof_dni) = V.viaje_chof_id AND
		   FVV.fact_nro = F.fact_id AND
		   V.viaje_turno_id = T.turno_id

	)

print ('Agregando item por cada factura');

update GARBAGE.Factura set  fact_total = (select sum(item_fac_costo) from GARBAGE.ItemxFactura where item_fac_fac_id = fact_id),
							fact_cant_viajes  = (select count(*) from GARBAGE.ItemxFactura where item_fac_fac_id = fact_id) 
from GARBAGE.Factura

print ('Actualizando los totales y cant. viajes las facturas');

alter table GARBAGE.Factura alter column fact_cant_viajes int not null
alter table GARBAGE.Factura alter column fact_total decimal (12,2) not null

end
go

/****************************************************************************/
/*************************** EJECUCION MIGRACION ****************************/
/****************************************************************************/
exec GARBAGE.SPMigracion;
go
/****************************************************************************/


/****************************************************************************/
/****************************************************************************/
/**************************** LOGIN PROCEDURES ******************************/
/****************************************************************************/
/****************************************************************************/


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
		set @error_message = 'No existe ningun usuario con ese username ' + @username;
		throw 50000, @error_message , 1; 
	END
	-- 
	IF @usu_activo = 0 BEGIN
		set @error_message = 'El usuario' + @username + 'se encuentra desahabilitado';
		throw 50000, @error_message , 1; 
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
		where usu_id = @usu_id;
		throw 50000, 'Contrasenia incorrecta' , 1;
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
		join GARBAGE.RolxUsuario RU ON R.rol_id = RU.rol_usu_rol_id and RU.rol_usu_usu_id = @user_id
		where rol_activo = 1)
end
go




/******************************************************************************/
/******************************************************************************/
/**************************** USUARIO PROCEDURES ******************************/
/******************************************************************************/
/******************************************************************************/

create procedure GARBAGE.getUsuarioById(@user_id int)
as
begin
	(select * from GARBAGE.Usuario where usu_id = @user_id)
end
go

create function GARBAGE.DevolverUsuarioValido(@nombre varchar(255), @apellido varchar(255))
returns varchar(25)
AS BEGIN
	
	DECLARE @cant int;
	DECLARE @usuario_sugerido varchar(25);
	DECLARE @usu_id int;

	SET @cant = (SELECT COUNT(*) FROM GARBAGE.Usuario WHERE usu_username LIKE GARBAGE.GenerarUsuario( @nombre , @apellido) + '%') ;
	
	IF (@cant = 0) BEGIN
		SET @usuario_sugerido = 'NADA'

	END
	ELSE BEGIN

		SET @usuario_sugerido = CONCAT ( GARBAGE.GenerarUsuario(@nombre , @apellido), @cant )

	END

	RETURN @usuario_sugerido 

END
go


/**************************************************************************************/
/**************************************************************************************/
/**************************** FUNCIONALIDADES PROCEDURES ******************************/
/**************************************************************************************/
/**************************************************************************************/


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
go




/**************************************************************************/
/**************************************************************************/
/**************************** ROL PROCEDURES ******************************/
/**************************************************************************/
/**************************************************************************/


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

IF EXISTS (SELECT * FROM sys.table_types WHERE name ='FuncionalidadType')
    drop type GARBAGE.FuncionalidadType
GO

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
go





/******************************************************************************/
/******************************************************************************/
/**************************** CHOFER PROCEDURES ******************************/
/******************************************************************************/
/******************************************************************************/

create procedure GARBAGE.getChoferes
as
begin
	(select * from GARBAGE.Chofer)
end
go

create procedure GARBAGE.getChoferById(@chofer_id int)
as
begin
	(select * from GARBAGE.Chofer where chof_id = @chofer_id)
end
go

create procedure GARBAGE.bajaLogicaChofer(@chof_id int)
as
begin
	
	update GARBAGE.Chofer set chof_activo = 0
	where chof_id = @chof_id;
	RETURN 1

end
go

create procedure GARBAGE.altaChofer(
            @chof_nombre varchar(255),
            @chof_apellido varchar(255),
            @chof_dni numeric (18,0),
            @chof_mail varchar(255),
            @chof_telefono numeric (18,0),
			@chof_direccion varchar(255),
            @chof_fecha_nacimiento datetime
			)
as
begin

	declare @error_message nvarchar(255);
	declare @cant int;
	declare @user_id int;
	declare @nombre_sugerido varchar(25);
	declare @id_rol_chofer int;


	set @cant = (SELECT COUNT (*) FROM GARBAGE.Chofer WHERE chof_telefono=@chof_telefono);
	
	if  @cant > 0 BEGIN
		set @error_message = 'El chofer ya existe';
		throw 50000, @error_message , 1;
		
	END

	SET @nombre_sugerido = GARBAGE.DevolverUsuarioValido(@chof_nombre , @chof_apellido)

	IF (@nombre_sugerido = 'NADA') BEGIN
		SET @nombre_sugerido = GARBAGE.GenerarUsuario(@chof_nombre , @chof_apellido)
	END

	-- Podria volver a agregarse en un futuro

	SET @id_rol_chofer = (select rol_id from GARBAGE.Rol WHERE rol_nombre = 'Chofer');


	-- ROL INHABILITADO
	IF ( (SELECT COUNT(*) FROM GARBAGE.Rol WHERE rol_id = @id_rol_chofer AND rol_activo = 0) > 0 ) BEGIN
	
		set @error_message = 'No se puede crear un chofer con un rol inactivo';
		throw 70000, @error_message , 1;

	END 

	-- INSERTA EN TABLA USUARIO

	INSERT INTO GARBAGE.Usuario (usu_username,usu_password)
	VALUES (@nombre_sugerido, HASHBYTES('SHA2_256',GARBAGE.GenerarUsuario(@chof_nombre , @chof_apellido)))

	SET @user_id = scope_identity();

	-- INSERTA EN TABLA ROL_POR_USUARIO ( AL SER VALIDO ) 

	INSERT INTO GARBAGE.RolxUsuario (rol_usu_rol_id , rol_usu_usu_id)
	VALUES (@id_rol_chofer , @user_id)

	insert into GARBAGE.Chofer(chof_nombre,
							   chof_apellido,
							   chof_dni,
							   chof_mail,
							   chof_telefono,
							   chof_direccion,
							   chof_fecha_nacimiento,
							   chof_usu_id,
							   chof_activo)
	values (  @chof_nombre,
			  @chof_apellido,
			  @chof_dni, 
			  @chof_mail,
			  @chof_telefono,
			  @chof_direccion,
			  @chof_fecha_nacimiento,
			  @user_id,
			  1)

	RETURN 1
END
GO

create procedure GARBAGE.updateChofer(
			@chof_id numeric(18,0),
            @chof_nombre varchar(255),
            @chof_apellido varchar(255),
            @chof_dni numeric (18,0),
            @chof_mail varchar(255),
            @chof_telefono numeric (18,0),
			@chof_direccion varchar(255),
            @chof_fecha_nacimiento datetime ,
			@chof_activo bit
			)
as
begin

	declare @error_message nvarchar(255);
	declare @cant int;

	set @cant = (select COUNT(*) from GARBAGE.Chofer where chof_id = @chof_id );

	if  @cant = 0 BEGIN
		set @error_message = 'El chofer no existe';
		throw 50000, @error_message , 1;
	END

	-- Nota: No se actualiza el usuario.

	update GARBAGE.Chofer set chof_nombre = @chof_nombre,
							  chof_apellido = @chof_apellido,
							  chof_dni = @chof_dni,
							  chof_telefono = @chof_telefono,
							  chof_direccion = @chof_direccion,
							  chof_fecha_nacimiento = @chof_fecha_nacimiento,
							  chof_mail = @chof_mail,
							  chof_activo = @chof_activo
	where chof_id = @chof_id;

	RETURN 1

end
go

create procedure GARBAGE.getChoferesHabilitados
as
begin
	(select * from GARBAGE.Chofer where chof_activo = 1)
end
go





/******************************************************************************/
/******************************************************************************/
/**************************** CLIENTE PROCEDURES ******************************/
/******************************************************************************/
/******************************************************************************/

create procedure GARBAGE.getClientes
as
begin
	(select * from GARBAGE.Cliente)
end
go

create procedure GARBAGE.getClientesHabilitados
as
begin
	(select * from GARBAGE.Cliente where cli_activo = 1)
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
		set @error_message = 'El telefono ya esta en uso, ingrese uno distinto';
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
go

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
	declare @telefono int;

	set @cant = (select COUNT(*) from GARBAGE.Cliente where cli_id = @cli_id );

	if  @cant = 0 BEGIN
		set @error_message = 'El cliente no existe';
		throw 50000, @error_message , 1;
	END

	set @telefono = (SELECT COUNT (*) FROM GARBAGE.Cliente WHERE cli_telefono = @cli_telefono and @cli_id != cli_id);
	
	if  @telefono > 0 BEGIN
		set @error_message = 'El telefono ya esta en uso, ingrese uno distinto';
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





/******************************************************************************/
/******************************************************************************/
/**************************** MODELO PROCEDURES *******************************/
/******************************************************************************/
/******************************************************************************/

create procedure GARBAGE.getModelos
as
begin
	(select * from GARBAGE.Modelo)
end
go





/******************************************************************************/
/******************************************************************************/
/**************************** MARCA PROCEDURES ********************************/
/******************************************************************************/
/******************************************************************************/

create procedure GARBAGE.getMarcas
as
begin
	(select * from GARBAGE.Marca)
end
go




/**********************************************************************************/
/**********************************************************************************/
/**************************** AUTOMOVIL PROCEDURES ********************************/
/**********************************************************************************/
/**********************************************************************************/

create procedure GARBAGE.getAutomoviles
as begin
	(select auto_id,auto_marca_id,marca_nombre,auto_mod_id,mod_nombre,auto_patente,auto_licencia,auto_rodado,auto_activo
	FROM GARBAGE.Automovil,GARBAGE.Marca,GARBAGE.Modelo
	WHERE auto_marca_id=marca_id and auto_mod_id = mod_id)
end
go

create procedure GARBAGE.bajaLogicaAutomovil(@auto_id int)
as
begin
update GARBAGE.Automovil set auto_activo=0 where auto_id=@auto_id;
update GARBAGE.ChoferxAutomovil set chof_auto_habilitado = 0 where chof_auto_auto_id=@auto_id;
RETURN 1
end
go

create procedure GARBAGE.getTurnosByAutomovilId (@auto_id int)
as begin
select * FROM GARBAGE.Turno,GARBAGE.TurnoxAutomovil
where @auto_id = turno_auto_auto_id and turno_auto_turno_id=turno_id
end
go

create procedure GARBAGE.getChoferByAutomovilId (@auto_id int)
as begin
select * FROM GARBAGE.Chofer,GARBAGE.ChoferxAutomovil,GARBAGE.Automovil 
where auto_id = chof_auto_auto_id and chof_auto_chof_id=chof_id
end
go

if exists (select * from sys.table_types where name ='TurnoType')
    drop type GARBAGE.TurnoType
go

create type GARBAGE.TurnoType as table(
	turnoext_id int not null
)
go

create procedure GARBAGE.updateAutomovil(
            @auto_marca_id int,
            @auto_modelo_id int,
            @auto_patente varchar(10),
            @auto_licencia varchar(26),
            @auto_rodado varchar(10),
            @auto_chofer_id int,
			@turnos GARBAGE.TurnoType READONLY,
			@auto_id int,
			@auto_activo bit)
as
begin
	declare @error_message_patente nvarchar(255)
	declare @cant_patente int

	declare @error_message_chofer nvarchar(255)
	declare @cant_chofer int

	set @cant_patente = (SELECT COUNT (*) FROM GARBAGE.Automovil WHERE auto_patente=@auto_patente and auto_id<>@auto_id);
	set @cant_chofer = (SELECT COUNT (*) FROM GARBAGE.ChoferxAutomovil WHERE chof_auto_chof_id=@auto_chofer_id AND chof_auto_habilitado = 1 and chof_auto_auto_id<>@auto_id);


	IF  (@cant_patente > 0) BEGIN
			set @error_message_patente = 'Ya existe automomovil registrado con esa patente';
			throw 50000, @error_message_patente , 1; 
	END

	IF  (@cant_chofer > 0) BEGIN
			set @error_message_chofer = 'El chofer seleccionado ya esta asignado a un automovil habilitado';
			throw 60000, @error_message_chofer , 1; 
	END
	ELSE

	update GARBAGE.Automovil set auto_marca_id=@auto_marca_id,auto_mod_id=auto_mod_id,auto_patente=@auto_patente,auto_licencia=auto_licencia,auto_rodado=@auto_rodado,auto_activo=@auto_activo
	where auto_id=@auto_id

	update GARBAGE.ChoferxAutomovil set chof_auto_habilitado=@auto_activo, chof_auto_chof_id=@auto_chofer_id
	where chof_auto_auto_id=@auto_id

	delete from GARBAGE.TurnoxAutomovil where turno_auto_auto_id = @auto_id;

	insert into GARBAGE.TurnoxAutomovil(turno_auto_auto_id, turno_auto_turno_id) (
			select @auto_id, T.turno_id
			from @turnos as TURNO join GARBAGE.Turno t on TURNO.turnoext_id = T.turno_id);
	RETURN 1
END
go

create procedure GARBAGE.altaAutomovil(
		    @auto_marca_id int,
            @auto_modelo_id int,
            @auto_patente varchar(10),
            @auto_licencia varchar(26),
            @auto_rodado varchar(10),
            @auto_chofer_id int,
			@turnos GARBAGE.TurnoType READONLY)
as
begin
	declare @error_message_patente nvarchar(255)
	declare @cant_patente int

	declare @error_message_chofer nvarchar(255)
	declare @cant_chofer int

	set @cant_patente = (SELECT COUNT (*) FROM GARBAGE.Automovil WHERE auto_patente=@auto_patente);
	set @cant_chofer = (SELECT COUNT (*) FROM GARBAGE.ChoferxAutomovil WHERE chof_auto_chof_id=@auto_chofer_id AND chof_auto_habilitado = 1);


	IF  (@cant_patente > 0) BEGIN
			set @error_message_patente = 'Ya existe automomovil registrado con esa patente';
			throw 50000, @error_message_patente , 1; 
	END
	
	IF  (@cant_chofer > 0) BEGIN
			set @error_message_chofer = 'El chofer seleccionado ya esta asignado a un automovil habilitado';
			throw 60000, @error_message_chofer , 1; 
	END
	ELSE
	
	insert into GARBAGE.Automovil(auto_marca_id,auto_mod_id,auto_patente,auto_licencia,auto_rodado,auto_activo)
			values (@auto_marca_id,@auto_modelo_id,@auto_patente,@auto_licencia,@auto_rodado, 1)

	declare @auto_id int
	SET @auto_id = (SELECT auto_id FROM GARBAGE.Automovil 
					WHERE auto_marca_id=@auto_marca_id AND auto_mod_id=@auto_modelo_id AND auto_patente=@auto_patente AND auto_licencia=@auto_licencia AND auto_rodado=@auto_rodado);

	insert into GARBAGE.ChoferxAutomovil(chof_auto_chof_id,chof_auto_auto_id,chof_auto_habilitado)
			values (@auto_chofer_id,@auto_id,1)

	insert into GARBAGE.TurnoxAutomovil(turno_auto_auto_id, turno_auto_turno_id) (
			select @auto_id, T.turno_id
			from @turnos as TURNO join GARBAGE.Turno t on TURNO.turnoext_id = T.turno_id);
	RETURN 1
end
go





/******************************************************************************/
/******************************************************************************/
/**************************** TURNO PROCEDURES ********************************/
/******************************************************************************/
/******************************************************************************/

create procedure GARBAGE.getTurnoById(@turno_id int)
as
begin
	(select * from GARBAGE.Turno where turno_id = @turno_id)
end
go

create procedure GARBAGE.getAllTurnos
as
begin
	(select * from GARBAGE.Turno)
end
go 

create procedure GARBAGE.altaTurno(@turno_hora_inicio numeric(18,0) , @turno_hora_fin numeric(18,0), @turno_descripcion varchar(255) , @turno_valor_km numeric(18,2) , @turno_precio_base numeric(18,2) )
as
begin

	declare @error_message nvarchar(255)
	declare @cant int;
	declare @solapado int;
	
	set @cant = (select COUNT(*) from GARBAGE.TURNO 		where turno_hora_fin = @turno_hora_fin AND
	 	turno_hora_inicio = @turno_hora_inicio AND
	 	turno_valor_km = @turno_valor_km AND
	 	turno_precio_base = @turno_precio_base AND
	 	turno_descripcion = @turno_descripcion);

	set @solapado = (select COUNT (*) 
					from GARBAGE.Turno
					where ( ( (turno_hora_inicio <= @turno_hora_inicio AND  turno_hora_fin >= @turno_hora_fin) or 
							  (turno_hora_inicio >= @turno_hora_inicio AND turno_hora_fin > @turno_hora_fin and @turno_hora_fin > turno_hora_inicio) or
							  (turno_hora_inicio <= @turno_hora_inicio AND turno_hora_fin < @turno_hora_fin and @turno_hora_inicio < turno_hora_fin) or
							  (turno_hora_inicio >= @turno_hora_inicio AND  turno_hora_fin <= @turno_hora_fin) 
							) AND  turno_habilitado > 0
					))

	-- TURNOS SOLAPADOS

	if  @solapado > 0  BEGIN
		set @error_message = 'El turno no puede agregarse o editarse solapando a otro turno';
		throw 60000, @error_message , 1;
		
	END

	-- TURNOS DUPLICADOS

	if  @cant > 0 BEGIN
		set @error_message = 'El turno ya existe';
		throw 50000, @error_message , 1;
		
	END


	insert into GARBAGE.Turno(turno_hora_inicio , turno_hora_fin , turno_descripcion , turno_valor_km , turno_precio_base , turno_habilitado)
	values (@turno_hora_inicio, @turno_hora_fin, @turno_descripcion, @turno_valor_km, @turno_precio_base , 1)

	return 1;

end
go

create procedure GARBAGE.updateTurno(@turno_id numeric(18,0) , @turno_hora_inicio numeric(18,0) , @turno_hora_fin numeric(18,0), @turno_descripcion varchar(255) , @turno_valor_km numeric(18,2) , @turno_precio_base numeric(18,2) , @turno_habilitado bit)
as
begin

	declare @error_message nvarchar(255)
	declare @cant int;
	declare @solapado int;
	
	set @cant = (select COUNT(*) from GARBAGE.TURNO  where turno_id = @turno_id );


	-- Solo busca por aquellos habilitados.

	set @solapado = (select COUNT (*) 
					from GARBAGE.Turno
					where ( ( (turno_hora_inicio <= @turno_hora_inicio AND  turno_hora_fin >= @turno_hora_fin) or 
							  (turno_hora_inicio >= @turno_hora_inicio AND turno_hora_fin > @turno_hora_fin and @turno_hora_fin > turno_hora_inicio) or
							  (turno_hora_inicio <= @turno_hora_inicio AND turno_hora_fin < @turno_hora_fin and @turno_hora_inicio < turno_hora_fin) or
							  (turno_hora_inicio >= @turno_hora_inicio AND  turno_hora_fin <= @turno_hora_fin) 
							) AND  turno_habilitado > 0
					))

	-- TURNOS SOLAPADOS

	if  (@solapado > 0 ) AND (@turno_habilitado > 0) BEGIN
		set @error_message = 'El turno no puede agregarse o editarse solapando a otro turno';
		throw 60000, @error_message , 1;
		
	END

	-- TURNOS DUPLICADOS

	if  @cant = 0 BEGIN
		set @error_message = 'El turno no existe';
		throw 50000, @error_message , 1;
	END

	update GARBAGE.Turno set turno_hora_inicio = @turno_hora_inicio, 
							 turno_hora_fin = @turno_hora_fin,
							 turno_descripcion = @turno_descripcion ,
							 turno_valor_km = @turno_valor_km ,
							 turno_precio_base = @turno_precio_base , 
							 turno_habilitado = @turno_habilitado 
	where turno_id = @turno_id;

	RETURN 1

end
go

create procedure GARBAGE.bajaLogicaTurno(@turno_id int)
as
begin
	
	update GARBAGE.Turno set turno_habilitado = 0
	where turno_id = @turno_id;
	RETURN 1

end
go





/******************************************************************************/
/******************************************************************************/
/**************************** VIAJE PROCEDURES ********************************/
/******************************************************************************/
/******************************************************************************/


create procedure GARBAGE.getAutomovilDisponible(@chof_id int)
as
begin
	
	(SELECT *
	 FROM GARBAGE.Automovil A , GARBAGE.ChoferxAutomovil CA , GARBAGE.Marca,GARBAGE.Modelo
	 WHERE A.auto_id = CA.chof_auto_auto_id AND
		   CA.chof_auto_chof_id = @chof_id AND
		   CA.chof_auto_habilitado = 1 AND 
		   A.auto_marca_id= marca_id AND A.auto_mod_id = mod_id)

end
go

create procedure GARBAGE.getTurnosByAutoId(@auto_id int)
as
begin
	-- Trae los turnos habilitados nomas.
	(SELECT *
	 FROM GARBAGE.Turno T , GARBAGE.TurnoxAutomovil TA
	 WHERE T.turno_id = TA.turno_auto_turno_id AND
			TA.turno_auto_auto_id = @auto_id AND
			T.turno_habilitado = 1)

end
go

create procedure GARBAGE.altaViaje(
            @viaje_auto_id int,
			@viaje_turno_id int,
			@viaje_chof_id int ,
			@viaje_cant_km numeric(18,2) ,
			@fecha_hora_ini datetime ,
			@fecha_hora_fin datetime,
			@viaje_cli_id int
			)
as
begin

	declare @viaje_duplicado int;
	declare @error_message nvarchar(255);
	declare @solapado int;

	
	set @viaje_duplicado = (SELECT COUNT(*) FROM GARBAGE.Viaje WHERE 
														viaje_auto_id = @viaje_auto_id AND
														viaje_turno_id = @viaje_turno_id AND
														viaje_chof_id = @viaje_chof_id AND
														viaje_cant_km = @viaje_cant_km AND
														fecha_hora_ini = @fecha_hora_ini AND
														fecha_hora_fin= @fecha_hora_fin AND
														viaje_cli_id = @viaje_cli_id)
	if  @viaje_duplicado > 0 BEGIN
		set @error_message = 'El viaje ya existe';
		throw 50000, @error_message , 1;
		
	END

	set @solapado = (select COUNT (*) 
					from GARBAGE.Viaje
					where ( ( (fecha_hora_ini <= @fecha_hora_ini AND  fecha_hora_fin >= @fecha_hora_fin) or 
							  (fecha_hora_ini >= @fecha_hora_ini AND fecha_hora_fin > @fecha_hora_fin and @fecha_hora_fin > fecha_hora_ini) or
							  (fecha_hora_ini <= @fecha_hora_ini AND fecha_hora_fin < @fecha_hora_fin and @fecha_hora_ini < fecha_hora_fin) or
							  (fecha_hora_ini >= @fecha_hora_ini AND  fecha_hora_fin <= @fecha_hora_fin) 
							)
						  AND (viaje_cli_id = @viaje_cli_id OR viaje_chof_id = @viaje_chof_id )
						  AND YEAR(@fecha_hora_ini) = YEAR(fecha_hora_ini) and MONTH(@fecha_hora_ini) = MONTH(fecha_hora_ini) and DAY(@fecha_hora_ini) = DAY(fecha_hora_fin)
					))
	
	-- VIAJES SOLAPADOS

	if  @solapado > 0  BEGIN
		set @error_message = 'El viaje no puede agregarse o editarse solapando a otro viaje';
		throw 60000, @error_message , 1;
		
	END


	INSERT INTO GARBAGE.Viaje(	viaje_auto_id
								,viaje_turno_id
								,viaje_chof_id
								,viaje_cant_km
								,fecha_hora_ini
								,fecha_hora_fin
								,viaje_cli_id
								)
	VALUES (
			 @viaje_auto_id
			,@viaje_turno_id
			,@viaje_chof_id
			,@viaje_cant_km 
			,@fecha_hora_ini
			,@fecha_hora_fin
			,@viaje_cli_id
				)

	RETURN 1

end
go





/**********************************************************************************/
/**********************************************************************************/
/**************************** RENDICION PROCEDURES ********************************/
/**********************************************************************************/
/**********************************************************************************/

create procedure GARBAGE.getTurnosViajesByChofer(@chof_id int)
as
begin
	select distinct turno_id, turno_descripcion, turno_hora_inicio, turno_hora_fin, turno_precio_base, turno_valor_km, turno_habilitado
	from GARBAGE.Viaje
	join GARBAGE.Turno on viaje_turno_id = turno_id
	where viaje_chof_id = @chof_id
	order by turno_hora_inicio
end
go

create procedure GARBAGE.getViajesNoRendidos(@chof_id int, @turno_id int, @fecha datetime, @porcentaje_rendicion numeric(3,2))
as
begin

	declare @valorKmTurno numeric(18,2);
	declare @precioBaseTurno numeric(18,2);

	select @valorKmTurno = turno_valor_km, @precioBaseTurno = turno_precio_base from GARBAGE.Turno where turno_id = @turno_id

	select viaje_id, viaje_auto_id, viaje_cli_id, fecha_hora_ini, fecha_hora_fin, viaje_cant_km,
			cast(@precioBaseTurno + (@valorKmTurno * viaje_cant_km)  as numeric(18,2)) as valor_viaje, 
			cast(cast(@precioBaseTurno + (@valorKmTurno * viaje_cant_km)  as numeric(18,2)) 
					* @porcentaje_rendicion as numeric(18,2)) as valor_rendicion
	from GARBAGE.Viaje
	where viaje_chof_id = @chof_id and viaje_turno_id = @turno_id and 
	YEAR(@fecha) = YEAR(fecha_hora_ini) and MONTH(@fecha) = MONTH(fecha_hora_ini) and DAY(@fecha) = DAY(fecha_hora_fin) and 
	YEAR(@fecha) = YEAR(fecha_hora_fin) and MONTH(@fecha) = MONTH(fecha_hora_fin) and DAY(@fecha) = DAY(fecha_hora_fin) and
	viaje_rendido = 0
end
go

IF EXISTS (SELECT * FROM sys.table_types WHERE name ='ViajeType')
    drop type GARBAGE.ViajeType
go

create type GARBAGE.ViajeType as table(
	viaje_id int not null
)
go

create procedure GARBAGE.generarRendicion(@chof_id int, @turno_id int, @fecha datetime, 
	@importe_total numeric(12,2), @viajes GARBAGE.ViajeType readonly)
as
begin
	
	if (select count(*) 
		from GARBAGE.Rendicion 
		where rend_fecha_pago = @fecha and rend_turno = @turno_id and rend_chofer = @chof_id) > 0
		throw 50000, 'Ya se ha rendido una rendicion este dia para este chofer en el turno seleccionado', 1;

	insert into GARBAGE.Rendicion (rend_fecha_pago, rend_chofer, rend_turno, rend_importe_total) 
	values (@fecha, @chof_id, @turno_id, @importe_total)

	update GARBAGE.Viaje set viaje_rendido = 1
	from @viajes V
	where V.viaje_id = GARBAGE.Viaje.viaje_id 
	
end
go





/**********************************************************************************/
/**********************************************************************************/
/**************************** RENDICION PROCEDURES ********************************/
/**********************************************************************************/
/**********************************************************************************/


CREATE FUNCTION GARBAGE.calcular_trimestre(@fecha datetime)
returns int
	
begin
	declare @respuesta int;

	set @respuesta = case
		when month(@fecha) IN (1, 2, 3) then 1
		when month(@fecha) IN (4, 5, 6) then 2
		when month(@fecha) IN (7, 8, 9) then 3
		when month(@fecha) IN (10, 11, 12) then 4
		end

return @respuesta
end
go

/* Choferes con mayor recaudacion */

CREATE PROCEDURE GARBAGE.choferes_mayor_recaudacion(@trimestre int, @anio int)
AS
BEGIN
	select top 5 chof_id, chof_nombre, chof_dni, sum(item_fac_costo) as total_recaudado
	from GARBAGE.Chofer join GARBAGE.Viaje on chof_id = viaje_chof_id join GARBAGE.ItemxFactura on item_fac_viaje_id = viaje_id
	where YEAR(fecha_hora_ini) = @anio and GARBAGE.calcular_trimestre(fecha_hora_ini) = @trimestre
	group by chof_id, chof_nombre, chof_dni
	order by sum(item_fac_costo) desc
END

go

/* Choferes con viaje mas largo realizado */

CREATE PROCEDURE GARBAGE.choferes_viaje_mas_largo(@trimestre int, @anio int)
AS
BEGIN

	select top 5 chof_id, chof_nombre, chof_dni, (select top 1 viaje_cant_km
												  from GARBAGE.Viaje V2
												  where v2.viaje_chof_id = C.chof_id
												  order by viaje_cant_km desc) as  viaje_mas_largo
	from GARBAGE.Chofer C join GARBAGE.Viaje V on viaje_chof_id = chof_id
	where YEAR(fecha_hora_ini) = @anio and GARBAGE.calcular_trimestre(fecha_hora_ini) = @trimestre
	group by chof_id, chof_nombre, chof_dni
	order by sum(viaje_cant_km) desc

END
go

/* Clientes con mayor consumo */ 

CREATE PROCEDURE GARBAGE.clientes_mayor_consumo(@trimestre int, @anio int)
AS
BEGIN

	select top 5 cli_id, cli_nombre, cli_apellido, sum(fact_total) as total_cliente, sum(fact_cant_viajes) as cant_viajes
	from GARBAGE.Cliente join GARBAGE.Factura on fact_cli_id = cli_id
	where YEAR(fact_fecha_ini) = @anio and GARBAGE.calcular_trimestre(fact_fecha_ini) = @trimestre
	group by cli_id, cli_nombre, cli_apellido
	order by sum(fact_total) desc
	
END
go

/* Cliente que utilizo mas veces el mismo automovil en los viajes que realizo */

CREATE PROCEDURE GARBAGE.clientes_mismo_auto(@trimestre int, @anio int)
AS
BEGIN

	select top 5 cli_id, cli_nombre, cli_apellido, cli_dni, auto_id, auto_patente, count(viaje_id) as cantidad_viajes
	from GARBAGE.Cliente join GARBAGE.Viaje on viaje_cli_id = cli_id join GARBAGE.Automovil on viaje_auto_id = auto_id
	where YEAR(fecha_hora_ini) = @anio and GARBAGE.calcular_trimestre(fecha_hora_ini) = @trimestre
	group by cli_id, cli_nombre, cli_apellido, cli_dni, auto_id, auto_patente
	order by cantidad_viajes desc
	
END
