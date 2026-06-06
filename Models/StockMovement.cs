using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Orjeen_Stok_Takip.Models
{
    [Table("stock_movements")]
    public class StockMovement : BaseModel
    {
        [PrimaryKey("id", false)]
        public string Id { get; set; } = null!;

        [Column("product_id")]
        public string ProductId { get; set; } = null!;

        [Column("user_id")]
        public string? UserId { get; set; }

        [Column("movement_type")]
        public string MovementType { get; set; } = null!; // "IN" or "OUT"

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unit_price")]
        public decimal UnitPrice { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
