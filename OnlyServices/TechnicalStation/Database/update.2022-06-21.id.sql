
drop procedure if exists UpdateCar	;	
delimiter $$

CREATE PROCEDURE  UpdateCar
		(IN Id int,
		IN CustomerId int,
		IN Producer text,
		IN Model text,
		IN Color text,
		IN Number text,
		IN Year int,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Car`
	SET 
	`CustomerId` = CustomerId,
	`Producer` = Producer,
	`Model` = Model,
	`Color` = Color,
	`Number` = Number,
	`Year` = Year,
	`ModifyTime` = ModifyTime
	WHERE `Car`.`Id` = Id;	

end$$
delimiter ;

drop procedure if exists UpdateCustomer	;	
delimiter $$

CREATE PROCEDURE  UpdateCustomer
		(IN Id int,
		IN FirstName text,
		IN LastName text,
		IN Address text,
		IN PhoneNumber text,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Customer`
	SET 
	`FirstName` = FirstName,
	`LastName` = LastName,
	`Address` = Address,
	`PhoneNumber` = PhoneNumber,
	`ModifyTime` = ModifyTime
	WHERE `Customer`.`Id` = Id;	

end$$
delimiter ;

drop procedure if exists UpdateOrder	;	
delimiter $$

CREATE PROCEDURE  UpdateOrder
		(IN Id int,
		IN CustomerId int,
		IN CarId int,
		IN StartDate datetime(3),
		IN FinishDate datetime(3),
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Order`
	SET 
	`CustomerId` = CustomerId,
	`CarId` = CarId,
	`StartDate` = StartDate,
	`FinishDate` = FinishDate,
	`ModifyTime` = ModifyTime
	WHERE `Order`.`Id` = Id;	

end$$
delimiter ;

drop procedure if exists UpdateWork	;	
delimiter $$

CREATE PROCEDURE  UpdateWork
		(IN Id int,
		IN OrderId int,
		IN WorkerId int,
		IN StartDate datetime(3),
		IN FinishDate datetime(3),
		IN Cost double,
		IN SupplyExpenses double,
		IN WorkExpenses double,
		IN Description text,
		IN Notes text,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Work`
	SET 
	`OrderId` = OrderId,
	`WorkerId` = WorkerId,
	`StartDate` = StartDate,
	`FinishDate` = FinishDate,
	`Cost` = Cost,
	`SupplyExpenses` = SupplyExpenses,
	`WorkExpenses` = WorkExpenses,
	`Description` = Description,
	`Notes` = Notes,
	`ModifyTime` = ModifyTime
	WHERE `Work`.`Id` = Id;	

end$$
delimiter ;

drop procedure if exists UpdateWorker	;	
delimiter $$

CREATE PROCEDURE  UpdateWorker
		(IN Id int,
		IN FirstName text,
		IN LastName text,
		IN Address text,
		IN PhoneNumber text,
		IN Notes text,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Worker`
	SET 
	`FirstName` = FirstName,
	`LastName` = LastName,
	`Address` = Address,
	`PhoneNumber` = PhoneNumber,
	`Notes` = Notes,
	`ModifyTime` = ModifyTime
	WHERE `Worker`.`Id` = Id;	

end$$
delimiter ;
