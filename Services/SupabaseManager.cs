using System;
using System.Threading.Tasks;
using Supabase;
using Orjeen_Stok_Takip.Helpers;
using Orjeen_Stok_Takip.Models;

namespace Orjeen_Stok_Takip.Services
{
    public static class SupabaseManager
    {
        private static Client? _client;
        
        public static Client Client
        {
            get
            {
                if (_client == null)
                {
                    Initialize();
                }
                return _client ?? throw new InvalidOperationException("Supabase client is not initialized. Please configure settings.");
            }
        }

        public static bool IsInitialized => _client != null;

        public static void Initialize()
        {
            var config = ConfigHelper.LoadConfig();
            if (config.IsValid())
            {
                try
                {
                    var options = new SupabaseOptions
                    {
                        AutoConnectRealtime = true
                    };
                    _client = new Client(config.SupabaseUrl, config.SupabaseKey, options);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error initializing Supabase client: {ex.Message}");
                    _client = null;
                }
            }
            else
            {
                _client = null;
            }
        }
    }
}
