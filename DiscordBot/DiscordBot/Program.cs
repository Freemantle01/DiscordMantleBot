using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;


namespace DiscordBot
{
    public class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider service;

        public static void Main(string[] args)
        {
            try
            {
                new Program().MainAsync().GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to start bot. Error message: {e?.Message}");
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _client.Log += Log;
            service = new ServiceCollection()
                .AddSingleton(this)
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .AddSingleton<CommandHandler>()
                .AddSingleton<FileService>()
                .AddSingleton<ChannelMessages>()
                .BuildServiceProvider();

            await service.GetService<CommandHandler>().InstallCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, GetBotToken());
            await _client.StartAsync();


            await Task.Delay(-1);
        }

        public static string GetBotToken()
        {
            var tokenFilePath = Path.Combine(Directory.GetCurrentDirectory(), "bot_token/token.txt");
            using (StreamReader file = new StreamReader(tokenFilePath))
            {
                return file.ReadToEnd();
            }
        }
    }
}

