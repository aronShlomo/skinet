using System.Text.Json;
using Core.Entities;
namespace Infrastructure.Data
{
    public class StoreContextSeed 
    {
        
        public static async Task SeedAsync(StoreContext context)
        {
            if(!context.ProductBrands.Any())
            {
            var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brand.json");
            var brand = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
            context.ProductBrands.AddRange(brand);

                      
            }
        }
    }
}