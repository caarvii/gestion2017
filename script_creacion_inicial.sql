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

/**************************************
			USUARIO
**************************************/

-- Tener en cuenta que se debe encriptar la contraseña como SHA256
-- Agregar el usuario "admin" y pass "w23e"
-- perfil Administrador

CREATE TABLE [GARBAGE].Usuario(
	usu_id numeric(18,0) primary key identity (0,1),
	usu_username nvarchar(255) unique NOT NULL,
	usu_password nvarchar(255) NOT NULL,
	usu_activo bit default 1 NOT NULL,
	usu_intentos numeric(1,0) default 0 NOT NULL)
GO

-- Buscar cual seria la contrasela w23e en este hash

DECLARE @hash binary(32)
SET @hash =  CONVERT(binary(32),'0xe6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',1)

INSERT INTO [GARBAGE].Usuario(usu_username,usu_password)
VALUES
	('admin', @hash),
	('david', @hash),
	('fede', @hash),
	('nico', @hash),
	('fer', @hash)
GO

/**************************************
			ROL POR USUARIO
**************************************/

create table [GARBAGE].RolxUsuario(
	rol_usu_rol_id numeric(18,0) foreign key references [GARBAGE].Rol(rol_id) NOT NULL,
	rol_usu_usu_id numeric(18,0) foreign key references [GARBAGE].Usuario(usu_id) NOT NULL
	primary key(rol_usu_rol_id, rol_usu_usu_id)
)
go

INSERT INTO [GARBAGE].RolxUsuario(rol_usu_rol_id , rol_usu_usu_id)
(
	SELECT R.rol_id , S.usu_id
	FROM [GARBAGE].Usuario S 
	JOIN [GARBAGE].Rol R ON S.usu_username = 'admin' AND R.rol_nombre = 'Administrador'
)
GO

