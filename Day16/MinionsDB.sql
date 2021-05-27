create database MinionsDB;

use MinionsDB;

create table EvilnessFactors(
	Id int primary key IDENTITY(1,1),
	[Name] varchar(25)
)

create table Villains(
	Id int primary key IDENTITY(1,1),
	[Name] varchar(25),
	EvilnessFactorId int foreign key references EvilnessFactors(Id)
)

create table Countries(
	Id int primary key IDENTITY(1,1),
	[Name] varchar(25)
)

create table Towns(
	Id int primary key IDENTITY(1,1),
	[Name] varchar(25),
	CountryId int foreign key references Countries(Id)
)

create table Minions(
	Id int primary key IDENTITY(1,1),
	[Name] varchar(25),
	Age int,
	TownId int foreign key references Towns(Id)
)

create table MinionsVillains(
	MinionId int foreign key references Minions(Id),
	VillainId int foreign key references Villains(Id)
)

drop table EvilnessFactors;
drop table Villains;
drop table Countries;
drop table Towns;
drop table Minions;
drop table MinionsVillains;

insert into EvilnessFactors values('super good');
insert into EvilnessFactors values('good');
insert into EvilnessFactors values('bad');
insert into EvilnessFactors values('evil');
insert into EvilnessFactors values('super evil');
select * from EvilnessFactors;

insert into Villains values('Tom', 2);
insert into Villains values('Steve', 1);
insert into Villains values('Jack', 3);
insert into Villains values('Bill', 5);
insert into Villains values('Jeff', 4);
select * from Villains;

insert into Countries values('USA');
insert into Countries values('UK');
insert into Countries values('Canada');
insert into Countries values('Japan');
insert into Countries values('Korea');
insert into Countries values('Germany');
select * from Countries;

insert into Towns values('New York', 1);
insert into Towns values('London', 2);
insert into Towns values('Toronto', 3);
insert into Towns values('Tokyo', 4);
insert into Towns values('Seoul', 5);
select * from Towns;

insert into Minions values('Mike', 45, 1);
insert into Minions values('William', 49, 2);
insert into Minions values('Tim', 50, 3);
insert into Minions values('Yamamoto', 51, 4);
insert into Minions values('Kim', 60, 5);
insert into Minions values('Sam', 47, 1);
select * from Minions;

insert into MinionsVillains values(1, 2);
insert into MinionsVillains values(1, 3);
insert into MinionsVillains values(2, 3);
insert into MinionsVillains values(3, 1);
insert into MinionsVillains values(3, 2);
insert into MinionsVillains values(3, 4);
insert into MinionsVillains values(4, 3);
insert into MinionsVillains values(4, 5);
insert into MinionsVillains values(4, 1);
insert into MinionsVillains values(4, 2);
insert into MinionsVillains values(5, 2);
insert into MinionsVillains values(5, 3);
insert into MinionsVillains values(5, 4);
insert into MinionsVillains values(6, 4);
insert into MinionsVillains values(6, 1);
insert into MinionsVillains values(6, 2);
insert into MinionsVillains values(6, 3);
insert into MinionsVillains values(6, 5);
select * from MinionsVillains;
