create view latestPrices as
select * from AffordableSkin.dbo.ProductPrice where date = (select max(Date) from AffordableSkin.dbo.ProductPrice) 