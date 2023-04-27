using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace affordable_skin.Models;

[Table("Product")]
[PrimaryKey(nameof(Id))]
public class Product
{
    [JsonPropertyName("Id")]
    public int Id;
    public String Image { get; set; }
    public String Name { get; set; }
    [ForeignKey("Brand")]
    public String BrandName { get; set; }
    public Brand Brand { get; set; }
    public int LowestPrice { get; set; }
    public IEnumerable<ProductPrice> ProductsPrices { get; set; }

}