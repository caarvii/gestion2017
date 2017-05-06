CREATE PROCEDURE [THE_ULTIMATES].[Lista_Func_Rol]
@id numeric(18,0)=null
AS
BEGIN
	SET NOCOUNT ON;

SELECT func_desc DESCRIPCION FROM THE_ULTIMATES.Funcionalidad func ,THE_ULTIMATES.Funcionalidad_Rol funcRol 
WHERE funcRol.func_rol_rol_id = @id and func.func_id = func_rol_func_id;
END



GO

CREATE PROCEDURE [THE_ULTIMATES].[Lista_Pais]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT pais_id ID , pais_desc DESCRIPCION
	FROM [THE_ULTIMATES].Pais 
END

GO

CREATE PROCEDURE [THE_ULTIMATES].[Lista_Rol]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [THE_ULTIMATES].Rol 
END

GO
CREATE PROCEDURE [THE_ULTIMATES].[Lista_Tipo_Cuenta]
AS
BEGIN
	SET NOCOUNT ON;

SELECT tipo_cuenta_id  ID , tipo_cuenta_desc  DESCRIPCION   FROM THE_ULTIMATES.Tipo_Cuenta;
END

GO