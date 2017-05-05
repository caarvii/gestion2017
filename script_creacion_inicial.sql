USE [GD1C2017]
GO

--creacion esquema del grupo
if not exists(select * from sys.schemas where name = 'GARBAGE')
	execute('create schema [GARBAGE] authorization [gd]')
else 
	print('El esquema GARBAGE ya existe.')
GO


/**************************************
				ROL
**************************************/

create table [GARBAGE].Rol(
	rol_id numeric(18,0) primary key identity(0,1),
	rol_nombre nvarchar(255) unique NOT NULL,
	rol_activo bit default 1 NOT NULL
)
go

insert into [GARBAGE].Rol(rol_nombre)
	values
	('Administrador'),
	('Cliente'),
	('Chofer')
go

/**************************************
			FUNCIONALIDADES
**************************************/

create table [GARBAGE].Funcionalidad(
	func_id numeric(18,0) primary key identity(0,1),
	func_descripcion nvarchar(255) unique not null
)
GO

insert into [GARBAGE].Funcionalidad(func_descripcion)
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
	
/**************************************
		FUNCIONALIDAD DE CADA ROL
**************************************/

create table [GARBAGE].FuncionalidadxRol(
	func_rol_rol_id numeric(18,0) foreign key references [GARBAGE].Rol(rol_id) NOT NULL,
	func_rol_func_id numeric(18,0) foreign key references [GARBAGE].Funcionalidad(func_id) NOT NULL
	primary key(func_rol_rol_id, func_rol_func_id)
)
go