create view minLatestPrices as 
select ProductId, Date, min(price) as Price from latestPrices 
group by ProductId, Date;
