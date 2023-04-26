using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace affordable_skin.Models;

[Table("ProductPrice")]
[PrimaryKey(nameof(Id))]
public class ProductPrice
{
    public int Id { get; set; }
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    [ForeignKey("Seller")]
    public String SellerName { get; set; }
    public Seller Seller{ get; set; }
    public String Date { get; set; }
    public int Price { get; set; }

}