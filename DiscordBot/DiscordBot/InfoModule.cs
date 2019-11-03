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
        [Command("ping", RunMode = RunMode.Async)]
        [Summary("replaying to ping")]
        public async Task Pong()
            => await Context.Channel.SendMessageAsync("pong!");
        
        [Command("time", RunMode = RunMode.Async)]
        [Summary("return current time and date")]
        public async Task GetCurrentDate()
            => await Context.Channel.SendMessageAsync(DateTime.Now.ToString());
        [Command("frugo", RunMode = RunMode.Async)]
        [Summary("saying stuff using tts")]
        public async Task SayStuffAboutFrugo([Remainder]string text)
            => await Context.Channel.SendMessageAsync("/tts" + " " + text);
    }
}
