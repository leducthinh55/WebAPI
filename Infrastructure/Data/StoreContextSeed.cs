using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {

        public static async Task CreateStoreContextSeed(StoreContext dbcontext, ILoggerFactory loggerFactory)
        {
            try 
            {
                //if(!dbcontext.ProductBrands.Any())
                //{
                //    var JsonBrand = File.ReadAllText("../Infrastructure/SeedData/brands.json");
                //    var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(JsonBrand);
                //    foreach (var brand in productBrands)
                //    {
                //        dbcontext.ProductBrands.Add(brand);
                //    }
                //    await dbcontext.SaveChangesAsync();
                //}

                //if(!dbcontext.ProductTypes.Any())
                //{
                //    var JsonType = File.ReadAllText("../Infrastructure/SeedData/types.json");
                //    var productType = JsonSerializer.Deserialize<List<ProductType>>(JsonType);
                //    foreach (var type in productType)
                //    {
                //        dbcontext.ProductTypes.Add(type);
                //    }
                //    await dbcontext.SaveChangesAsync();
                //}
                
                if(!dbcontext.Products.Any())
                {
                    var JsonProduct = File.ReadAllText("../Infrastructure/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(JsonProduct);
                    foreach (var product in products)
                    {
                        dbcontext.Products.Add(product);
                    }
                    await dbcontext.SaveChangesAsync();
                }
                
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, "An error occur when migration");
            }
        }
    }
}
