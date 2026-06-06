using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orjeen_Stok_Takip.Models;
using Supabase.Postgrest;

namespace Orjeen_Stok_Takip.Services
{
    public static class ProductService
    {
        public static async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                var response = await SupabaseManager.Client
                    .From<Product>()
                    .Order(x => x.Name, Constants.Ordering.Ascending)
                    .Get();
                return response.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting products: {ex.Message}");
                return new List<Product>();
            }
        }

        public static async Task<Product?> GetProductByBarcodeAsync(string barcode)
        {
            try
            {
                var response = await SupabaseManager.Client
                    .From<Product>()
                    .Where(x => x.Barcode == barcode)
                    .Get();
                
                return response.Models.Count > 0 ? response.Models[0] : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding product by barcode: {ex.Message}");
                return null;
            }
        }

        public static async Task<Product?> InsertProductAsync(Product product)
        {
            try
            {
                var response = await SupabaseManager.Client.From<Product>().Insert(product);
                return response.Model;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting product: {ex.Message}");
                throw;
            }
        }

        public static async Task<Product?> UpdateProductAsync(Product product)
        {
            try
            {
                var response = await SupabaseManager.Client.From<Product>().Update(product);
                return response.Model;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                throw;
            }
        }

        public static async Task DeleteProductAsync(string id)
        {
            try
            {
                var product = new Product { Id = id };
                await SupabaseManager.Client.From<Product>().Delete(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                throw;
            }
        }

        public static async Task<List<Product>> GetLowStockProductsAsync()
        {
            try
            {
                var products = await GetProductsAsync();
                return products.FindAll(x => x.StockQuantity <= x.MinStockLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting low stock: {ex.Message}");
                return new List<Product>();
            }
        }
    }
}
