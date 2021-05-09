/*
	Answer following questions:
	1.	What is View? What are the benefits of using views?
		View is a virtual table whose contents are defined by a query.
		The benefits of using views are views can simplify data manipulation, 
		create a backward compatible interface for a table when its schema changes,
		and let different users to see data in different ways.

	2.	Can data be modified through views?
		Yes, but there are some limitations.

	3.	What is stored procedure and what are the benefits of using it?
		Stored procedure groups one or more Transact-SQL statements into a logical unit, stored as an object in a SQL Server database.
		The benefits are it can increase database security by limiting direct access, have faster execution becuase of plan reuse,
		help centralize Transact-SQL code in the data tier, help reduce network traffic for larger ad hoc queries, and encourage code reusability.

	4.	What is the difference between view and stored procedure?
			1) Stored procedure has faster execution than view because the database can optimize the data access plan 
			used by the procedure and cache it for subsequent reuse.
			2) Stored procedure can have parameters while view cannot.

	5.	What is the difference between stored procedure and functions?
			1) Stored procedure does not have a return type but functions have a return type and returns a value.
			2) Function can be only used in a SQL statement, mostly in a select statement, or representing a data or a dataset.
			3) We can call a function using a select statement but we cannot call a stored procedure using a select statement.

	6.	Can stored procedure return multiple result sets?
		Yes, stored procedure can return multiple result sets using .

	7.	Can stored procedure be executed as part of SELECT Statement? Why?
		No, because we cannot call a stored procedure using a select statement.

	8.	What is Trigger? What types of Triggers are there?
		Trigger is a special type of stored procedure that get executed (fired) when a specific event happens.
		Types of Triggers are DDL Trigger, DML Trigger, Logon Trigger. 

	9.	What are the scenarios to use Triggers?
			1) Enforce Integrity beyond simple Referential Integrity
			2) Implement business rules
			3) Maintain audit record of changes
			4) Accomplish cascading updates and deletes

	10.	What is the difference between Trigger and Stored Procedure?
			1) Trigger is a special type of stored procedure that get executed automatically when a specific event happens.
			2) Trigger cannot be explicitly executed.

*/

use Northwind
go

/*
	question 1
*/
BEGIN TRANSACTION;
-- a.	A new region called ¡°Middle Earth¡±
insert into dbo.Region values(5, 'Middle Earth');

-- b.	A new territory called ¡°Gondor¡±, belongs to region ¡°Middle Earth¡±;
Declare @newRegionid int;
set @newRegionid = (select RegionID from dbo.Region where RegionDescription = 'Middle Earth');
insert into dbo.Territories values(99999, 'Gondor', @newRegionid);

-- c.	A new employee ¡°Aragorn King¡± who's territory is ¡°Gondor¡±.
insert into dbo.Employees (FirstName, LastName) values('Aragorn', 'King');
Declare @newEmployeeID int;
set @newEmployeeID = (select EmployeeID from dbo.Employees where FirstName = 'Aragorn' and LastName = 'King');
insert into dbo.EmployeeTerritories values(@newEmployeeID, 99999);

/*
	question 2
*/
update dbo.Territories set TerritoryDescription = 'Arnor' where TerritoryID = 99999;

/*
	question 3
*/
delete from dbo.Territories where TerritoryID = 99999;
delete from dbo.Region where RegionDescription = 'Middle Earth';
ROLLBACK;

go /*batch separator*/

/*
	question 4
*/
create view view_product_order_Mei
as
select	p.ProductName, sum(od.Quantity) as totalQuantity
from	dbo.[Order Details] od
		inner join
		dbo.Products p
		on od.ProductID = p.ProductID
group by	p.ProductName
go
;

/*
	question 5
*/
create procedure sp_product_order_quantity_Mei 
	@ProductID int,
	@TotalQuantity int output
as
select	@TotalQuantity = sum(Quantity)
from	dbo.[Order Details]
where	ProductID = @ProductID
group by	ProductID
go
;
/*
To exectue:

DECLARE	@TotalQuantity int;
exec sp_product_order_quantity_Mei @ProductID = 1, @TotalQuantity = @TotalQuantity output;
select @TotalQuantity as TotalQuantity
go
*/

/*
	question 6
*/
create procedure sp_product_order_city_Mei
	@ProductName nvarchar(40)
as
select	B.ShipCity, B.totalQuant
from
(
select	A.ProductName, A.ShipCity, A.totalQuant, RANK() over(partition by A.ProductName order by A.totalQuant desc) as rnk
from	(
		select	p.ProductName, o.ShipCity, sum(od.Quantity) as totalQuant
		from	dbo.[Order Details] od
				inner join
				dbo.Products p
				on od.ProductID = p.ProductID
				inner join
				dbo.Orders o
				on o.OrderID = od.OrderID
		group by	p.ProductName, o.ShipCity
		) A
) B
where	B.rnk <= 5 and B.ProductName = @ProductName
go
;
/*
To exectue:

exec sp_product_order_city_Mei @ProductName = 'Ipoh Coffee'
go
*/

/*
	created a view used in question 7
*/
create view foundEmployees
as 
select	e.EmployeeID, e.FirstName, e.LastName, count(1) as cnt
from	dbo.Employees e
		inner join
		dbo.EmployeeTerritories et
		on e.EmployeeID = et.EmployeeID
		inner join
		dbo.Territories t
		on et.TerritoryID = t.TerritoryID
where	t.TerritoryDescription = 'Troy'
group by	e.EmployeeID, e.FirstName, e.LastName
go
/*
	question 7
*/
BEGIN TRANSACTION;
go
create procedure sp_move_employees_Mei
as
begin
select	f.EmployeeID, f.FirstName, f.LastName
From	foundEmployees f;

Declare @countOfFound int;
select	@countOfFound = cnt from foundEmployees
if @countOfFound > 0
	begin
	Declare @regionIdOfNorth int;
	select @regionIdOfNorth = RegionID from dbo.Region where RegionDescription = 'Northern';
	insert into dbo.Territories values(99999, 'Stevens Point', @regionIdOfNorth);
	update dbo.EmployeeTerritories set TerritoryID = 99999 where EmployeeID in (select EmployeeID from foundEmployees);
	end

end
go
;

/*
	question 8
*/
create trigger trigger_Mei on dbo.EmployeeTerritories
for insert
as
begin
if exists (
	select	et.EmployeeID
	from	dbo.EmployeeTerritories et
			inner join
			dbo.Territories t
			on et.TerritoryID = t.TerritoryID
	where	t.TerritoryDescription = 'Stevens Point'
	group by	et.EmployeeID
	having	count(1) > 100
)
	begin
	Declare @idOfTroy int;
	select @idOfTroy = TerritoryID from dbo.Territories where TerritoryDescription = 'Troy';
	update dbo.EmployeeTerritories set TerritoryID = @idOfTroy where EmployeeID in (select et.EmployeeID from dbo.EmployeeTerritories et inner join dbo.Territories t on et.TerritoryID = t.TerritoryID where t.TerritoryDescription = 'Stevens Point');
	end
end
go

ROLLBACK;
go

/*
	question 9
*/
create table city_Mei (
	id int primary key,
	city varchar(20)
)

create table people_Mei (
	id int primary key,
	[Name] varchar(20),
	City int foreign key references city_Mei(id)
)

insert into city_Mei values(1, 'Seattle');
insert into city_Mei values(2, 'Green Bay');
insert into people_Mei values(1, 'Aaron Rodgers', 2);
insert into people_Mei values(2, 'Russell Wilson', 1);
insert into people_Mei values(3, 'Jody Nelson', 2);

delete from city_Mei where city  = 'Seattle'
if @@ERROR <> 0
	begin
	insert into city_Mei values(3, 'Madison');
	update people_Mei set City = 3 where City = 1;
	delete from city_Mei where city  = 'Seattle'
	end
;
go

create view Packers_Mei
as
select	p.[Name], c.city
from	city_Mei c  
		inner join 
		people_Mei p  
		on c.id = p.City
where	c.city = 'Green Bay'

drop table people_Mei;
drop table city_Mei;
drop view Packers_Mei;
go

/*
	question 10
*/
create procedure sp_birthday_employees_Mei
as
select * into birthday_employees_Mei from dbo.Employees where DATEPART(MONTH, BirthDate) = 2;
go
/*
exec sp_birthday_employees_Mei
select * from birthday_employees_Mei
drop table birthday_employees_Mei
*/

/*
	question 11
*/
create procedure sp_your_mei_1
as
with buyNoOrOnlyOneCTE as (
select	c.City, c.CustomerID
from	dbo.Customers c
		left join
		dbo.Orders o
		on c.CustomerID = o.CustomerID
where	o.OrderID is null
union
select	o.ShipCity, o.CustomerID
from	dbo.Orders o
		inner join
		dbo.[Order Details] od
		on o.OrderID = od.OrderID
group by		o.ShipCity, o.CustomerID
having	count(distinct od.ProductID) = 1
)
select	b.City
from	buyNoOrOnlyOneCTE b
group by	b.City
having	count(b.CustomerID) >= 2
go
;

create procedure sp_your_mei_2
as
with buyNoOrOnlyOneCTE as (
select	c.City, c.CustomerID
from	dbo.Customers c
where	c.CustomerID not in (select o.CustomerID from dbo.Orders o)
union
select	o.ShipCity, o.CustomerID
from	dbo.[Order Details] od, dbo.Orders o
where	od.OrderID = o.OrderID
group by		o.ShipCity, o.CustomerID
having	count(distinct od.ProductID) = 1
)
select	b.City
from	buyNoOrOnlyOneCTE b
group by	b.City
having	count(b.CustomerID) >= 2
go

/*
	question 12

	If these two tables have different count of rows, then they are not having the same data.
	If these two tables have same count of rows, 
	then use a UNION clause:
		SELECT * FROM Table1
		UNION
		SELECT * FROM Table2
	if the count of rows of the result set is different from any of thw two tables, the two tables are not having the same data.

*/

/*
	question 14
*/
create table #table_q14 (FirstName varchar(20), LastName varchar(20), MiddleName varchar(20))
insert into #table_q14 values('John','Green', null);
insert into #table_q14 values('Mike','White', 'M');

select	CONCAT(FirstName, ' ', LastName, ' ', MiddleName + '.') as [Full Name]
from	#table_q14
;

/*
	question 15
*/
create table #table_q15 (
	Student	varchar(10),
	Marks int,
	Sex varchar(10)
)
insert into #table_q15 values('Ci',70,'F');
insert into #table_q15 values('Bob',80,'M');
insert into #table_q15 values('Li',90,'F');
insert into #table_q15 values('Mi',95,'M');

select	t.Student, t.Marks
from (
select	Student, Marks, rank() over(order by Marks desc) as rnk
from	#table_q15
where	Sex = 'F'
) t
where	rnk = 1
;

/*
	question 16
*/
select	Student, Marks, Sex
from	#table_q15
group by	Student, Marks, Sex
order by	Sex asc, Marks desc
;