using ECommerceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                #region ProductBrand Seed data
                if (!context.ProductBrands.Any())
                {
                    using var transaction = context.Database.BeginTransaction();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrands] ON;");

                    var brandsText = File.ReadAllText("../ECommerceApp.Infrastructure/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsText);

                    foreach (var item in brands)
                    {
                        context.Add(item);
                    }
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrands] OFF;");
                    transaction.Commit();
                }
                #endregion

                #region ProductType Seed data
                if (!context.ProductTypes.Any())
                {
                    using var transaction = context.Database.BeginTransaction();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ECommerceApp].[dbo].[ProductTypes] ON;");

                    var productTypesText = File.ReadAllText("../ECommerceApp.Infrastructure/SeedData/types.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesText);

                    foreach (var item in productTypes)
                    {
                        context.Add(item);
                    }

                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ECommerceApp].[dbo].[ProductTypes] OFF;");
                    transaction.Commit();

                }
                #endregion

                #region Products Seed data
                if (!context.Products.Any())
                {
                    var productText = File.ReadAllText("../ECommerceApp.Infrastructure/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productText);

                    foreach (var item in products)
                    {
                        context.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                #endregion
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);

            }
        }
    }
}
