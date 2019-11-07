using System;
using System.Collections.Generic;
using System.Text;
using Discord.WebSocket;
using System.Threading.Tasks;
using Discord;
namespace DiscordBot
{
    public class ChannelMessages
    {
        public async Task<bool> DeleteMesseges(byte quantity,ISocketMessageChannel channel )
        {
            byte min = 1, max = 20+1;
            if (Validator.IsInRange(quantity, min, max) == false)
            {        
                await channel.SendMessageAsync($"Wrong quantity number, range {min}-{max-1}");
                return false;
            }
            ++quantity;//command msg
            var messages = await channel.GetMessagesAsync(limit:quantity).FlattenAsync();//limit numbers of message 
            foreach (var msg in messages)
            {
                await msg.DeleteAsync();
            }
            return true;
        }
    }
}
