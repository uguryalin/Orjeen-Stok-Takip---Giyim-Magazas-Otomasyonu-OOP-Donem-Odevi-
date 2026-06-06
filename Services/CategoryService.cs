using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orjeen_Stok_Takip.Models;
using Supabase.Postgrest;

namespace Orjeen_Stok_Takip.Services
{
    public static class CategoryService
    {
        public static async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var response = await SupabaseManager.Client
                    .From<Category>()
                    .Order(x => x.Name, Constants.Ordering.Ascending)
                    .Get();
                return response.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting categories: {ex.Message}");
                return new List<Category>();
            }
        }

        public static async Task<Category?> InsertCategoryAsync(string name, string description)
        {
            try
            {
                var category = new Category
                {
                    Name = name,
                    Description = description
                };
                var response = await SupabaseManager.Client.From<Category>().Insert(category);
                return response.Model;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting category: {ex.Message}");
                throw;
            }
        }

        public static async Task<Category?> UpdateCategoryAsync(string id, string name, string description)
        {
            try
            {
                var category = new Category
                {
                    Id = id,
                    Name = name,
                    Description = description
                };
                var response = await SupabaseManager.Client.From<Category>().Update(category);
                return response.Model;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating category: {ex.Message}");
                throw;
            }
        }

        public static async Task DeleteCategoryAsync(string id)
        {
            try
            {
                var category = new Category { Id = id };
                await SupabaseManager.Client.From<Category>().Delete(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting category: {ex.Message}");
                throw;
            }
        }
    }
}
