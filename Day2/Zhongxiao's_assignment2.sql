/*
Answer following questions

1.	What is a result set?
	A set of data returned by a select statement or a stored procedure.

2.	What is the difference between Union and Union All?
	UNION does not allow duplicate records, while UNION ALL allows duplicate records.

3.	What are the other Set Operators SQL Server has?
	INTERSECT, EXCEPT

4.	What is the difference between Union and Join?
	Union combines tables or result set vertically, while Join combines tables or result set horizontally.

5.	What is the difference between INNER JOIN and FULL JOIN?
	INNER JOIN returns only the matching rows from left table and right table, 
	while FULL JOIN returns all rows from both left and right table including non-matching rows.

6.	What is difference between left join and outer join
	left join is one type of outer join.

7.	What is cross join?
	it returns the Cartesian product of the sets of records from two joined tables.

8.	What is the difference between WHERE clause and HAVING clause?
		1) When the query has a GROUP BY clause, WHERE can only be used before GROUP BY, 
			while HAVING can only be used after GROUP BY.
		2) We cannot use HAVING without GROUP BY. However, we can use WHERE without GROUP BY.

9.	Can there be multiple group by columns?
	Yes, group by can contain multiple columns. 

*/

use AdventureWorks2017
go

/*
	query 1
*/
select	count(1) as NumberOfProduct
from	Production.Product
;

/*
	query 2
*/
select	count(1)
from	Production.Product
where	ProductSubcategoryID is not NULL
;

/*
	query 3
*/
select	ProductSubcategoryID, count(1) as CountedProducts
from	Production.Product
where	ProductSubcategoryID is not NULL
group by	ProductSubcategoryID
;

/*
	query 4
*/
select	count(1)
from	Production.Product
where	ProductSubcategoryID is NULL
;

/*
	query 5
*/
select	sum(Quantity)
from	Production.ProductInventory
;

/*
	query 6
*/
select	ProductID, sum(Quantity) as TheSum
from	Production.ProductInventory
where	LocationID = 40
group by	ProductID
Having	sum(Quantity) < 100
;

/*
	query 7
*/
select	Shelf, ProductID, sum(Quantity) as TheSum
from	Production.ProductInventory
where	LocationID = 40
group by	shelf, ProductID
Having	sum(Quantity) < 100
;

/*
	query 8
*/
select	avg(Quantity)
from	Production.ProductInventory
where	LocationID = 10
;

/*
	query 9
*/
select	ProductID, Shelf, avg(Quantity) as TheAvg
from	Production.ProductInventory
group by	ProductID, Shelf
;/*
	query 10
*/
select	ProductID, Shelf, avg(Quantity) as TheAvg
from	Production.ProductInventory
where	Shelf <> 'N/A'
group by	ProductID, Shelf
;

/*
	query 11
*/
select	Color, Class, count(1) as TheCount, avg(ListPrice) as AvgPrice
from	Production.Product
where	Color is not NULL and Class is not NULL
group by	Color, Class
;

/*
	query 12
*/
select	c.[Name] as Country, s.[Name] as Province
from	Person.CountryRegion c
		inner join
		Person.StateProvince s
		on c.CountryRegionCode = s.CountryRegionCode
;

/*
	query 13
*/
select	c.[Name] as Country, s.[Name] as Province
from	Person.CountryRegion c
		inner join
		Person.StateProvince s
		on c.CountryRegionCode = s.CountryRegionCode
where	c.[Name] in ('Germany', 'Canada')
;

/*
	using Northwind
*/
use Northwind
go

/*
	query 14
*/
select	p.ProductName
from	dbo.Products p
		inner join
		dbo.[Order Details] od
		on p.ProductID = od.ProductID
		inner join
		dbo.Orders o
		on od.OrderID = o.OrderID
where	DATEDIFF(year, GETDATE(), o.OrderDate) <= 25
;/*
	query 15
*/
select	top 5 ShipPostalCode
from	dbo.Orders
group by	ShipPostalCode
order by	count(ShipPostalCode) desc
;

/*
	query 16
*/
select	top 5 ShipPostalCode
from	dbo.Orders
where	DATEDIFF(year, GETDATE(), OrderDate) <= 20
group by	ShipPostalCode
order by	count(ShipPostalCode) desc
;

/*
	query 17
*/
select	City, count(CustomerID) as NumOfCustomer
from	dbo.Customers
group by	City
;

/*
	query 18
*/
select	City, count(CustomerID) as NumOfCustomer
from	dbo.Customers
group by	City
having	count(CustomerID) > 10
;

/*
	query 19
*/
select	distinct c.ContactName
from	dbo.Customers c
		inner join
		dbo.Orders o
		on c.CustomerID = o.CustomerID
where	o.OrderDate > '1/1/98'
;

/*
	query 20
*/
with mostRecent as (
select	distinct c.ContactName as [customer name], o.OrderDate as [Most Recent OrderDate]
		, ROW_NUMBER() over(partition by c.ContactName order by o.OrderDate desc) as rowNumber
from	dbo.Customers c
		inner join
		dbo.Orders o
		on c.CustomerID = o.CustomerID
)
select	m.[customer name], m.[Most Recent OrderDate]
from	mostRecent m
where	m.rowNumber = 1
;

/*
	query 21
*/select	c.ContactName, sum(od.Quantity) as [count of products]
from	dbo.Customers c
		inner join
		dbo.Orders o
		on c.CustomerID = o.CustomerID
		inner join
		dbo.[Order Details] od
		on o.OrderID = od.OrderID
group by	c.ContactName
;

/*
	query 22
*/select	c.CustomerID, sum(od.Quantity) as [count of products]
from	dbo.Customers c
		inner join
		dbo.Orders o
		on c.CustomerID = o.CustomerID
		inner join
		dbo.[Order Details] od
		on o.OrderID = od.OrderID
group by	c.CustomerID
having	sum(od.Quantity) > 100
;

/*
	query 23
*/
select	sup.CompanyName as [Supplier Company Name], sh.CompanyName as [Shipping Company Name]
from	dbo.Suppliers sup
		cross join
		dbo.Shippers sh
;

/*
	query 24
*/
select	o.OrderDate, p.ProductName
from	dbo.Products p
		inner join
		dbo.[Order Details] od
		on p.ProductID = od.ProductID
		inner join
		dbo.Orders o
		on od.OrderID = o.OrderID
group by	o.OrderDate, p.ProductName
;

/*
	query 25
*/
select	e1.EmployeeID, e1.FirstName, e1.LastName
		, e2.EmployeeID, e2.FirstName, e2.LastName
from	dbo.Employees e1
		inner join
		dbo.Employees e2
		on e1.Title = e2.Title
where	e1.EmployeeID <> e2.EmployeeID
;

/*
	query 26
*/
select	e1.EmployeeID, e1.FirstName, e1.LastName
from	dbo.Employees e1
		inner join
		dbo.Employees e2
		on e1.EmployeeID = e2.ReportsTo
group by	e1.EmployeeID, e1.FirstName, e1.LastName
having	count(1) > 2
;

/*
	query 27
*/
select	City, ContactName, 'Customer' as [Type]
from	dbo.Customers
union
select	City, ContactName, 'Supplier' as [Type]
from	dbo.Suppliers
;

/*
	query 28:

	select	*
	from	F1.T1
			inner join
			F2.T2
			on F1.T1 = F2.T2

	the result of this query:

		F1.T1	F2.T2
		2		2
		3		3
*/

/*
	query 29:
	
	select	*
	from	F1.T1
			left join
			F2.T2
			on F1.T1 = F2.T2

	the result of this query:

		F1.T1	F2.T2
		1		NULL
		2		2
		3		3
*/