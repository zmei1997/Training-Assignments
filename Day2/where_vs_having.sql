use AdventureWorks2017
go

/*
	using having after group by
*/
select	Color, count(1)
from	Production.Product
group by Color
having count(1) < 10

/*
	having is invalid before group by
*/
select	Color, count(1)
from	Production.Product
having	Color in ('Black', 'Red', 'White')
group by Color


/*
	can use where before group by
*/
select	Color, count(1)
from	Production.Product
where	Color in ('Black', 'Red', 'White')
group by Color

/*
	where is invalid after group by
*/
select	Color, count(1)
from	Production.Product
group by Color
where count(1) < 10

