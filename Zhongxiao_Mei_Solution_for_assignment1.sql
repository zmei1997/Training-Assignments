use AdventureWorks2017
go

/*
	question 1
*/
select	ProductID, [Name], Color, ListPrice
from	Production.Product
;

/*
	question 2
*/
select	ProductID, [Name], Color, ListPrice
from	Production.Product
where	ListPrice = 0
;

/*
	question 3
*/
select	ProductID, [Name], Color, ListPrice
from	Production.Product
where	Color is NULL
;

/*
	question 4
*/
select	ProductID, [Name], Color, ListPrice
from	Production.Product
where	Color is not NULL
;

/*
	question 5
*/
select	ProductID, [Name], Color, ListPrice
from	Production.Product
where	Color is not NULL
		and
		ListPrice > 0
;

/*
	question 6
*/
select	CONCAT([Name], Color) as Report
from	Production.Product
where	Color is not NULL
;

/*
	question 7
*/
select	'NAME: ' + [Name] + ' -- ' + 'COLOR: ' + Color as [Name And Color]
from	Production.Product
where	Color is not NULL
;

/*
	question 8
*/
select	ProductID, [Name]
from	Production.Product
where	ProductID between 400 and 500
;

/*
	question 9
*/
select	ProductID, [Name], Color
from	Production.Product
where	Color in ('black', 'blue')
;

/*
	question 10
*/
select	[Name] as Report
from	Production.Product
where	[Name] like 'S%'
;

/*
	question 11
*/
select	[Name], ListPrice
from	Production.Product
where	[Name] like 'S%'
order by	[Name] asc
;

/*
	question 12
*/
select	[Name], ListPrice
from	Production.Product
where	[Name] like '[A,S]%'
order by	[Name] asc
;

/*
	question 13
*/
select	[Name]
from	Production.Product
where	[Name] like 'SPO[^K]%'
order by	[Name]
;

/*
	question 14
*/
select	distinct Color as [unique colors]
from	Production.Product
--where	Color is not NULL
order by	Color desc
;

/*
	question 15
*/
select	distinct ProductSubcategoryID, Color
from	Production.Product
where	ProductSubcategoryID is not NULL
		and Color is not NULL
group by	ProductSubcategoryID, Color
order by	ProductSubcategoryID, Color
;

/*
	question 16
*/
-- solution that only includes products in red and black
select	ProductSubCategoryID
		, LEFT([Name],35) as [Name]
		, Color, ListPrice 
from	Production.Product
where	(Color IN ('Red','Black') 
		AND ListPrice BETWEEN 1000 AND 2000)
		OR
		(Color IN ('Red','Black') AND ProductSubCategoryID = 1)
order by	ProductID
;

-- solution that includes products in other colors (not only red and black)
select	ProductSubCategoryID
		, LEFT([Name],35) as [Name]
		, Color, ListPrice 
from	Production.Product
where	(Color IN ('Red','Black') 
		AND ListPrice BETWEEN 1000 AND 2000)
		OR
		(Color IN ('Red','Black') AND ProductSubCategoryID = 1)
		OR
		(Color not IN ('Red','Black'))
order by	ProductID
;

/*
	question 17
*/
select	ProductSubcategoryID, [Name], Color, ListPrice
from	Production.Product
where	Color in ('Red','Black') 
		and ProductSubCategoryID = 1
		or ListPrice between 1000 and 2000
;
