using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Orjeen_Stok_Takip.Helpers;

namespace Orjeen_Stok_Takip.Services
{
    public static class GeminiService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string> ChatWithAssistantAsync(string userMessage, string stockContext)
        {
            var config = ConfigHelper.LoadConfig();
            if (string.IsNullOrWhiteSpace(config.GeminiApiKey))
            {
                return "Lütfen ayarlardan geçerli bir Gemini API anahtarı yapılandırın.";
            }

            try
            {
                string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent?key={config.GeminiApiKey}";

                string systemInstruction = 
                    "Sen Orjeen Giyim Mağazası'nın akıllı yapay zeka stok danışmanısın. " +
                    "Kullanıcılara stok seviyeleri, sipariş önerileri, satış trendleri ve ürün performansları hakkında profesyonel tavsiyeler verirsin. " +
                    "Cevaplarını her zaman Türkçe, kibar, kısa ve net bir üslupla ver. " +
                    "Aşağıda mağazadaki mevcut ürünlerin ve stok durumlarının özeti yer almaktadır:\n\n" + stockContext;

                var payload = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = $"{systemInstruction}\n\nKullanıcı Sorusu: {userMessage}" }
                            }
                        }
                    }
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic? result = JsonConvert.DeserializeObject(jsonResponse);
                
                string reply = result?.candidates?[0]?.content?.parts?[0]?.text ?? "Yanıt alınamadı.";
                return reply;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gemini API error: {ex.Message}");
                return $"Hata oluştu: {ex.Message}";
            }
        }
    }
}
