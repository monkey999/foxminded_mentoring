using System.Net;
using System.Text.Json;
using Task11_TgBot;
using Task11_TgBot.Models;
using Xunit;

namespace TgBot.Tests.DataProcessor_Tests
{
    public class DataProcessorTests
    {
        public class HttpMessageHandlerMock : HttpMessageHandler
        {
            private readonly HttpResponseMessage? _response;
            private readonly HttpStatusCode _code;

            public HttpMessageHandlerMock(HttpStatusCode code)
            {
                _code = code;
            }

            public HttpMessageHandlerMock(HttpResponseMessage response)
            {
                _response = response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (_response != null)
                {
                    return Task.FromResult(_response);
                }

                return Task.FromResult(new HttpResponseMessage()
                {
                    StatusCode = _code,
                });
            }
        }

        [Fact]
        public async Task Process_ValidInput_ReturnsExchangeRateMessage()
        {
            string messageText = "USD 25.07.2023";

            string apiResponse =
             $"{{\"Date\":\"25.07.2023\"," +
             $"\"ExchangeRate\":[{{\"Currency\":\"USD\"," +
             $"\"SaleRate\":27," +
             $"\"PurchaseRate\":26.5}}]}}";

            var http = new HttpClient(new HttpMessageHandlerMock(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(apiResponse)
            }));

            var dataProcessor = new DataProcessor(http);
            string result = await dataProcessor.Process(messageText);

            var exchangeRatesData = JsonSerializer.Deserialize<ExchangeRatesData>(apiResponse);

            string expected = $"Exchange Rate for {exchangeRatesData.ExchangeRate[0].Currency} to UAH on {exchangeRatesData.Date}:\n" +
                              $"Sale Rate: {exchangeRatesData.ExchangeRate[0].SaleRate}\n" +
                              $"Purchase Rate: {exchangeRatesData.ExchangeRate[0].PurchaseRate}";

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Process_InvalidCurrencyCode_ReturnsErrorMessage()
        {
            string messageText = "XYZ 25.07.2023";

            string response = "Invalid command format or currency symbol. Use {currency code} {dd.mm.yyyy} and available currency code from available ones!";

            var dataProcessor = new DataProcessor();
            string result = await dataProcessor.Process(messageText);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(response, result);
        }

        [Fact]
        public async Task Process_InvalidDateFormat_ReturnsErrorMessage()
        {
            string messageText = "USD 25/07/2023";

            string response = "Invalid date format. Please use dd.mm.yyyy format.";

            var dataProcessor = new DataProcessor();
            string result = await dataProcessor.Process(messageText);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(response, result);
        }
    }
}
