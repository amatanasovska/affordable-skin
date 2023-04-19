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
    public int Price { get; set; }
    public Seller Seller{ get; set; }


}