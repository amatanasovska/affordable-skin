namespace affordable_skin.Models.dto;

public class ProductPriceDto
{
    public int Key { get; set; }
    public String Name { get; set; }
    public String SellerName { get; set; }
    public String Date { get; set; }
    public int Price { get; set; }
    public String LinkToProduct { get; set; }

    public ProductPriceDto(int id, string name, string sellerName, string date, int price, string linkToProduct)
    {
        Key = id;
        Name = name;
        SellerName = sellerName;
        Date = date;
        Price = price;
        LinkToProduct = linkToProduct;
    }
}