use store;

DECLARE @orderid varchar
begin

insert into orders(date, orderStatus, account_id) 
values(getdate(), 0, 'acc4') 
set @orderid = scope_identity()

insert into LineItems (quantity, product_id, order_orderId) 
values (2, 'p5', @orderId)

insert into LineItems (quantity, product_id, order_orderId) 
values (1, 'p6', @orderId)

insert into LineItems (quantity, product_id, order_orderId) 
values (4, 'p7', @orderId)

end

print('order id ' +@orderid)