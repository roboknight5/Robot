using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Robot.Modules
{
    public class ChatModule : ModuleBase<SocketCommandContext>
    {
        [Command("clear")]
        [Summary("Clears text from user")]
        public async Task ClearAsync(SocketUser user = null, int count = 100)
        {
            var messages = await Context.Channel.GetMessagesAsync().FlattenAsync();
            if (user != null)
            {
                Console.WriteLine(user.Username);


                IEnumerable<IMessage> userMessage;
                userMessage = messages.Where(x => x.Author == user);
                int temp = 0;
                foreach (var h in userMessage.ToArray())
                {
                    if (temp == count)
                        break;

                    await Context.Channel.DeleteMessageAsync(h);
                    await Task.Delay(700);
                    temp++;

                }
            }
            else
            {
                Console.WriteLine("here");
                int temp = 0;
                foreach (var h in messages.ToArray())
                {
                    if (temp == count)
                        break;

                    await Context.Channel.DeleteMessageAsync(h);
                    await Task.Delay(700);
                    temp++;

                }
            }
        }
    }
}