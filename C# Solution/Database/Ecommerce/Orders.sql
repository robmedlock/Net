use db1;

create table Orders(
	OrderId int identity(1,1) not null primary key,
	AccountId nvarchar(450) null,
	[Date] datetime2(7) not null,
	OrderStatus int not null,
);