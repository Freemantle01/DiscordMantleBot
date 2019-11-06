using System;
using Discord.Net;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using System.IO;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;

//https://discord.foxbot.me
namespace DiscordBot
{
    public class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider service;
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

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

