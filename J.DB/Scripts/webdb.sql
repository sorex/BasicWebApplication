CREATE TABLE `users` (
`GUID` char(32) NOT NULL,
`ShowName` varchar(32) NOT NULL COMMENT '显示名称',
`LoginName` varchar(32) NOT NULL COMMENT '登录名称',
`LoginPassword` varchar(32) NOT NULL COMMENT '登录密码',
`Email` varchar(32) NOT NULL COMMENT '电子邮箱',
`CreateDateTime` datetime NOT NULL COMMENT '创建时间',
PRIMARY KEY (`GUID`) 
);

CREATE TABLE `user_loginlogs` (
`ID` int NOT NULL AUTO_INCREMENT,
`userID` char(32) NOT NULL,
`LoginDateTime` datetime NOT NULL COMMENT '登录时间',
PRIMARY KEY (`ID`) 
);

CREATE TABLE `uploadfiles` (
`GUID` char(32) NOT NULL,
`userID` char(32) NOT NULL,
`Name` varchar(300) NOT NULL,
`Extension` varchar(300) NOT NULL,
`Length` bigint NOT NULL,
`CreateDateTime` datetime NOT NULL,
PRIMARY KEY (`GUID`) 
);

CREATE TABLE `singles` (
`GUID` char(32) NOT NULL,
`SingleIntNumber` int NOT NULL,
`SingleIntEnum` int NOT NULL,
`SingleMoney` decimal NOT NULL,
`SingleDatetime` datetime NOT NULL,
`SingleVarchar` varchar(300) NOT NULL,
`SingleLongVarchar` text NOT NULL,
`SingleBit` bit NOT NULL,
PRIMARY KEY (`GUID`) 
);


ALTER TABLE `user_loginlogs` ADD FOREIGN KEY (`userID`) REFERENCES `users` (`GUID`);
ALTER TABLE `uploadfiles` ADD FOREIGN KEY (`userID`) REFERENCES `users` (`GUID`);

