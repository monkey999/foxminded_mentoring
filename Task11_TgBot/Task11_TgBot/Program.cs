using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Task11_TgBot
{
    class Program
    {

        static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .Build();

            string botToken = configuration["BotConfiguration:BotToken"];

            var botClient = new TelegramBotClient(botToken);
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");

            using (var cts = new CancellationTokenSource())
            {
                botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, null, cts.Token);

                Console.WriteLine("Telegram Exchange Rate Bot started. Press any key to stop...");
                Console.ReadKey();

                cts.Cancel();
            }
        }

        private static Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"Error occurred: {exception.Message}");
            return Task.CompletedTask;
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var botLogic = new BotLogic(botClient);

            await botLogic.HandleUpdate(update);
        }
    }
}
