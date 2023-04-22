create view latestPrices as
select * from AffordableSkin.dbo.ProductPrice pp1
where date = (select max(Date) from AffordableSkin.dbo.ProductPrice pp2
	where pp1.ProductId=pp2.ProductId

) 