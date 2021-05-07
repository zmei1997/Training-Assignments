/*
	Answer following questions:
	1.	In SQL Server, assuming you can find the result by using both joins and subqueries, which one would you prefer to use and why?
		I would prefer tp use JOIN because subquery is inefficient that it may be evaluated once for each row processed by the outer query.

	2.	What is CTE and when to use it?
		CTE is common table expressions. It can be used to create a recursive query, 
		to be the substitute for a view when do not have to store the definition in metadata,
		and to improve readability and manageability of complex SQL statements.

	3.	What are Table Variables? What is their scope and where are they created in SQL Server?
		Table Variable is a replacement of temporary tables when the data is not very large.
		It is scoped to the duration of the batch, function, or stored procedure.
		And it can be created within a Transact-SQL batch, stored procedure, or function.

	4.	What is the difference between DELETE and TRUNCATE? Which one will have better performance and why?
		DELETE is a data manipulation language, while TRUNCATE is a data definition language.
		Truncate reseeds identity values but delete doesn't.
		Truncate removes all records and doesn't fire triggers.
		Truncate is not possible when a table is referenced by a Foreign Key or tables are used in replication or with indexed views.
		Truncate has better performance because it makes less use of the transaction log.

	5.	What is Identity column? How does DELETE and TRUNCATE affect it?
		Identity column is the column contains the identification number of each row.
		Truncate reseeds identity values but delete doesn't.

	6.	What is difference between ¡°delete from table_name¡± and ¡°truncate table table_name¡±?
		Data can be restored after using Delete,
		but data cannot be restored after using truncate.

*/

use Northwind
go

/*
	Query 1
*/
select	distinct e.City
from	dbo.Employees e
		inner join
		dbo.Customers c
		on e.City = c.City
;

/*
	Query 2
*/
--Use sub-query
select	distinct c.City
from	dbo.Customers c
where	c.City not in (select City from dbo.Employees)
;

--Do not use sub-query
select	distinct c.City
from	dbo.Customers c
		left join
		dbo.Employees e
		on c.City = e.City
where	e.City is NULL
;

/*
	Query 3
*/
select	p.ProductID, p.ProductName, sum(od.Quantity) as [total order quantities]
from	dbo.[Order Details] od
		inner join
		dbo.Orders o
		on od.OrderID = o.OrderID
		inner join
		dbo.Products p
		on od.ProductID = p.ProductID
group by	p.ProductID, p.ProductName
;

/*
	Query 4
*/
select	c.City, sum(od.Quantity) as [total products ordered by city]
from	dbo.[Order Details] od
		inner join
		dbo.Orders o
		on od.OrderID = o.OrderID
		inner join
		dbo.Customers c
		on o.CustomerID = c.CustomerID
group by	c.City
;

/*
	Query 5
*/
--Use union
select	c1.City from dbo.Customers c1 group by c1.city having count(1) = 2
union
select	c2.City from dbo.Customers c2 group by c2.city having count(1) > 2
;

--Use sub-query and no union
select	distinct c1.City
from	dbo.Customers c1
		, (select c2.City from dbo.Customers c2 group by c2.city having count(1) >= 2) sub
where	c1.City = sub.City
;

/*
	Query 6
*/
select	distinct c.City
from	dbo.[Order Details] od
		inner join
		dbo.Orders o
		on od.OrderID = o.OrderID
		inner join
		dbo.Customers c
		on o.CustomerID = c.CustomerID
group by	c.City, od.ProductID
having	count(od.ProductID) >= 2
;

/*
	Query 7
*/
select	distinct c.ContactName
from	dbo.Customers c
		inner join
		dbo.Orders o
		on c.CustomerID = o.CustomerID
where	c.City <> o.ShipCity
;

/*
	Query 8
*/
with mostPopularCTE as (
select	top 5 od.ProductID, o.ShipCity, avg(od.UnitPrice) as avgPrice, sum(od.Quantity) as quantity
from	dbo.Customers c
		inner join
		dbo.Orders o
		on c.CustomerID = o.CustomerID
		inner join
		dbo.[Order Details] od
		on o.OrderID = od.OrderID
group by	od.ProductID, o.ShipCity
order by	quantity desc
), mostQuantityCTE as (
	select	mp.ProductID, mp.avgPrice, mp.ShipCity
			, DENSE_RANK() over(partition by mp.ProductID order by mp.quantity desc) as dsrank
	from	mostPopularCTE mp
)
select	mq.ProductID, mq.avgPrice, mq.ShipCity
from	mostQuantityCTE mq
where	mq.dsrank = 1
;

/*
	Query 9
*/
--Use sub-query
select	e.City 
from	dbo.Employees e
where	e.City not in (select o.ShipCity from dbo.Orders o)
;

--Do not use sub-query
select	e.City
from	dbo.Employees e
		left join
		dbo.Orders o
		on e.City = o.ShipCity
where	o.ShipCity is NULL
;

/*
	Query 10
*/
select	mostOrders.City, mostOrders.countOfOrder, mostTotalQuantity.totalQuantity
from (
	select	Top 1 e.City, count(o.OrderID) as countOfOrder 
	from	Employees e 
			inner join Orders o
			on e.EmployeeID = o.EmployeeID
	group by	e.City
	) mostOrders
	inner join 
	(
	select	Top 1 c.City, count(od.Quantity) as totalQuantity 
	from	[Order Details] od 
			inner join
			Orders o 
			on od.OrderID = o.OrderID
			inner join 
			Customers c 
			on c.CustomerID = o.CustomerID
	group by	c.City
	) mostTotalQuantity
	on mostOrders.City = mostTotalQuantity.City;
;

/*
	question 11
	
	Answer: Use DISTINCT clause or use GROUP BY clause
*/

/*
	Query 12
*/
select	e1.empid
from	Employee e1
		left join
		Employee e1
		on e1.empid = e2.mgrid
where	e2.empid is NULL
;

/*
	Query 13
*/
with countByDeptCTE as (
select	d.deptname as deptname, count(e.empid) as numberOfEmployee
from	Employee e
		inner join
		Dept d
		on e.deptid = d.deptid 
group by	d.deptname
)
, rankOfcountByDeptCTE as (
select	c.deptname, c.numberOfEmployee, rank() over(order by c.numberOfEmployee desc) as rnk
from	countByDeptCTE c
)
select	r.deptname, r.numberOfEmployee
from	rankOfcountByDeptCTE r
where	r.rnk = 1;
;

/*
	Query 14
*/
with rankOfSalaryCTE as (
select	d.deptname as deptname, e.empid as empid, e.salary as salary, rank() over(partition by e.deptid order by e.salary desc) as rnk
from	Employee e
		inner join
		Dept d
		on e.deptid = d.deptid
)
select	rs.deptname, rs.empid, rs.salary
from	rankOfSalaryCTE rs
where	rs.rnk <= 3
order by	rs.deptname, rs.rnk
;