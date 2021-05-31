create database CompanyDB;

use CompanyDB;

create table Dept(
	Id int identity(1,1) primary key,
	DName varchar(25),
	Loc varchar(50)
)

create table Employee(
	Id int identity(1,1) primary key,
	EName varchar(25),
	Salary	decimal(10,2),
	DeptId int foreign key references Dept(Id)
)

insert into Dept values('IT', 'San Francisco');
insert into Dept values('HR', 'New York');
insert into Dept values('QA', 'San Francisco');
insert into Dept values('Inventory', 'San Francisco');
select * from Dept;

insert into Employee values('Mike', 3000.00, 4);
insert into Employee values('Jack', 5000.00, 3);
insert into Employee values('Tom', 7000.00, 1);
insert into Employee values('Sam', 4000.00, 2);
select * from Employee;

Select e.Id,e.EName,e.Salary,e.DeptId, d.DName from Employee e inner join Dept d on e.DeptId=d.Id;