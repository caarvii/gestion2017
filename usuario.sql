create procedure GARBAGE.getUsuarioById(@user_id int)
as
begin
	(select * from GARBAGE.Usuario where usu_id = @user_id)
end


