using affordable_skin.Data;
using affordable_skin.Models;
using affordable_skin.Repositories.GenericRepository;

namespace affordable_skin.Repositories.Impl;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ShopContext context) : base(context)
    {
        
    }

    public IEnumerable<ProductPrice> FindLatestPricesByProductId(int id)
    {
        return 
            (from productPrice in _context.ProductPrices
            where productPrice.ProductId == id &&
                  (productPrice.Date == _context.ProductPrices
                      .Where(x => x.ProductId
                                  == productPrice.ProductId)
                      .Max(x => x.Date))
            select productPrice).ToList() ;
    }

    public IEnumerable<Product> GetProductsByBrandName(string brand)
    {
        return (from product in _context.Products
            where product.BrandName == brand
            select product).ToList();
    }

    public IEnumerable<Product> GetProductsByBrandNameContaining(string word)
    {
        return (from product in _context.Products
            where product.BrandName.Contains(word)
            select product);
    }

    public IEnumerable<Product> GetProductsByNameContaining(string word)
    {
        return (from product in _context.Products
            where product.Name.Contains(word)
            select product);
    }
}