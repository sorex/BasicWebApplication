CREATE TABLE `users` (

`GUID` char(32) NULL,

`ShowName` varchar(32) NULL COMMENT '显示名称',

`LoginName` varchar(32) NULL COMMENT '登录名称',

`LoginPassword` varchar(32) NULL COMMENT '登录密码',

`Email` varchar(32) NULL COMMENT '电子邮箱',

`CreateDateTime` datetime NULL COMMENT '创建时间',

PRIMARY KEY (`GUID`) 

);



CREATE TABLE `user_loginlogs` (

`ID` int NULL AUTO_INCREMENT,

`userID` char(32) NULL,

`LoginDateTime` datetime NULL COMMENT '登录时间',

PRIMARY KEY (`ID`) 

);



CREATE TABLE `uploadfiles` (

`GUID` char(32) NULL,

`userID` char(32) NULL,

`Name` varchar(300) NULL,

`Extension` varchar(300) NULL,

`Length` bigint NULL,

`CreateDateTime` datetime NULL,

PRIMARY KEY (`GUID`) 

);





ALTER TABLE `user_loginlogs` ADD FOREIGN KEY (`userID`) REFERENCES `users` (`GUID`);

ALTER TABLE `uploadfiles` ADD FOREIGN KEY (`userID`) REFERENCES `users` (`GUID`);



