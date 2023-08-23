namespace Task11_TgBot
{
    public class DataProcessor
    {
        private string _replyMessage;
        private static HttpClient _client = new();

        public DataProcessor(HttpClient client)
        {
            _client = client;
        }

        public DataProcessor()
        {
        }

        public async Task<string> Process(string messageText)
        {
            string[] commandParts = messageText.Split(' ');

            if (commandParts.Length != 2 || commandParts[0].Length != 3 || !commandParts[0].All(char.IsUpper)
                || !Enum.TryParse(commandParts[0], out Enums.CurrencyCode currencyCode))
            {
                _replyMessage = "Invalid command format or currency symbol. Use {currency code} {dd.mm.yyyy} and available currency code from available ones!";

                return _replyMessage;
            }

            if (!DateTime.TryParseExact(commandParts[1], "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date) || date.Date > DateTime.Now.Date)
            {
                _replyMessage = "Invalid date format. Please use dd.mm.yyyy format.";

                return _replyMessage;
            }

            var allExchangeRates = await PrivatApi.GetExchangeRatesDataAsync(date, _client);
            var requiredExRate = allExchangeRates.ExchangeRate.FirstOrDefault(rate => rate.Currency == commandParts[0]);

            if (requiredExRate != null)
            {
                _replyMessage = $"Exchange Rate for {requiredExRate.Currency} to UAH on {allExchangeRates.Date}:\n" +
                                      $"Sale Rate: {requiredExRate.SaleRate}\nPurchase Rate: {requiredExRate.PurchaseRate}";

                return _replyMessage;
            }
            else
            {
                _replyMessage = $"No exchange rate data found for {commandParts[0]} on {date:dd.MM.yyyy}";

                return _replyMessage;
            }
        }
    }
}
