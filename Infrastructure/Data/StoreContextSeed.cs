using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedData(StoreContext context)
        {
            if(!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands );
            }
               if(!context.ProductTypes.Any())
            {
                var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var type = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                context.ProductTypes.AddRange(type);
            }
        
             if(!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }
            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();  
        }
    }
}