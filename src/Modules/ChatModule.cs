using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.VisualBasic;

namespace Robot.Modules
{
    public class ChatModule : ModuleBase<SocketCommandContext>
    {
        [Command("clear")]
        [Summary("Clears text from user")]
        public async Task ClearAsync(SocketUser user, int count )
        {
            var messages = await Context.Channel.GetMessagesAsync(count+1).FlattenAsync();
            Console.WriteLine(user.Username);
            IEnumerable<IMessage> userMessage;
            userMessage = messages.Where(x => x.Author == user);
            await ((ITextChannel) Context.Channel).DeleteMessagesAsync(userMessage);
        }

        [Command("clear")]
        [Summary("Clears text from user")]
        public async Task ClearAsync(SocketUser user)
        {
            var messages = await Context.Channel.GetMessagesAsync().FlattenAsync();
            Console.WriteLine(user.Username);
            IEnumerable<IMessage> userMessage;
            userMessage = messages.Where(x => x.Author == user);
            await ((ITextChannel) Context.Channel).DeleteMessagesAsync(userMessage);
            

        }
        [Command("clear")]
        [Summary("Clears text from user")]
        public async Task ClearAsync()
        {
            var messages = await Context.Channel.GetMessagesAsync().FlattenAsync();
            await ((ITextChannel) Context.Channel).DeleteMessagesAsync(messages);
            
        }
        [Command("clear")]
        [Summary("Clears text from user")]
        public async Task ClearAsync(int count)
        {
            var messages = await Context.Channel.GetMessagesAsync(count+1).FlattenAsync();
            await ((ITextChannel) Context.Channel).DeleteMessagesAsync(messages);
        }


        // else
            // {
            //     Console.WriteLine("here");
            //     int temp = 0;
            //     foreach (var h in messages.ToArray())
            //     {
            //         if (temp == count)
            //             break;
            //
            //         await Context.Channel.DeleteMessageAsync(h);
            //         await Task.Delay(700);
            //         temp++;
            //
            //     }
            // }
        
    }
}