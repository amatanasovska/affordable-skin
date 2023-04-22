create trigger dbo.updateLowestPrice
on dbo.ProductPrice
after update
as
begin
	update dbo.Product set LowestPrice =
	(
	select Price from (
			select ProductId, Date, min(price) as Price from 
			(
				select * from AffordableSkin.dbo.ProductPrice pp1
				where date = (select max(Date) from AffordableSkin.dbo.ProductPrice pp2
				where pp1.ProductId=pp2.ProductId
			) 
			) as lp group by ProductId, Date
		) as mlp
		where mlp.ProductId = dbo.Product.Id
)
end