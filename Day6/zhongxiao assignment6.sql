/*
	1.	Design a Database for a company to Manage all its projects
*/
create table Countries (
	id int primary key,
	[name] varchar(25)
);

create table Cities (
	city_id int primary key,
	[name] varchar(25),
	country_id int foreign key references Countries(id),
	number_of_inhabitants int
);

create table Projects (
	code int primary key,
	title varchar(50),
	starting_date Date,
	end_date Date,
	assigned_budget decimal,
	person_in_charge varchar(25)
);

create table HeadOffice (
	[name] varchar(25) unique,
	city_id	int foreign key references Cities(city_id),
	country_id int foreign key references Countries(id),
	[address] varchar(50),
	phone_number int,
	director_name varchar(25)
);

create table Operations (
	id int not null,
	details varchar(50),
	project_id int foreign key references Projects(code),
	city_id int foreign key references Cities(city_id)
);

/*
	2.	Design a database for a lending company which manages lending among people (p2p lending)
*/
create table Lenders (
	id int primary key,
	[name] varchar(25) not null,
	available_amount_of_money decimal(10, 2) not null
);

create table Borrowers (
	id int primary key,
	[name] varchar(25) not null,
	company varchar(25) not null,
	risk_value int not null
);

create table Loans (
	loan_code int primary key,
	total_amount decimal(20, 2) not null,
	refund_deadline Date not null,
	interest_rate decimal(5, 2) not null,
	purpose varchar(100),
	borrower_id int foreign key references Borrowers(id) not null,
	Lender_id int foreign key references Lenders(id),
	invest_amount_from_lender decimal(20, 2)
);

/*
	3.	Design a database to maintain the menu of a restaurant.
*/
create table Categories (
	id int primary key,
	[name] varchar(25) not null,
	short_description varchar(50),
	employee_in_charge_name varchar(25) not null
);

create table Course (
	id int primary key,
	category_id int foreign key references Categories(id),
	[name] varchar(25) not null,
	short_description varchar(50),
	photo varchar(100),
	final_price decimal(10, 2) not null
);

create table Recipes (
	course_id int foreign key references Course(id),
	name_of_ingredients varchar(50) not null,
	required_amount decimal(10,2) not null,
	units_of_measurements varchar(25) not null,
	current_amount decimal(10,2) not null
);