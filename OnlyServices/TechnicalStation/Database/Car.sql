use orders;

DROP TABLE IF EXISTS `Car`; 

CREATE TABLE IF NOT EXISTS `Car`(
id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	`CustomerId` int  NOT NULL,
	`Producer` text  NOT NULL,
	`Model` text  NOT NULL,
	`Color` text  NOT NULL,
	`Number` text  NOT NULL,
	`Year` int  NOT NULL,
	`ModifyTime` datetime(3)  NOT NULL
)ENGINE=INNODB; 



drop procedure if exists AddCar	;	
delimiter $$

CREATE PROCEDURE  AddCar(
		IN CustomerId int,
		IN Producer text,
		IN Model text,
		IN Color text,
		IN Number text,
		IN Year int,
		IN ModifyTime datetime(3),
		OUT Id int)

BEGIN

	INSERT INTO `Car` (
	`CustomerId`,
	`Producer`,
	`Model`,
	`Color`,
	`Number`,
	`Year`,
	`ModifyTime`
	) 
	VALUES 
	(
	CustomerId,
	Producer,
	Model,
	Color,
	Number,
	Year,
	ModifyTime
	);
	
set Id = last_insert_id();

end$$
delimiter ;

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

drop procedure if exists GetCarById	;	
delimiter $$


CREATE PROCEDURE GetCarById(IN Id int)

BEGIN

	SELECT * FROM `Car` WHERE `Car`.id = Id;

end$$
delimiter ;

drop procedure if exists UpdateCarCustomerId	;	
delimiter $$


CREATE PROCEDURE  `UpdateCarCustomerId`
		(IN Id int,
		IN CustomerId int,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Car`
	SET 
	`CustomerId` = CustomerId,
	`ModifyTime` = ModifyTime
	WHERE id = Id;	

end$$
delimiter ;

drop procedure if exists UpdateCarProducer	;	
delimiter $$


CREATE PROCEDURE  `UpdateCarProducer`
		(IN Id int,
		IN Producer text,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Car`
	SET 
	`Producer` = Producer,
	`ModifyTime` = ModifyTime
	WHERE id = Id;	

end$$
delimiter ;

drop procedure if exists UpdateCarModel	;	
delimiter $$


CREATE PROCEDURE  `UpdateCarModel`
		(IN Id int,
		IN Model text,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Car`
	SET 
	`Model` = Model,
	`ModifyTime` = ModifyTime
	WHERE id = Id;	

end$$
delimiter ;


drop procedure if exists GetCarCollection;	
delimiter $$


CREATE PROCEDURE GetCarCollection()

BEGIN

	SELECT * FROM `Car`;

end$$
delimiter ;


drop procedure if exists GetCarCollectionByCustomerId;	
delimiter $$


CREATE PROCEDURE GetCarCollectionByCustomerId(IN CustomerId int)

BEGIN

	SELECT * FROM `Car` WHERE `Car`.`CustomerId` = CustomerId;

end$$
delimiter ;




drop procedure if exists GetCarByProducer;	
delimiter $$


CREATE PROCEDURE GetCarByProducer(IN Producer text)

BEGIN

	SELECT * FROM `Car` WHERE `Car`.`Producer` = Producer LIMIT 1;

end$$
delimiter ;


drop procedure if exists GetCarByModel;	
delimiter $$


CREATE PROCEDURE GetCarByModel(IN Model text)

BEGIN

	SELECT * FROM `Car` WHERE `Car`.`Model` = Model LIMIT 1;

end$$
delimiter ;




drop procedure if exists DeleteCar;
delimiter $$
create procedure DeleteCar(IN Id INT)
begin

START TRANSACTION;
delete from `Car` where `Car`.id = Id;
	DELETE FROM `Order` WHERE carid = Id;


COMMIT;

end$$
delimiter ;
