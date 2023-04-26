using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace affordable_skin.Models;

[Table("Product")]
[PrimaryKey(nameof(Id))]
public class Product
{
    public int Id;
    public String Image { get; set; }
    public String Name { get; set; }
    [ForeignKey("Brand")]
    public String BrandName { get; set; }
    public Brand Brand { get; set; }
    public String Link { get; set; }
    public int LowestPrice { get; set; }
}