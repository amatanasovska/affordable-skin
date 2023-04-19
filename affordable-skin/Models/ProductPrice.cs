using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace affordable_skin.Models;

[Table("ProductPrice")]
[PrimaryKey(nameof(Date), nameof(ProductId))]
public class ProductPrice
{
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    private String Date { get; set; }
    private int Price { get; set; }

}