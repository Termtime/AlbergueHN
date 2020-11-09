delimiter //
Create trigger trInsertEntradaDetalle
after insert on entradadetalle 
FOR EACH ROW
begin
	Update suministro set existencia = existencia + new.cantidad where suministroID = new.suministroID;
end;
//
delimiter ;

delimiter //
Create trigger trDeleteEntradaDetalle
after DELETE on entradadetalle FOR EACH ROW
begin
	Update suministro set existencia = existencia - old.cantidad where suministroID = old.suministroID;
end;
//
delimiter ;

delimiter //
Create trigger trUpdateEntradaDetalle
after update on entradadetalle FOR EACH ROW
begin
	if(new.cantidad != old.cantidad ) then
		Update suministro set existencia = existencia + (new.cantidad-old.cantidad) where suministroID = new.suministroID;
	end if;
end;
//
delimiter ;

delimiter //
Create trigger trInsertSalidaDetalle
after insert on salidadetalle FOR EACH ROW
begin
	Update suministro set existencia = existencia - new.cantidad where suministroID = new.suministroID;
end;
//
delimiter ;

delimiter //
Create trigger trDeleteSalidaDetalle
after DELETE on salidadetalle FOR EACH ROW
begin
	Update suministro set existencia = existencia + old.cantidad where suministroID = old.suministroID;
end;
//
delimiter ;

delimiter //
Create trigger trUpdateSalidaDetalle
after update on salidadetalle FOR EACH ROW
begin
	Update suministro set existencia = new.cantidad where suministroID = new.suministroID;
end;
//
delimiter ;