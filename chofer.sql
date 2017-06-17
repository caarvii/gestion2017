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


-- updateChoder
-- altaChofer