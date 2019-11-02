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
        [Command("ping",RunMode=RunMode.Async)]
        [Summary("replaying to ping")]
        public async Task Pong()
        {
            await Context.Channel.SendMessageAsync("pong");
        }
    }
}
