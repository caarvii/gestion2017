/********************************************* INICIO - CREACION ESQUEMA *******************************************/

USE GD1C2015;
GO
/*CREATE SCHEMA THE_ULTIMATES AUTHORIZATION gd

GO */

/********************************************* FIN - CREACION ESQUEMA **********************************************/

/******************************************** INICIO - CREACION DE TABLAS ******************************************/

create table THE_ULTIMATES.Rol( 
	rol_id int CONSTRAINT PK_rol_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	rol_desc varchar(15),
	rol_activo bit DEFAULT 1  
);

GO	

create table THE_ULTIMATES.Funcionalidad(
	func_id int CONSTRAINT PK_func_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	func_desc varchar(60)
);

GO
	
create table THE_ULTIMATES.Funcionalidad_Rol(
	func_rol_rol_id int  not null, /* FK  THE_ULTIMATES.Rol*/
	func_rol_func_id int not null,/* FK  THE_ULTIMATES.Funcionalidad*/
	CONSTRAINT PK_funcionalidad_rol PRIMARY KEY (func_rol_rol_id, func_rol_func_id)
); 

GO

create table THE_ULTIMATES.Usuario(
	usu_id int CONSTRAINT PK_usu_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	usu_username varchar(25) not null UNIQUE,
	usu_password char(64) not null,
	usu_fecha_alta datetime not null,
	usu_fecha_mod datetime null,
	usu_pregunta varchar(50),
	usu_respuesta char(64),
	usu_activo bit DEFAULT 0,
	usu_intentos_fallidos int not null,
);

GO

create table THE_ULTIMATES.Rol_Usuario(
	rol_usu_rol_id int  not null, /* FK  THE_ULTIMATES.Rol*/
	rol_usu_usu_id int  not null,  /* FK  THE_ULTIMATES.Usuario*/
	CONSTRAINT PK_rol_usuario PRIMARY KEY (rol_usu_rol_id, rol_usu_usu_id)
);
	
GO

create table THE_ULTIMATES.Acceso_Log(
	acc_id int CONSTRAINT PK_acc_id PRIMARY KEY not null IDENTITY(1,1),
	acc_usu_id int  not null, /* FK  THE_ULTIMATES.Usuario*/
	acc_fecha datetime not null,
	acc_correcto bit not null,
	acc_intent_fallido int not null
);

GO
	
create table THE_ULTIMATES.Pais(
	pais_id numeric(18,0) CONSTRAINT PK_pais_id PRIMARY KEY not null IDENTITY(1,1),
	pais_desc varchar(250) not null
);

GO

create table THE_ULTIMATES.Tipo_Doc(
	tipo_doc_id numeric(18,0) CONSTRAINT PK_tipo_doc_id PRIMARY KEY not null IDENTITY(1,1),
	tipo_doc_desc varchar(255) not null
);

GO
	
create table THE_ULTIMATES.Cliente(
	clie_id int CONSTRAINT PK_clie_id PRIMARY KEY not null IDENTITY(1,1),
	clie_nombre varchar(255) not null,
	clie_apellido varchar(255) not null,
	clie_nro_doc numeric(18,0) not null unique, 
	clie_tipo_doc_id numeric(18,0) not null, /* FK  THE_ULTIMATES.Tipo_Doc*/
	clie_mail varchar(255) not null unique,
	clie_activo bit not null,
	clie_dom_calle varchar(255) not null,
	clie_dom_numero numeric(18,0) not null,
	clie_dom_piso numeric(18,0) null,
	clie_dom_depto varchar(10),
	clie_fecha_nac datetime not null,
	clie_pais_id numeric(18,0) not null, /* FK  THE_ULTIMATES.Pais*/
	clie_usu_id int
);

GO
	
create table THE_ULTIMATES.Cuenta(
	cuen_id numeric(18,0) CONSTRAINT PK_cuen_id PRIMARY KEY not null IDENTITY(1,1),
	cuen_clie_id int not null, /* FK  THE_ULTIMATES.Cliente*/
	cuen_tipo_cuenta_id int not null, /* FK  THE_ULTIMATES.Tipo_Cuenta*/
	cuen_fecha_creacion datetime not null,
	cuen_fecha_cierre datetime,
	cuen_estado_id int not null, /* FK  THE_ULTIMATES.Estado_Cuenta*/
	cuen_pais_id numeric(18,0) not null, /* FK  THE_ULTIMATES.Pais*/
	cuen_saldo numeric(18,2) not null,
	cuen_tipo_mon_id int not null /* FK  THE_ULTIMATES.Tipo_Moneda*/
);

GO
	
create table THE_ULTIMATES.Tipo_Moneda(
	tipo_moneda_id int CONSTRAINT PK_tipo_moneda_id PRIMARY KEY not null IDENTITY(1,1),
	tipo_moneda_desc varchar(30) not null,
	tipo_moneda_codigo char(3) not null unique, 
	tipo_moneda_cambio numeric(18,3)not null
);

GO
	
create table THE_ULTIMATES.Estado_Cuenta(
	esta_cuenta_id int CONSTRAINT PK_esta_cuenta_id PRIMARY KEY not null IDENTITY(1,1),
	esta_cuenta_desc varchar(255) not null
);

GO

create table THE_ULTIMATES.Tipo_Cuenta(
	tipo_cuenta_id int CONSTRAINT PK_tipo_cuenta_id PRIMARY KEY not null IDENTITY(1,1),
	tipo_cuenta_desc varchar(30)not null,
	tipo_cuenta_duracion int not null,
	tipo_cuenta_costo numeric(18,2) not null
);

GO

create table THE_ULTIMATES.Tarjeta(
	tarj_id int CONSTRAINT PK_tarj_id PRIMARY KEY not null IDENTITY(1,1),
	tarj_clie_id int not null,  /* FK  THE_ULTIMATES.Cliente*/
	tarj_numero char(20) not null UNIQUE,
	tarj_numero_preview char(4) not null,
	tarj_emisor_id int not null, /* FK  THE_ULTIMATES.Emisor*/
	tarj_fecha_emision datetime not null,
	tarj_fecha_venc datetime not null,
	tarj_codigo_seg char(20),
	tarj_activa bit default 1 not null
);

GO

create table THE_ULTIMATES.Emisor(
	emisor_id int CONSTRAINT PK_emisor_id PRIMARY KEY not null IDENTITY(1,1),
	emisor_desc varchar(30)
); 
	
GO

create table THE_ULTIMATES.Deposito(
	depo_id numeric(18,0) CONSTRAINT PK_depo_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	depo_fecha datetime not null,
	depo_importe numeric(18,2) not null,
	depo_cuen_id numeric(18,0) not null,  /* FK  THE_ULTIMATES.Cuenta*/
	depo_tarj_id int not null,  /* FK  THE_ULTIMATES.Tarjeta*/
	depo_tipo_moneda_id int not null /* FK  THE_ULTIMATES.Tipo_Moneda*/
);
	
GO

create table THE_ULTIMATES.Cheque(
	cheque_numero numeric(18,0) CONSTRAINT PK_cheque_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	cheque_fecha datetime not null,
	cheque_importe numeric(18,2)not null,
	cheque_nombre_completo varchar(30),
	cheque_banco_id numeric(18,0) not null  /* FK  THE_ULTIMATES.Banco*/
);
	
GO

create table THE_ULTIMATES.Transferencia(
	transf_id int CONSTRAINT PK_transf_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	transf_fecha datetime not null,
	transf_cuenta_origen numeric(18,0) not null, /* FK  THE_ULTIMATES.Cuenta*/
	transf_cuenta_destino numeric(18,0) not null, /* FK  THE_ULTIMATES.Cuenta*/
	transf_importe numeric(18,2)not null,
	transf_costo_transf numeric(18,2)not null,
	transf_cuenta_propia bit null 
);

GO

create table THE_ULTIMATES.Transaccion(
	transac_id int CONSTRAINT PK_transac_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	transac_fecha datetime not null,
	transac_cuen_id numeric(18,0) not null, /* FK  THE_ULTIMATES.Cuenta*/
	transac_tipo_transac_id int not null, /* FK  THE_ULTIMATES.Tipo_Transaccion*/
	transac_importe_comision numeric(18,3)not null,
	transac_pendiente bit not null	
);

GO

create table THE_ULTIMATES.Tipo_Transaccion(
	tipo_transac_id int CONSTRAINT PK_tipo_transac_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	tipo_transac_desc varchar(50) not null,
	tipo_transac_facturable bit not null
);

GO

create table THE_ULTIMATES.Extraccion(
	extrac_id numeric(18,0) CONSTRAINT PK_extrac_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	extrac_cuenta_id numeric(18,0) not null, /* FK  THE_ULTIMATES.Cuenta*/
	extrac_cheque_numero numeric(18,0) not null /* FK  THE_ULTIMATES.Cheque*/
);

GO

create table THE_ULTIMATES.Banco(
	banco_id numeric(18,0) CONSTRAINT PK_banco_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	banco_nombre varchar(255) not null,
	banco_direc varchar(255) not null
);

GO

create table THE_ULTIMATES.Factura(
	fact_num int CONSTRAINT PK_fact_num PRIMARY KEY NOT NULL IDENTITY(1,1),
	fact_fecha datetime not null,
	fact_clie_id int not null, /* FK  THE_ULTIMATES.Cliente*/
);

GO 

/*create table THE_ULTIMATES.Item_Factura(
	item_fact_id int CONSTRAINT PK_item_fact_id PRIMARY KEY NOT NULL IDENTITY(1,1),
	item_fact_num int not null, /* FK  THE_ULTIMATES.Factura*/
	item_fact_desc varchar(250) not null,
	item_fact_precio numeric(18,3)not null
);
*/

create table THE_ULTIMATES.Item_Factura(
	item_fact_num int not null, /* FK  THE_ULTIMATES.Factura*/
	item_fact_transac_id int not null,  /* FK  THE_ULTIMATES.Transaccion*/
	item_fact_cantidad int not null,
	CONSTRAINT PK_item_factura PRIMARY KEY (item_fact_num, item_fact_transac_id)
);


GO

/******************************************** FIN - CREACION DE TABLAS *********************************************/


/******************************************** INICIO - FOREING KEY *************************************************/

alter table THE_ULTIMATES.Funcionalidad_Rol
add constraint FK_func_ron_rol_id foreign key (func_rol_rol_id) references THE_ULTIMATES.Rol(rol_id),
	constraint FK_func_ron_func_id foreign key (func_rol_func_id) references THE_ULTIMATES.Funcionalidad(func_id);

GO

alter table THE_ULTIMATES.Rol_Usuario
add constraint FK_rol_usu_rol_id foreign key (rol_usu_rol_id) references THE_ULTIMATES.Rol(rol_id),
	constraint FK_rol_usu_usu_id foreign key (rol_usu_usu_id) references THE_ULTIMATES.Usuario(usu_id);
	
go

alter table THE_ULTIMATES.Acceso_Log
add constraint FK_acc_usu_id foreign key (acc_usu_id) references THE_ULTIMATES.Usuario(usu_id);

go

alter table THE_ULTIMATES.Cliente
add constraint FK_clie_tipo_doc_id foreign key (clie_tipo_doc_id) references THE_ULTIMATES.Tipo_Doc(tipo_doc_id),
	constraint FK_clie_pais_id foreign key (clie_pais_id) references THE_ULTIMATES.Pais(pais_id),
	constraint FK_clie_usu_id foreign key (clie_usu_id) references THE_ULTIMATES.Usuario(usu_id);

go

alter table THE_ULTIMATES.Cuenta
add constraint FK_cuen_clie_id foreign key (cuen_clie_id) references THE_ULTIMATES.Cliente(clie_id),
	constraint FK_cuen_tipo_cuenta_id foreign key (cuen_tipo_cuenta_id) references THE_ULTIMATES.Tipo_Cuenta(tipo_cuenta_id),
	constraint FK_cuen_estado_id foreign key (cuen_estado_id) references THE_ULTIMATES.Estado_cuenta(esta_cuenta_id),
	constraint FK_cuen_pais_id foreign key (cuen_pais_id) references THE_ULTIMATES.Pais(pais_id),
	constraint FK_cuen_tipo_mon_id foreign key (cuen_tipo_mon_id) references THE_ULTIMATES.Tipo_Moneda(tipo_moneda_id);
	
go

alter table THE_ULTIMATES.Tarjeta
add constraint FK_tarj_clie_id foreign key (tarj_clie_id) references THE_ULTIMATES.Cliente(clie_id),
	constraint FK_tarj_emisor_id foreign key (tarj_emisor_id) references THE_ULTIMATES.Emisor(emisor_id);
	
go

alter table THE_ULTIMATES.Deposito
add constraint FK_depo_cuen_id foreign key (depo_cuen_id) references THE_ULTIMATES.Cuenta(cuen_id),
	constraint FK_depo_tarj_id foreign key (depo_tarj_id) references THE_ULTIMATES.Tarjeta(tarj_id),
	constraint FK_depo_tipo_moneda_id foreign key (depo_tipo_moneda_id) references THE_ULTIMATES.Tipo_Moneda(tipo_moneda_id);

go

alter table THE_ULTIMATES.Cheque
add constraint FK_cheque_banco_id foreign key (cheque_banco_id) references THE_ULTIMATES.Banco(banco_id);

go

alter table THE_ULTIMATES.Transferencia
add constraint FK_transf_cuenta_origen foreign key (transf_cuenta_origen) references THE_ULTIMATES.Cuenta(cuen_id),
	constraint FK_transf_cuenta_destino foreign key (transf_cuenta_destino) references THE_ULTIMATES.Cuenta(cuen_id);

go

alter table THE_ULTIMATES.Transaccion
add constraint FK_transac_cuen_id foreign key (transac_cuen_id) references THE_ULTIMATES.Cuenta(cuen_id),
	constraint FK_transac_tipo_transac_id foreign key (transac_tipo_transac_id) references THE_ULTIMATES.Tipo_Transaccion(tipo_transac_id);

go

alter table THE_ULTIMATES.Extraccion
add constraint FK_extrac_cuenta_id foreign key (extrac_cuenta_id) references THE_ULTIMATES.Cuenta(cuen_id),
	constraint FK_extrac_cheque_numero foreign key (extrac_cheque_numero) references THE_ULTIMATES.Cheque(cheque_numero);
	
go

alter table THE_ULTIMATES.Factura
add constraint FK_fact_clie_id foreign key (fact_clie_id) references THE_ULTIMATES.Cliente(clie_id);

go

alter table THE_ULTIMATES.Item_Factura
add constraint FK_item_fact_num foreign key(item_fact_num) references THE_ULTIMATES.Factura(fact_num),
	constraint FK_item_fact_transac_id foreign key(item_fact_transac_id) references THE_ULTIMATES.Transaccion(transac_id);

go

/******************************************** FIN - FOREING KEY ****************************************************/


/******************************************** INICIO - CREACION DE INDICES *****************************************/
/******************************************** FIN - CREACION DE INDICES *****************************************/
/******************************************** INICIO - CREACION DE STORED PROCEDURES, FUNCIONES Y VISTAS *************/
go

CREATE FUNCTION THE_ULTIMATES.RemoverTildes(@Cadena VARCHAR(25))
RETURNS VARCHAR(25)
AS BEGIN
    RETURN REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@Cadena, ' ', ''), 'á', 'a'), 'é','e'), 'í', 'i'), 'ó', 'o'), 'ú','u')
END
go

CREATE FUNCTION THE_ULTIMATES.GenerarUsuario(@nombre varchar(255), @apellido varchar(255))
RETURNS VARCHAR(25)
AS BEGIN	
	RETURN THE_ULTIMATES.RemoverTildes(lower(SUBSTRING(@nombre, 1,19) + '.' + SUBSTRING(@apellido, 1,19)))
END
go

create function THE_ULTIMATES.esDelMismoCliente(@CuentaOrigen numeric(18,0),@CuentaDestino numeric(18,0))
returns int
as begin
	
	declare @cuentaPropia int = (select 1 from THE_ULTIMATES.Cuenta c1, THE_ULTIMATES.Cuenta c2 
								where @CuentaOrigen = c1.cuen_id and @CuentaDestino = c2.cuen_id
								and c1.cuen_clie_id = c2.cuen_clie_id)
	if(@cuentaPropia is null)
		set @cuentaPropia = 0;
	 
	return @cuentaPropia;
end
go

create function THE_ULTIMATES.esDelMismoCliente2(@CuentaOrigen numeric(18,0),@CuentaDestino numeric(18,0))
returns int
as begin

	declare @cuentaPropia int;	
	declare @clienteOrigen int = (select cuen_clie_id from THE_ULTIMATES.Cuenta where @CuentaDestino = cuen_id);
	declare @clienteDestino int = (select cuen_clie_id from THE_ULTIMATES.Cuenta where @CuentaOrigen = cuen_id);	
	
	if(@clienteOrigen = @clienteDestino)
		set @cuentaPropia = 1
	else 
		set @cuentaPropia = 0;
	
	return @cuentaPropia;
end
go

create function THE_ULTIMATES.getClientId(@Cuenta numeric(18,0))
returns int
as begin
	return (select cuen_clie_id from THE_ULTIMATES.Cuenta where @Cuenta = cuen_id)
end
go

create procedure THE_ULTIMATES.SP_CargarCuentas 
as 
begin

set identity_insert THE_ULTIMATES.Cuenta on;

insert into THE_ULTIMATES.Cuenta (cuen_id, cuen_clie_id, cuen_tipo_cuenta_id,
	cuen_fecha_creacion, cuen_fecha_cierre, cuen_estado_id, cuen_pais_id, 
	cuen_saldo, cuen_tipo_mon_id)
	select distinct Cuenta_Numero, 
		(select clie_id from THE_ULTIMATES.Cliente 
		where clie_tipo_doc_id = Cli_Tipo_Doc_Cod and clie_nro_doc = Cli_Nro_Doc),
		4, Cuenta_Fecha_Creacion, null, 4, Cuenta_Pais_Codigo, 0.00, 1
	from gd_esquema.Maestra
	where Cuenta_Numero is not null;

set identity_insert THE_ULTIMATES.Cuenta off;

end
go

create procedure THE_ULTIMATES.SP_CargarTransferencias
as
begin

insert into THE_ULTIMATES.Transferencia (transf_cuenta_origen, transf_cuenta_destino, transf_fecha,
	transf_importe, transf_costo_transf, transf_cuenta_propia)
	select Cuenta_Numero, Cuenta_Dest_Numero, Transf_Fecha, Trans_Importe, Trans_Costo_Trans, 
	THE_ULTIMATES.esDelMismoCliente(Cuenta_Numero, Cuenta_Dest_Numero)
	from gd_esquema.Maestra
	where Cuenta_Dest_Numero is not null
	
end
go

create procedure THE_ULTIMATES.SP_CargarTransferencias2
as
begin

insert into THE_ULTIMATES.Transferencia (transf_cuenta_origen, transf_cuenta_destino, transf_fecha,
	transf_importe, transf_costo_transf, transf_cuenta_propia)
	select Cuenta_Numero, Cuenta_Dest_Numero, Transf_Fecha, Trans_Importe, Trans_Costo_Trans, 
	(select 1 from THE_ULTIMATES.Cuenta c1, THE_ULTIMATES.Cuenta c2 where Cuenta_Numero = c1.cuen_id
	and Cuenta_Dest_Numero = c2.cuen_id and c1.cuen_clie_id = c2.cuen_clie_id)
	from gd_esquema.Maestra
	where Cuenta_Dest_Numero is not null and Factura_Numero is null
	
update THE_ULTIMATES.Transferencia set transf_cuenta_propia = 0
where transf_cuenta_propia is null

alter table THE_ULTIMATES.Transferencia 
alter column transf_cuenta_propia bit not null 
end				
go

create procedure THE_ULTIMATES.SP_CargarBancos
as begin

set identity_insert THE_ULTIMATES.Banco on;

insert into THE_ULTIMATES.Banco (banco_id, banco_nombre, banco_direc)
	select distinct Banco_Cogido, Banco_Nombre, Banco_Direccion
	from gd_esquema.Maestra
	where Banco_Cogido is not null
	
set identity_insert THE_ULTIMATES.Banco off;

end
go

create procedure THE_ULTIMATES.SP_CargarCheques
as begin

set identity_insert THE_ULTIMATES.Cheque on;

insert into THE_ULTIMATES.Cheque (cheque_numero, cheque_fecha, cheque_importe, cheque_nombre_completo, cheque_banco_id)
	select distinct Cheque_Numero,Cheque_Fecha, Cheque_Importe, Cli_Nombre + ', ' + Cli_Apellido, Banco_Cogido
	from gd_esquema.Maestra
	where Cheque_Numero is not null
	
set identity_insert THE_ULTIMATES.Cheque off;

end
go

create procedure THE_ULTIMATES.SP_CargarExtracciones
as begin

set identity_insert THE_ULTIMATES.Extraccion on;

insert into THE_ULTIMATES.Extraccion (extrac_id, extrac_cheque_numero, extrac_cuenta_id)
	select distinct Retiro_Codigo, Cheque_Numero, Cuenta_Numero
	from gd_esquema.Maestra
	where Retiro_Codigo is not null

set identity_insert THE_ULTIMATES.Extraccion off;
end
go

create procedure THE_ULTIMATES.SP_CargarFacturas
as 
begin

	set identity_insert THE_ULTIMATES.Factura on;

	insert into THE_ULTIMATES.Factura (fact_num, fact_fecha, fact_clie_id)
		select distinct Factura_Numero, Factura_Fecha, THE_ULTIMATES.getClientId(Cuenta_Numero)
		from gd_esquema.Maestra
		where Factura_Numero is not null
		
	set identity_insert THE_ULTIMATES.Factura off;

end
go

create procedure THE_ULTIMATES.SP_CargarEmisores
as 
begin
	insert into THE_ULTIMATES.Emisor
	select distinct Tarjeta_Emisor_Descripcion
	from gd_esquema.Maestra
	where Tarjeta_Emisor_Descripcion is not null
end
go

create procedure THE_ULTIMATES.SP_CargarTarjetas
as 
begin
	insert into THE_ULTIMATES.Tarjeta (tarj_numero, tarj_numero_preview, tarj_fecha_emision,
										tarj_fecha_venc, tarj_codigo_seg, tarj_emisor_id, tarj_clie_id)
		select distinct HASHBYTES('SHA1', Tarjeta_Numero), RIGHT(Tarjeta_Numero, 4),
				Tarjeta_Fecha_Emision, Tarjeta_Fecha_Vencimiento, HASHBYTES('SHA1', Tarjeta_Codigo_Seg), 
				(select emisor_id from THE_ULTIMATES.Emisor 
				 where emisor_desc = Tarjeta_Emisor_Descripcion),
				(select clie_id from THE_ULTIMATES.Cliente
				 where Cliente.clie_tipo_doc_id = Cli_Tipo_Doc_Cod and Cliente.clie_nro_doc = Cli_Nro_Doc)
		from gd_esquema.Maestra 
		where Tarjeta_Numero is not null
end
go

create procedure THE_ULTIMATES.SP_CargarDepositos
as 
begin
	set identity_insert THE_ULTIMATES.Deposito on;

	insert into THE_ULTIMATES.Deposito (depo_id, depo_fecha, depo_importe, 
										depo_cuen_id, depo_tarj_id, depo_tipo_moneda_id)
		select distinct Deposito_Codigo, 
						Deposito_Fecha, 
						Deposito_Importe, 
						Cuenta_Numero, 
						(select tarj_id from THE_ULTIMATES.Tarjeta 
						 where Tarjeta.tarj_numero = HASHBYTES('SHA1',Tarjeta_Numero)),
						1
		from gd_esquema.Maestra
		where Deposito_Codigo is not null

	set identity_insert THE_ULTIMATES.Deposito off;
end
go
/******************************************** FIN - CREACION DE STORED PROCEDURES, FUNCIONES Y VISTAS *************/

/******************************************** INICIO - CREACION DE INDICES *****************************************/
/******************************************** FIN - CREACION DE INDICES *****************************************/

/******************************************** INICIO - LLENADO DE TABLAS *********************************************/

--ROL
insert into THE_ULTIMATES.Rol values ('Administrador', 1), 
									 ('Cliente', 1);
go

--FUNCIONALIDAD
insert into THE_ULTIMATES.Funcionalidad values ('ABM Rol'), 
											('ABM Usuario'),
											('AMB Cliente'),
											('ABM Cuentas'),
											('ABM Tipo de Cuentas'),
											('Asociar Desasociar Tarjetas'),
											('Deposito'),
											('Extraccion'),
											('Transferencia'),
											('Facturacion'),
											('Consulta de Saldo'),
											('Listado Estadistico');
											
go

--FUNCIONALIDAD_POR_ROL
insert into THE_ULTIMATES.Funcionalidad_Rol 
select rol_id , func_id from THE_ULTIMATES.Rol, THE_ULTIMATES.Funcionalidad where rol_id = 1

insert into THE_ULTIMATES.Funcionalidad_Rol values (2,4),(2,6),(2,7),(2,8),(2,9),(2,10),(2,11),(2,12);
go

--ESTADO_CUENTA
insert into THE_ULTIMATES.Estado_Cuenta values ('Pendiente de Activacion'),
											('Cerrada'),
											('Inhabilitada'),
											('Habilitada');
go

--TIPO_CUENTA
insert into THE_ULTIMATES.Tipo_Cuenta values ('Oro', 31, 30.00),
											('Plata', 31, 20.00),
											('Bronce', 31, 10.00),
											('Gratuita', 1, 0.00);
go

--TIPO_MONEDA
insert into THE_ULTIMATES.Tipo_Moneda values ('Dolar','USD', 1.000);
go

--TIPO_DOC
set identity_insert THE_ULTIMATES.Tipo_Doc on;
go
insert into THE_ULTIMATES.Tipo_Doc(tipo_doc_id,tipo_doc_desc)
select distinct Cli_Tipo_Doc_Cod,Cli_Tipo_Doc_Desc
from gd_esquema.Maestra;
go
set identity_insert THE_ULTIMATES.Tipo_Doc off;
go

--PAIS
set identity_insert THE_ULTIMATES.Pais on;
go
insert into THE_ULTIMATES.Pais(pais_id,pais_desc)
select distinct Cli_Pais_Codigo,Cli_Pais_Desc from gd_esquema.Maestra 
union
select distinct Cuenta_Dest_Pais_Codigo,Cuenta_Dest_Pais_Desc from gd_esquema.Maestra where Cuenta_Dest_Pais_Codigo is not null;
go
set identity_insert THE_ULTIMATES.Pais off;
go

--CLIENTE,USUARIO,ROL_USUARIO

insert into THE_ULTIMATES.Usuario values ('romi','w23e',GETDATE(),GETDATE(),null,null,1,0),
										('emi','w23e',GETDATE(),GETDATE(),null,null,1,0),
										('meli','w23e',GETDATE(),GETDATE(),null,null,1,0),
										('david','w23e',GETDATE(),GETDATE(),null,null,1,0);
go

insert into THE_ULTIMATES.Rol_Usuario values (1,1),(1,2),(1,3),(1,4);
go

DECLARE @usu_id int
DECLARE @username varchar(25);

DECLARE @cli_pais_codigo numeric (18,0), 
		@cli_nombre varchar(255),
		@cli_apellido varchar(255), 
		@cli_tipo_doc_cod numeric(18,0), 
		@cli_nro_doc numeric(18,0),
		@cli_tipo_doc_desc varchar(255), 
		@cli_dom_calle varchar(255), 
		@cli_dom_nro numeric(18,0),
		@cli_dom_piso numeric(18,0), 
		@cli_dom_depto varchar(10), 
		@cli_fecha_nac datetime, 
		@cli_mail varchar(255)
		
DECLARE cursor_carga_cliente_usuario CURSOR FOR 
	select distinct Cli_Pais_Codigo, 
					Cli_Nombre, 
					Cli_Apellido, 
					Cli_Tipo_Doc_Cod,
					Cli_Nro_Doc, 
					Cli_Tipo_Doc_Desc, 
					Cli_Dom_Calle, 
					Cli_Dom_Nro, 
					Cli_Dom_Piso, 
					Cli_Dom_Depto,
					Cli_Fecha_Nac, 
					Cli_Mail
					
	from gd_esquema.Maestra

OPEN cursor_carga_cliente_usuario;

FETCH NEXT FROM cursor_carga_cliente_usuario 
INTO	@cli_pais_codigo , 
		@cli_nombre , 
		@cli_apellido, 
		@cli_tipo_doc_cod, 
		@cli_nro_doc, 
		@cli_tipo_doc_desc, 
		@cli_dom_calle, 
		@cli_dom_nro, 
		@cli_dom_piso, 
		@cli_dom_depto, 
		@cli_fecha_nac, 
		@cli_mail
		

BEGIN TRANSACTION transaction_maestra;
WHILE @@FETCH_STATUS = 0
BEGIN
	
	IF not exists(select 1 from THE_ULTIMATES.Cliente where clie_nro_doc = @cli_nro_doc and clie_tipo_doc_id = @cli_tipo_doc_cod)  
	BEGIN
	
	set @username = THE_ULTIMATES.GenerarUsuario(@cli_nombre,@cli_apellido);
	
		INSERT INTO THE_ULTIMATES.Usuario(	[usu_username],
											[usu_password],
											[usu_fecha_alta],
											[usu_fecha_mod],
											[usu_pregunta],
											[usu_respuesta],
											[usu_activo],
											[usu_intentos_fallidos])
		VALUES (@username, 
				@username, -- Por unica vez se le asigna el usuario como password, 
						   -- luego el cliente tendra que cambiarla cuando ingrese por primera vez al sistema.
				GETDATE(), 
				GETDATE(), 
				NULL, 
				NULL, 
				1, 
				0)
			
		SET @usu_id = SCOPE_IDENTITY()	
		
		insert into THE_ULTIMATES.Rol_Usuario values (2,@usu_id)
		
		INSERT INTO THE_ULTIMATES.Cliente(	[clie_nombre],
											[clie_apellido],
											[clie_nro_doc],
											[clie_tipo_doc_id],
											[clie_mail],
											[clie_activo],
											[clie_dom_calle],
											[clie_dom_numero],
											[clie_dom_piso],
											[clie_dom_depto],
											[clie_fecha_nac],
											[clie_pais_id],
											[clie_usu_id])
		values(	@cli_nombre, 
				@cli_apellido, 
				@cli_nro_doc, 
				@cli_tipo_doc_cod, 
				@cli_mail, 
				1,
				@cli_dom_calle, 
				@cli_dom_nro, 
				@cli_dom_piso, 
				@cli_dom_depto, 
				@cli_fecha_nac, 
				@cli_pais_codigo, 
				@usu_id)
	END
		
	FETCH NEXT FROM cursor_carga_cliente_usuario 
	INTO	@cli_pais_codigo , 
			@cli_nombre , 
			@cli_apellido, 
			@cli_tipo_doc_cod, 
			@cli_nro_doc, 
			@cli_tipo_doc_desc, 
			@cli_dom_calle, 
			@cli_dom_nro, 
			@cli_dom_piso, 
			@cli_dom_depto, 
			@cli_fecha_nac, 
			@cli_mail
			
END 
CLOSE cursor_carga_cliente_usuario;
DEALLOCATE cursor_carga_cliente_usuario;
COMMIT TRANSACTION transaction_maestra;
go

exec THE_ULTIMATES.SP_CargarCuentas;
exec THE_ULTIMATES.SP_CargarTransferencias2;
exec THE_ULTIMATES.SP_CargarBancos;
exec THE_ULTIMATES.SP_CargarCheques;
exec THE_ULTIMATES.SP_CargarExtracciones;
exec THE_ULTIMATES.SP_CargarEmisores;
exec THE_ULTIMATES.SP_CargarTarjetas;
exec THE_ULTIMATES.SP_CargarDepositos;

--TIPO TRANSACCIONES

insert into THE_ULTIMATES.Tipo_Transaccion values ('Deposito', 0),
												('Extraccion', 0),
												('Transferencia', 1),
												('Apertura de cuenta', 1),
												('Cambio de cuenta', 1);
go

exec THE_ULTIMATES.SP_CargarFacturas;


declare @cuenta_numero numeric(18,0), 
		@trans_fecha datetime,  
		@item_factura_descr varchar(255),
		@item_factura_importe numeric(18,2),
		@factura_numero numeric(18,0),
		@transac_id int
		
declare cursor_transferencias cursor for 
	(select Cuenta_Numero,
			Transf_Fecha,
			Item_Factura_Descr,
			Item_Factura_Importe,
			Factura_Numero
	from gd_esquema.Maestra
	where Cuenta_Dest_Numero is not null and Factura_Numero is not null)
	
open cursor_transferencias;

fetch next from cursor_transferencias 
into	@cuenta_numero , 
		@trans_fecha,  
		@item_factura_descr, 
		@item_factura_importe, 
		@factura_numero

set identity_insert THE_ULTIMATES.Factura on;
		
while @@FETCH_STATUS = 0
begin

	insert into THE_ULTIMATES.Transaccion (transac_cuen_id,
											transac_fecha,
											transac_importe_comision,
											transac_pendiente,
											transac_tipo_transac_id)
											
	values (@cuenta_numero, @trans_fecha, @item_factura_importe, 0, 3)

	set @transac_id = SCOPE_IDENTITY();		
	
	insert into THE_ULTIMATES.Item_Factura (item_fact_num, item_fact_transac_id, item_fact_cantidad)
	values (@factura_numero, @transac_id, 1);

	fetch next from cursor_transferencias 
	into	@cuenta_numero, 
			@trans_fecha,  
			@item_factura_descr, 
			@item_factura_importe, 
			@factura_numero	
end	

close cursor_transferencias;
deallocate cursor_transferencias;

/******************************************** FIN - LLENADO DE TABLAS *********************************************/

/******************************************** INICIO - TRIGGERS *****************************************/

/*create trigger THE_ULTIMATES.Trigger_ControlCuentas on THE_ULTIMATES.Transferencia after insert
as

declare cursor_controlCuentas cursor for select i.transac_cuen_id from inserted i

Crear transaccion. 

Si el campo de item es distinto de null
	crear item, 
	si la 
*/




/******************************************** FIN - TRIGGERS *****************************************/
