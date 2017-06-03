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
	item_fac_id int not null identity (1,1),
	item_fac_fac_id int not null ,
	item_fac_viaje_id int not null,
	item_fac_costo decimal(12,2),
	item_fac_descripcion varchar(255),
	item_fac_duplicado int not null,
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
	viaje_rendido bit default 0 NOT NULL) --Hay que actualizarlo cuando se hace la tabla de rendiciones

GO

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

alter table GARBAGE.ItemxFactura
add constraint FK_fact_fact_id foreign key (item_fac_fac_id) references GARBAGE.Factura(fact_id),
	constraint FK_fact_viaje_id foreign key (item_fac_viaje_id) references GARBAGE.Viaje(viaje_id);
go

alter table GARBAGE.Chofer
add constraint FK_chof_usu_id foreign key (chof_usu_id) references GARBAGE.Usuario(usu_id);
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



---------------- CREO VARIABLES AUXILIARES --------------

	DECLARE @viaje_auto_id [int], 
			@viaje_turno_id [int],
			@viaje_chof_id [int],
			@viaje_cli_id [int]

---------------CREO VARIABLES PARA VOLCAR DATOS DEL CURSOR-------

	DECLARE @Auto_Patente [varchar] (10),
			@chofer_dni [numeric](18,0),
			@Viaje_Cant_Kilometros [numeric](18,0),
			@Viaje_Fecha datetime,
			@Turno_Descripcion [varchar] (255),
			@Cliente_dni [numeric](18,0)

---------------- CREO CURSOR --------------

	DECLARE cursor_migracion_viajes CURSOR FOR 
			(SELECT DISTINCT Auto_Patente,Chofer_Dni,Viaje_Cant_Kilometros,Viaje_Fecha,Turno_Descripcion,Cliente_Dni 
			FROM gd_esquema.Maestra 
			WHERE Rendicion_Nro is null AND Factura_Nro is null)
			
	OPEN cursor_migracion_viajes;

	FETCH NEXT FROM cursor_migracion_viajes
	INTO  @Auto_Patente,
		  @chofer_dni,
		  @Viaje_Cant_Kilometros,
		  @Viaje_Fecha,
		  @Turno_Descripcion,
		  @Cliente_dni

	WHILE @@FETCH_STATUS = 0
	BEGIN

	SET @viaje_auto_id = (SELECT A.auto_id	FROM GARBAGE.Automovil A WHERE @Auto_Patente = A.auto_patente)
	SET @viaje_turno_id = (SELECT T.turno_id FROM GARBAGE.Turno T WHERE @Turno_Descripcion = T.turno_descripcion)
	SET @viaje_chof_id = (SELECT C.chof_id FROM GARBAGE.Chofer C WHERE @chofer_dni = C.chof_dni)
	SET @viaje_cli_id = (SELECT	c.cli_id  FROM GARBAGE.Cliente C WHERE @Cliente_dni = c.cli_dni)
	
	INSERT INTO GARBAGE.Viaje ([viaje_auto_id],[viaje_turno_id], [viaje_chof_id],[viaje_cant_km],[fecha_hora_ini],[fecha_hora_fin],[viaje_cli_id]) 
							  VALUES (@viaje_auto_id,@viaje_turno_id,@viaje_chof_id, @Viaje_Cant_Kilometros, @Viaje_Fecha, @Viaje_Fecha, @viaje_cli_id);

	FETCH NEXT FROM cursor_migracion_viajes
	INTO  @Auto_Patente,
		  @chofer_dni,
		  @Viaje_Cant_Kilometros,
		  @Viaje_Fecha,
		  @Turno_Descripcion,
		  @Cliente_dni
	END

	CLOSE cursor_migracion_viajes
	DEALLOCATE cursor_migracion_viajes;


	print ('Agregando los viajes');


insert into GARBAGE.ItemxFactura (item_fac_fac_id,item_fac_viaje_id,item_fac_duplicado)
	(
		
	SELECT F.fact_id , V.viaje_id , FVV.repetido
	FROM GARBAGE.FacturaViajeView FVV , GARBAGE.Viaje V , GARBAGE.Factura F
	WHERE (SELECT auto_id FROM GARBAGE.Automovil WHERE FVV.patente = auto_patente) = v.viaje_auto_id AND
		   FVV.viaje_km = V.viaje_cant_km AND
		   FVV.viaje_fecha = V.fecha_hora_fin AND
		   (SELECT cli_id FROM GARBAGE.Cliente WHERE FVV.cli_dni = cli_dni) = V.viaje_cli_id AND
		   (SELECT chof_id FROM GARBAGE.Chofer WHERE FVV.chofer_dni = chof_dni) = V.viaje_chof_id AND
		   FVV.fact_nro = F.fact_id

	)


print ('Agregando item por cada factura');

end
go

-- FACTURAS:

-- TODO - Calcular la cantidad de viajes.
-- TODO - Calcular el monto total en base a los viajes.
-- alter table GARBAGE.Factura alter column fact_cant_viajes int not null
-- alter table GARBAGE.Factura alter column fact_total int not null

-- TODO - Generar funciones para calcular fact_total en base a ItemxFactura
-- una vez que este bien armada la tabla VIAJE.



exec GARBAGE.SPMigracion;

