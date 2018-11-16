use db1; 

create table Accounts (
	Id nvarchar(128) not null primary key, 
	Name nvarchar (max)
);

insert into accounts (id, name) values ('acc1','John Smith');
insert into accounts (id, name) values ('acc2','Jane Jones');
insert into accounts (id, name) values ('acc3','Brian Johnson');
insert into accounts (id, name) values ('acc4','Sue Smedley');

select * from accounts;