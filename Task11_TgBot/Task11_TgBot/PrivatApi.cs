using Newtonsoft.Json;
using Task11_TgBot.Models;

namespace Task11_TgBot
{
    public static class PrivatApi
    {
        public static async Task<ExchangeRatesData> GetExchangeRatesDataAsync(DateTime date, HttpClient client)
        {
            string apiUrl = $"https://api.privatbank.ua/p24api/exchange_rates?json&date={date:dd.MM.yyyy}";

            try
            {
                string json = await client.GetStringAsync(apiUrl);
                ExchangeRatesData data = JsonConvert.DeserializeObject<ExchangeRatesData>(json);

                return data;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error making HTTP request: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error deserializing JSON data: {ex.Message}", ex);
            }
        }
    }
}
