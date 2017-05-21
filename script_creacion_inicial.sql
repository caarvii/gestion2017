use [GD1C2017]
go

--creacion esquema del grupo
if not exists(select * from sys.schemas where name = 'GARBAGE')
	execute('create schema [GARBAGE] authorization [gd]')
else 
	print('El esquema GARBAGE ya existe.')
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
	usu_password char(64) not null,
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
	cli_fecha_nacimiento varchar(255) not null,
	cli_cp numeric(18,0) default 1 not null,
	cli_mail varchar(255), 
	cli_activo bit default 1 not null,
	cli_usu_id int )
go

create table GARBAGE.Factura(
	fact_id int constraint PK_fact_id primary key identity (1,1),
	fact_fecha_ini datetime not null,
	fact_fecha_fin datetime not null,
	fact_cli_id int,
	fact_total decimal (12,2) ,
	fact_cant_viajes int
)
go

-- TODO - fact_total y fact_cant_viajes NULL por el momento . Se calculara despues

create table GARBAGE.ItemxFactura(
	item_fac_id int not null ,
	item_fac_fac_id int not null ,--foreign key references [GARBAGE].Factura(fact_id) not null,
	item_fac_viaje_id int not null,--foreign key references [GARBAGE].Viaje(viaje_id) not null,
	item_fac_costo decimal(12,2),
	item_fac_descripcion varchar(255) not null ,
	constraint PK_item_x_factura primary key(item_fac_id, item_fac_fac_id, item_fac_viaje_id)
)
go



create table GARBAGE.Chofer(
	chof_id int constraint PK_chof_id primary key identity (1,1),
	chof_nombre varchar(255) not null,
	chof_apellido varchar(255) not null,
	chof_dni numeric(18,0) not null,
	chof_telefono numeric(18,0) not null,
	chof_direccion varchar(255) not null,
	chof_fecha_nacimiento varchar(255) not null,
	chof_mail varchar(255) not null,
	chof_activo bit default 1 not null,
	chof_usu_id int)
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
add constraint FK_cli_usu_id foreign key (cli_usu_id) references [GARBAGE].Usuario(usu_id);
go

alter table GARBAGE.Factura
add constraint FK_fact_cli_id foreign key (fact_cli_id) references GARBAGE.Cliente(cli_id);
go

/* Falta FK de ItemxFactura de id_viaje.  - TODO -*/

alter table GARBAGE.Chofer
add constraint FK_chof_usu_id foreign key (chof_usu_id) references [GARBAGE].Usuario(usu_id);
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
	('Rendicion de cuenta del Chofer'),
	('Facturacion a Cliente'),
	('Listado Estadístico')


print('Insertando Funcionalidades.');

--El Rol Administrador posee todas las funcionalidades
insert into GARBAGE.FuncionalidadxRol 
	select rol_id, func_id 
	from GARBAGE.Rol, GARBAGE.Funcionalidad 
	where rol_id = 1;

--TODO que funcionalidades tiene el cliente y el chofer???
--insert into GARBAGE.FuncionalidadxRol values (2,4),(2,6),(2,7),(2,8),(2,9),(2,10),(2,11),(2,12);
--go



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

end
go

-- FACTURAS

insert into GARBAGE.Factura(fact_id,fact_fecha_ini,fact_fecha_fin)(
	select DISTINCT  Factura_Nro,Factura_Fecha_Inicio , Factura_Fecha_Fin
	from gd_esquema.Maestra
	WHERE Factura_Nro IS NOT NULL
);

update GARBAGE.Factura set fact_cli_id = cli_id
	from GARBAGE.Factura, GARBAGE.Cliente , gd_esquema.Maestra M
	where fact_id = M.Factura_Nro AND cli_dni = M.Cliente_Dni

-- TODO - Calcular la cantidad de viajes.
-- TODO - Calcular el monto total en base a los viajes.
-- alter table GARBAGE.Factura alter column fact_cant_viajes int not null
-- alter table GARBAGE.Factura alter column fact_total int not null

print ('Agregando facturas');

-- TODO - Generar funciones para calcular fact_total en base a ItemxFactura
-- una vez que este bien armada la tabla VIAJE.



exec GARBAGE.SPMigracion;