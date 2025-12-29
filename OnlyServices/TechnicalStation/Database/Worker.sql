DROP TABLE IF EXISTS `Worker`; 

CREATE TABLE IF NOT EXISTS `Worker`(
id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	`FirstName` text  NOT NULL,
	`LastName` text  NOT NULL,
	`Address` text  NOT NULL,
	`PhoneNumber` text  NOT NULL,
	`Notes` text  NULL,
	`ModifyTime` datetime(3)  NOT NULL
)ENGINE=INNODB; 



drop procedure if exists AddWorker	;	
delimiter $$

CREATE PROCEDURE  AddWorker(
		IN FirstName text,
		IN LastName text,
		IN Address text,
		IN PhoneNumber text,
		IN Notes text,
		IN ModifyTime datetime(3),
		OUT Id int)

BEGIN

	INSERT INTO `Worker` (
	`FirstName`,
	`LastName`,
	`Address`,
	`PhoneNumber`,
	`Notes`,
	`ModifyTime`
	) 
	VALUES 
	(
	FirstName,
	LastName,
	Address,
	PhoneNumber,
	Notes,
	ModifyTime
	);
	
set Id = last_insert_id();

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

drop procedure if exists GetWorkerById	;	
delimiter $$


CREATE PROCEDURE GetWorkerById(IN Id int)

BEGIN

	SELECT * FROM `Worker` WHERE `Worker`.id = Id;

end$$
delimiter ;

drop procedure if exists UpdateWorkerLastName	;	
delimiter $$


CREATE PROCEDURE  `UpdateWorkerLastName`
		(IN Id int,
		IN LastName text,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Worker`
	SET 
	`LastName` = LastName,
	`ModifyTime` = ModifyTime
	WHERE id = Id;	

end$$
delimiter ;


drop procedure if exists GetWorkerCollection;	
delimiter $$


CREATE PROCEDURE GetWorkerCollection()

BEGIN

	SELECT * FROM `Worker`;

end$$
delimiter ;



drop procedure if exists GetWorkerByLastName;	
delimiter $$


CREATE PROCEDURE GetWorkerByLastName(IN LastName text)

BEGIN

	SELECT * FROM `Worker` WHERE `Worker`.`LastName` = LastName LIMIT 1;

end$$
delimiter ;




drop procedure if exists DeleteWorker;
delimiter $$
create procedure DeleteWorker(IN Id INT)
begin

START TRANSACTION;
delete from `Worker` where `Worker`.id = Id;
	DELETE FROM `Work` WHERE workerid = Id;


COMMIT;

end$$
delimiter ;
