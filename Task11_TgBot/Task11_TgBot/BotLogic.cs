using Newtonsoft.Json;
using Task11_TgBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Task11_TgBot
{
    public class BotLogic
    {
        private readonly ITelegramBotClient _botClient;

        public BotLogic(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task HandleUpdate(Update update)
        {
            if (update.Message is not { } message || message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;
            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            try
            {
                var dataProcessor = new DataProcessor();
                var response = await dataProcessor.Process(messageText);
                await NotifyUser(chatId, response);
            }

            catch (HttpRequestException ex)
            {
                await NotifyUser(chatId, $"Error connecting to the API: {ex.Message}");
            }
            catch (Exception ex)
            {
                await NotifyUser(chatId, $"An error occurred: {ex.Message}");
            }
        }

        private async Task NotifyUser(long chatId, string message)
        {
            await _botClient.SendTextMessageAsync(chatId, message);
        }
    }
}
