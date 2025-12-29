DROP TABLE IF EXISTS `Work`; 

CREATE TABLE IF NOT EXISTS `Work`(
id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	`OrderId` int  NOT NULL,
	`WorkerId` int  NOT NULL,
	`StartDate` datetime(3)  NOT NULL,
	`FinishDate` datetime(3)  NOT NULL,
	`Cost` double  NOT NULL,
	`SupplyExpenses` double  NOT NULL,
	`WorkExpenses` double  NOT NULL,
	`Description` text  NOT NULL,
	`Notes` text  NULL,
	`ModifyTime` datetime(3)  NOT NULL
)ENGINE=INNODB; 



drop procedure if exists AddWork	;	
delimiter $$

CREATE PROCEDURE  AddWork(
		IN OrderId int,
		IN WorkerId int,
		IN StartDate datetime(3),
		IN FinishDate datetime(3),
		IN Cost double,
		IN SupplyExpenses double,
		IN WorkExpenses double,
		IN Description text,
		IN Notes text,
		IN ModifyTime datetime(3),
		OUT Id int)

BEGIN

	INSERT INTO `Work` (
	`OrderId`,
	`WorkerId`,
	`StartDate`,
	`FinishDate`,
	`Cost`,
	`SupplyExpenses`,
	`WorkExpenses`,
	`Description`,
	`Notes`,
	`ModifyTime`
	) 
	VALUES 
	(
	OrderId,
	WorkerId,
	StartDate,
	FinishDate,
	Cost,
	SupplyExpenses,
	WorkExpenses,
	Description,
	Notes,
	ModifyTime
	);
	
set Id = last_insert_id();

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

drop procedure if exists GetWorkById	;	
delimiter $$


CREATE PROCEDURE GetWorkById(IN Id int)

BEGIN

	SELECT * FROM `Work` WHERE `Work`.id = Id;

end$$
delimiter ;

drop procedure if exists UpdateWorkWorkerId	;	
delimiter $$


CREATE PROCEDURE  `UpdateWorkWorkerId`
		(IN Id int,
		IN WorkerId int,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Work`
	SET 
	`WorkerId` = WorkerId,
	`ModifyTime` = ModifyTime
	WHERE id = Id;	

end$$
delimiter ;

drop procedure if exists UpdateWorkDescription	;	
delimiter $$


CREATE PROCEDURE  `UpdateWorkDescription`
		(IN Id int,
		IN Description text,
		IN ModifyTime datetime(3))

BEGIN

	UPDATE `Work`
	SET 
	`Description` = Description,
	`ModifyTime` = ModifyTime
	WHERE id = Id;	

end$$
delimiter ;


drop procedure if exists GetWorkCollection;	
delimiter $$


CREATE PROCEDURE GetWorkCollection()

BEGIN

	SELECT * FROM `Work`;

end$$
delimiter ;


drop procedure if exists GetWorkCollectionByWorkerId;	
delimiter $$


CREATE PROCEDURE GetWorkCollectionByWorkerId(IN WorkerId int)

BEGIN

	SELECT * FROM `Work` WHERE `Work`.`WorkerId` = WorkerId;

end$$
delimiter ;




drop procedure if exists GetWorkByDescription;	
delimiter $$


CREATE PROCEDURE GetWorkByDescription(IN Description text)

BEGIN

	SELECT * FROM `Work` WHERE `Work`.`Description` = Description LIMIT 1;

end$$
delimiter ;




drop procedure if exists DeleteWork;
delimiter $$
create procedure DeleteWork(IN Id INT)
begin

delete from `Work` where `Work`.id = Id;
 
end$$
delimiter ;

