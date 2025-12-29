DROP TABLE IF EXISTS `Customer`; 

CREATE TABLE IF NOT EXISTS `Customer`(
id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	`FirstName` text  NOT NULL,
	`LastName` text  NOT NULL,
	`Address` text  NOT NULL,
	`PhoneNumber` text  NOT NULL,
	`ModifyTime` datetime(3)  NOT NULL
)ENGINE=INNODB; 



drop procedure if exists AddCustomer	;	
delimiter $$

CREATE PROCEDURE  AddCustomer(
		IN FirstName text,
		IN LastName text,
		IN Address text,
		IN PhoneNumber text,
		IN ModifyTime datetime(3),
		OUT Id int)

BEGIN

	INSERT INTO `Customer` (
	`FirstName`,
	`LastName`,
	`Address`,
	`PhoneNumber`,
	`ModifyTime`
	) 
	VALUES 
	(
	FirstName,
	LastName,
	Address,
	PhoneNumber,
	ModifyTime
	);
	
set Id = last_insert_id();

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

drop procedure if exists GetCustomerById	;	
delimiter $$


CREATE PROCEDURE GetCustomerById(IN Id int)

BEGIN

	SELECT * FROM `Customer` WHERE `Customer`.id = Id;

end$$
delimiter ;

drop procedure if exists UpdateCustomerLastName	;	
delimiter $$


CREATE PROCEDURE  `UpdateCustomerLastName`
		(IN Id int,
		IN LastName text,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Customer`
	SET 
	`LastName` = LastName,
	`ModifyTime` = ModifyTime
	WHERE id = Id;	

end$$
delimiter ;


drop procedure if exists GetCustomerCollection;	
delimiter $$


CREATE PROCEDURE GetCustomerCollection()

BEGIN

	SELECT * FROM `Customer`;

end$$
delimiter ;



drop procedure if exists GetCustomerByLastName;	
delimiter $$


CREATE PROCEDURE GetCustomerByLastName(IN LastName text)

BEGIN

	SELECT * FROM `Customer` WHERE `Customer`.`LastName` = LastName LIMIT 1;

end$$
delimiter ;




drop procedure if exists DeleteCustomer;
delimiter $$
create procedure DeleteCustomer(IN Id INT)
begin

START TRANSACTION;
delete from `Customer` where `Customer`.id = Id;
	DELETE FROM `Car` WHERE customerid = Id;
	DELETE FROM `Order` WHERE customerid = Id;


COMMIT;

end$$
delimiter ;
