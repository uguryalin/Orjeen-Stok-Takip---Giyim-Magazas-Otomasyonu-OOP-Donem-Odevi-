using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orjeen_Stok_Takip.Models;
using Supabase.Postgrest;

namespace Orjeen_Stok_Takip.Services
{
    public static class StockService
    {
        public static async Task<List<StockMovement>> GetStockMovementsAsync()
        {
            try
            {
                var response = await SupabaseManager.Client
                    .From<StockMovement>()
                    .Order(x => x.CreatedAt, Constants.Ordering.Descending)
                    .Get();
                return response.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting stock movements: {ex.Message}");
                return new List<StockMovement>();
            }
        }

        public static async Task<StockMovement?> AddMovementAsync(string productId, string movementType, int quantity, decimal unitPrice, string? description)
        {
            try
            {
                var movement = new StockMovement
                {
                    ProductId = productId,
                    MovementType = movementType,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    Description = description,
                    UserId = AuthService.CurrentProfile?.Id,
                    CreatedAt = DateTime.UtcNow
                };
                
                var response = await SupabaseManager.Client.From<StockMovement>().Insert(movement);
                return response.Model;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding stock movement: {ex.Message}");
                throw;
            }
        }
    }
}
