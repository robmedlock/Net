create table Accounts (
	Id nvarchar(128) not null primary key, 
	Name nvarchar (max)
);

create table Products(
	Id nvarchar(128) not null primary key,
	[Name] nvarchar(max) null,
	CostPrice float not null,
	RetailPrice float not null,
	[RowVersion] rowversion not null
);

create table Orders(
	OrderId int identity(1,1) not null primary key,
	AccountId nvarchar(450) null,
	[Date] datetime2(7) not null,
	OrderStatus int not null,
);

create table  LineItems(
	Id int identity(1,1) not null,
	OrderId int null,
	ProductId nvarchar(450) null,
	Quantity int not null
);