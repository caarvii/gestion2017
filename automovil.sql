create procedure GARBAGE.getModelosListByMarca(@marca_id int)
as
begin
	(select * from GARBAGE.Automovil where auto_marca_id = @marca_id)
end


