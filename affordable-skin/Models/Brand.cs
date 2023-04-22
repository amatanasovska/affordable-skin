using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace affordable_skin.Models;

[Table("Brand")]
[PrimaryKey(nameof(Name))]
public class Brand
{
    public String Name { get; set; }  
    public IEnumerable<Product> Products { get; set; }

}