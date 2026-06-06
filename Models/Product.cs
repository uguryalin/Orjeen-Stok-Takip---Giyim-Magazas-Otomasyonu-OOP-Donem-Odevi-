using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Orjeen_Stok_Takip.Models
{
    [Table("products")]
    public class Product : BaseModel
    {
        [PrimaryKey("id", false)]
        public string Id { get; set; } = null!;

        [Column("category_id")]
        public string? CategoryId { get; set; }

        [Column("barcode")]
        public string Barcode { get; set; } = null!;

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("brand")]
        public string? Brand { get; set; }

        [Column("color")]
        public string? Color { get; set; }

        [Column("size")]
        public string? Size { get; set; }

        [Column("purchase_price")]
        public decimal PurchasePrice { get; set; }

        [Column("sale_price")]
        public decimal SalePrice { get; set; }

        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

        [Column("min_stock_level")]
        public int MinStockLevel { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
