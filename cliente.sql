create procedure GARBAGE.getClientes
as
begin
	(select * from GARBAGE.Cliente)
end
go

create procedure GARBAGE.getClienteById(@cli_id int)
as
begin
	(select * from GARBAGE.Cliente where cli_id = @cli_id)
end


