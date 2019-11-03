using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        public FileService Video { get; set; }

        [Command("ping", RunMode = RunMode.Async)]
        [Summary("replaying to ping")]
        public async Task Pong()
            => await Context.Channel.SendMessageAsync("pong!");
        
        [Command("time", RunMode = RunMode.Async)]
        [Summary("returns current time and date")]
        public async Task GetCurrentDate()
            => await Context.Channel.SendMessageAsync(DateTime.Now.ToString());
        [Command("frugo", RunMode = RunMode.Async)]
        [Summary("saying stuff using tts")]
        public async Task SayStuffAboutFrugo([Remainder]string text)
            => await Context.Channel.SendMessageAsync( text, isTTS: true);
        [Command("ylyl", RunMode=RunMode.Async)]
        [Summary("adding video file to channel")]
        [RequireContext(ContextType.Guild)]
        public async Task AddVideoFileToChannel()
        {
            var path = await Video.GetVideoFilePath();
            if (path == null)
                await Context.Channel.SendMessageAsync("Ups error 😢");
            else
                await Context.Channel.SendFileAsync(path);
        }
        
    }
}
