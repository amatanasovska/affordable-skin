using affordable_skin.Models;
using Microsoft.EntityFrameworkCore;

namespace affordable_skin.Data;

public class ShopContext:DbContext
{
    public ShopContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductPrice> ProductPrices { get; set; }
    public DbSet<Seller> Sellers { get; set; }
  
}
