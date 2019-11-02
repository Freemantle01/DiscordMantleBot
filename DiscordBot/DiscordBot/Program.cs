using System;
using Discord.Net;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using System.IO;

namespace DiscordBot
{
    public class Program
    {
        private static readonly string tokenFilePath = @"D:\git rep\DiscordMantleBot\DiscordBot\DiscordBot\bot_token\token.txt";
        private DiscordSocketClient _client;
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

            _client.Log += Log;

            // Remember to keep token private or to read it from an 
            // external source! In this case, we are reading the token 
            // from an environment variable. If you do not know how to set-up
            // environment variables, you may find more information on the 
            // Internet or by using other methods such as reading from 
            // a configuration.
            await _client.LoginAsync(TokenType.Bot, GetBotToken());
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        public static string GetBotToken()
        {
            using (StreamReader file = new StreamReader(tokenFilePath))
            {
                return file.ReadToEnd();
            }
        }
    }
}

