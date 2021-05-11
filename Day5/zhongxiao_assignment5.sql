/*
Answer following questions:

1.	What is an object in SQL?
	Object is used to store or reference data, such as tables, views, clusters, indexes, stored procedures, and constraints.

2.	What is Index? What are the advantages and disadvantages of using Indexes?
	A performance tuning method of allowing faster retrieval of records from the table.
	Advantages: faster retrieval of records from the table.
	Disadvantages: Indexes take additional disk space.

3.	What are the types of Indexes?
	unique index, clustered index, non-clustered index

4.	Does SQL Server automatically create indexes when a table is created? If yes, under which constraints?
	Yes, unique index is automatically created when defining a primary key or unique constraint

5.	Can a table have multiple clustered index? Why?
	No, each table can only have one clustered index.

6.	Can an index be created on multiple columns? Is yes, is the order of columns matter?
	Yes, an index can be created on multiple columns. the order of columns is matter.

7.	Can indexes be created on views?
	Yes, indexes can be created on views.

8.	What is normalization? What are the steps (normal forms) to achieve normalization?
	The process of organizing data to avoid duplication and redundancy.
	First normal form, Second normal form, Third normal form.

9.	What is denormalization and under which scenarios can it be preferable?
	Denormalization is a technique which is used to access data from higher to lower forms of a database.
	To increase the performance of the entire infrastructure as it introduces redundancy into a table.

10.	How do you achieve Data Integrity in SQL Server?
	1. Constraints are used for enforcing, validating, or restricting data.
	2. Entity integrity ensures each row in a table is a uniquely identifiable entity,
	apply Entity integrity to the Table by specifying a primary key, unique key, and not null.
	3. Referential integrity ensures the relationship between the Tables, apply this using a Foreign Key constraint.
	4. Domain integrity ensures the data values in a database follow defined rules for values, range, and format.

11.	What are the different kinds of constraint do SQL Server have?
	not null, unique, primary key, foreign key, check constraints

12.	What is the difference between Primary Key and Unique Key?
	primary key doesn't allow NULL value but unique key allows NULL values.

13.	What is foreign key?
	Foreign key maintains referential integrity by enforcing a link between the data in two tables.
	The foreign key in the child table references the primary key in the parent table.

14.	Can a table have multiple foreign keys?
	Yes

15.	Does a foreign key have to be unique? Can it be null?
	No, a foreign key doesn't have to be unique.
	It can be null.

16.	Can we create indexes on Table Variables or Temporary Tables?
	No

17.	What is Transaction? What types of transaction levels are there in SQL Server?
	It is a single recoverable unit of work that executes either completely or not at all.
	Read Uncommitted, Read Committed, Repeatable Read, Serializable, Snapshot Isolation.

*/

/*
	question 1
*/
create table customer (
	cust_id int primary key,
	iname varchar (50)
);

create table [order] (
	order_id int primary key,
	cust_id int foreign key references customer(cust_id),
	amount money,
	order_date smalldatetime
);

select	c.iname, sum(o.order_id)
from	customer c inner join [order] o
		on c.cust_id = o.cust_id
where	DATEPART(year, o.order_date) = 2002
group by	c.iname
;


/*
	question 2
*/
Create table person (
	id int primary key, 
	firstname varchar(100), 
	lastname varchar(100)
);

select	id, firstname, lastname
from	person
where	lastname = 'A%'
;

/*
	question 3
*/
Create table person (person_id int primary key, manager_id int null, name varchar(100) not null);

select	m.[name] as [names of all top managers], count(1) as [number of people report directly]
from person p, (
	select	person_id, [name]
	from	person
	where	manager_id is null
) m
where	p.manager_id = m.person_id
group by	m.[name]
;

/*
	question 4

	Answer: insert, update, or delete
*/

/*
	question 5
*/
create table Companies (
	company_id int primary key,
	company_name varchar(20)
);

create table Contacts (
	contact_id int primary key,
	contact_name varchar(20),
	suite varchar(20),
	mail_drop_records varchar(50)
);

create table Physical_locations (
	physical_id int primary key,
	addresses varchar(50)
);

create table Divisions (
	division_id int not null,
	division_name varchar(20),
	physical_id int foreign key references physical_locations(physical_id),
	company_id int foreign key references Companies(company_id),
	contact_id int foreign key references Contacts(contact_id)
);
