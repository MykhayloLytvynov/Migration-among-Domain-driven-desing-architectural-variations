DROP TABLE IF EXISTS `Order`; 

CREATE TABLE IF NOT EXISTS `Order`(
id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	`CustomerId` int  NOT NULL,
	`CarId` int  NOT NULL,
	`StartDate` datetime(3)  NOT NULL,
	`FinishDate` datetime(3)  NOT NULL,
	`ModifyTime` datetime(3)  NOT NULL
)ENGINE=INNODB; 



drop procedure if exists AddOrder	;	
delimiter $$

CREATE PROCEDURE  AddOrder(
		IN CustomerId int,
		IN CarId int,
		IN StartDate datetime(3),
		IN FinishDate datetime(3),
		IN ModifyTime datetime(3),
		OUT Id int)

BEGIN

	INSERT INTO `Order` (
	`CustomerId`,
	`CarId`,
	`StartDate`,
	`FinishDate`,
	`ModifyTime`
	) 
	VALUES 
	(
	CustomerId,
	CarId,
	StartDate,
	FinishDate,
	ModifyTime
	);
	
set Id = last_insert_id();

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

drop procedure if exists GetOrderById	;	
delimiter $$


CREATE PROCEDURE GetOrderById(IN Id int)

BEGIN

	SELECT * FROM `Order` WHERE `Order`.id = Id;

end$$
delimiter ;

drop procedure if exists UpdateOrderCustomerId	;	
delimiter $$


CREATE PROCEDURE  `UpdateOrderCustomerId`
		(IN Id int,
		IN CustomerId int,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Order`
	SET 
	`CustomerId` = CustomerId,
	`ModifyTime` = ModifyTime
	WHERE id = Id;	

end$$
delimiter ;

drop procedure if exists UpdateOrderCarId	;	
delimiter $$


CREATE PROCEDURE  `UpdateOrderCarId`
		(IN Id int,
		IN CarId int,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Order`
	SET 
	`CarId` = CarId,
	`ModifyTime` = ModifyTime
	WHERE id = Id;	

end$$
delimiter ;


drop procedure if exists GetOrderCollection;	
delimiter $$


CREATE PROCEDURE GetOrderCollection()

BEGIN

	SELECT * FROM `Order`;

end$$
delimiter ;


drop procedure if exists GetOrderCollectionByCustomerId;	
delimiter $$


CREATE PROCEDURE GetOrderCollectionByCustomerId(IN CustomerId int)

BEGIN

	SELECT * FROM `Order` WHERE `Order`.`CustomerId` = CustomerId;

end$$
delimiter ;



drop procedure if exists GetOrderCollectionByCarId;	
delimiter $$


CREATE PROCEDURE GetOrderCollectionByCarId(IN CarId int)

BEGIN

	SELECT * FROM `Order` WHERE `Order`.`CarId` = CarId;

end$$
delimiter ;






drop procedure if exists DeleteOrder;
delimiter $$
create procedure DeleteOrder(IN Id INT)
begin

START TRANSACTION;
delete from `Order` where `Order`.id = Id;
	DELETE FROM `Work` WHERE orderid = Id;


COMMIT;

end$$
delimiter ;
