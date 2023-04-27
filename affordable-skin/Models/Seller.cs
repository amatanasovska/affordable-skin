using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace affordable_skin.Models;

[Table("Seller")]
[PrimaryKey(nameof(Name))]

public class Seller
{
    public String Name{ get; set; }
    public String Webpage{ get; set; }
    public String Logo {get; set;}
    public IEnumerable<ProductPrice> ProductsPrices { get; set; }
    
}