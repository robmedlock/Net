﻿
begin
delete from Products;
insert into products (id, name, costprice, retailprice) values ('p1','Dog''s Dinner', 0.70, 1.42) ;
insert into products (id, name, costprice, retailprice) values ('p2','Knife', 0.60, 1.20) ;
insert into products (id, name, costprice, retailprice) values ('p3','Fork', 0.55, 1.10) ;
insert into products (id, name, costprice, retailprice) values ('p4','Spaghetti', 0.44, 0.88) ;
insert into products (id, name, costprice, retailprice) values ('p5','Cheddar Cheese', 0.67, 1.34) ;
insert into products (id, name, costprice, retailprice) values ('p6','Bean bag', 11.20, 20.40) ;
insert into products (id, name, costprice, retailprice) values ('p7','Bookcase', 32, 64) ;
insert into products (id, name, costprice, retailprice) values ('p8','Table', 70, 140) ;
insert into products (id, name, costprice, retailprice) values ('p9','Chair', 60, 120) ;
end

select count(*) from products;

