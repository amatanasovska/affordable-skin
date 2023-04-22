create view minLatestPricesViewWithSellers as
select lp.* from latestPrices lp, minLatestPrices mlp 
where lp.ProductId=mlp.ProductId and lp.Date=mlp.Date and lp.Price = mlp.Price
