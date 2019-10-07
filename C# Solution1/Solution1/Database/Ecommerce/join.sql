DECLARE @id int
SET @id = 22

select orderId, id as [Account id], name from Accounts
inner join Orders on Orders.AccountId = Accounts.Id
where OrderId = @id;

select LineItems.Id as LineItemId, LineItems.Quantity, Products.Id as ProductId, 
Products.Name, Products.CostPrice, Products.RetailPrice
from Products
inner join LineItems on LineItems.ProductId = Products.Id
where LineItems.OrderId = @id;