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
	primary key(rol_usu_rol_id, rol_usu_usu_id))
go


create table GARBAGE.Cliente(
	cli_id numeric(18,0) primary key identity (1,1),
	cli_nombre varchar(255) not null,
	cli_apellido varchar(255) not null,
	cli_dni numeric(18,0) not null,
	cli_telefono numeric(18,0) unique not null,
	cli_direccion varchar(255) not null,
	cli_fecha_nacimiento varchar(255) not null,
	cli_cp numeric(18,0) default 1 not null,
	cli_mail varchar(255), 
	cli_activo bit default 1 not null,
	cli_usu_id int foreign key references [GARBAGE].Usuario(usu_id))
go

/******************************************** FIN - CREACION DE TABLAS *********************************************/

/******************************************** INICIO - FOREING KEY *************************************************/

alter table GARBAGE.FuncionalidadxRol
add constraint FK_func_ron_rol_id foreign key (func_rol_rol_id) references GARBAGE.Rol(rol_id),
	constraint FK_func_ron_func_id foreign key (func_rol_func_id) references GARBAGE.Funcionalidad(func_id);

GO

alter table GARBAGE.RolxUsuario
add constraint FK_rol_usu_rol_id foreign key (rol_usu_rol_id) references GARBAGE.Rol(rol_id),
	constraint FK_rol_usu_usu_id foreign key (rol_usu_usu_id) references GARBAGE.Usuario(usu_id);
	
go

insert into GARBAGE.Rol(rol_nombre)
	values
	('Administrador'),
	('Cliente'),
	('Chofer')
go

print('Insertando Roles.')
go

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
go

print('Insertando Funcionalidades.')
go

--El Rol Administrador posee todas las funcionalidades
insert into GARBAGE.FuncionalidadxRol 
	select rol_id, func_id 
	from GARBAGE.Rol, GARBAGE.Funcionalidad where rol_id = 1
go

--TODO que funcionalidades tiene el cliente y el chofer???
--insert into GARBAGE.FuncionalidadxRol values (2,4),(2,6),(2,7),(2,8),(2,9),(2,10),(2,11),(2,12);
--go

-- Buscar cual seria la contrasela w23e en este hash

print('Insertando Funcionalidades x Rol.')
go

declare @hash binary(32)
set @hash = convert(binary(32),'0xe6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',1)

insert into GARBAGE.Usuario(usu_username,usu_password)
values
	('admin', @hash),
	('david', @hash),
	('fede', @hash),
	('nico', @hash),
	('fer', @hash)
go

print('Insertando Usuarios base.')
go

insert into GARBAGE.RolxUsuario(rol_usu_rol_id , rol_usu_usu_id)
(
	select R.rol_id , S.usu_id
	from GARBAGE.Usuario S 
	join GARBAGE.Rol R on R.rol_nombre = 'Administrador'
)
go

print('Insertando Usuarios admin.')
go

insert into GARBAGE.Cliente (
	cli_nombre, 
	cli_apellido, 
	cli_dni, 
	cli_telefono, 
	cli_direccion, 
	cli_fecha_nacimiento, 
	cli_mail, 
	cli_cp)
(
	select distinct Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Telefono, 
					Cliente_Direccion, Cliente_Fecha_Nac, Cliente_Mail, 0
	from gd_esquema.Maestra
)
go

print('Insertando Clientes.')
go
