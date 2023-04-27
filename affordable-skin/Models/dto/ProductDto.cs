namespace affordable_skin.Models.dto;

public class ProductDto
{
    public int Key { get; set; }
    public String Image { get; set; }
    public String Name { get; set; }
    public String BrandName { get; set; }
    public int LowestPrice { get; set; }

    public ProductDto(int id, string image, string name, string brandName, int lowestPrice)
    {
        Key= id;
        Image = image;
        Name = name;
        BrandName = brandName;
        LowestPrice = lowestPrice;
    }
}