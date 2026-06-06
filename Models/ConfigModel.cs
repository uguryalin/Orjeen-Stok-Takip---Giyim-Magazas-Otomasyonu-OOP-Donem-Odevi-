namespace Orjeen_Stok_Takip.Models
{
    public class ConfigModel
    {
        public string SupabaseUrl { get; set; } = "https://gjxkcgcqfzdedmmfxglz.supabase.co";
        public string SupabaseKey { get; set; } = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImdqeGtjZ2NxZnpkZWRtbWZ4Z2x6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3ODAwNjI2OTgsImV4cCI6MjA5NTYzODY5OH0.gLOTrjITy7ZnCucU0jixYBDIiiXjXZ1vQOQK2Bml6l8";
        public string GeminiApiKey { get; set; } = "AQ.Ab8RN6IuTb-j6mLCQ0Qi6GHHKRrco-SZb6uSKugcsGhDtBRRHg";

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(SupabaseUrl) && 
                   !string.IsNullOrWhiteSpace(SupabaseKey);
        }
    }
}
