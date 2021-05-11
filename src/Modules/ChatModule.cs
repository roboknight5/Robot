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
        [Command("say")]
        [Summary("Echos a message")]
        public Task SayAsync([Remainder] [Summary("The text to echo")]
            string echo)
            => ReplyAsync(echo);

        [Command("say")]
        [Summary("Echos a message")]
        public Task SayAsync( int count,[Remainder] [Summary("The text to echo")] string echo)
        {
            for (int i = 0; i < count; i++)
            {
                ReplyAsync(echo);
                Task.Delay(700);
                

            }
            return Task.CompletedTask;
        }
        [Command("clear")]
        [Summary("Clears text from user")]
        public async Task ClearAsync(SocketUser user, int count )
        {
            var messages = await Context.Channel.GetMessagesAsync().FlattenAsync();
            IEnumerable<IMessage> userMessage;
            userMessage = messages.Where(x => x.Author == user).Take(count);
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

        [Command("role")]
        [Alias("roles","Role","Roles")]
        [Summary("Grants roles to users")]
        public async Task RoleAsync([Remainder]SocketGuildUser user=null)
        {
            var embed=new EmbedBuilder();
            embed.Title = "Roles";
            embed.WithCurrentTimestamp();
            IReadOnlyCollection<SocketRole> roles;

            if (user == null)
            {
                roles = Context.Guild.Roles;
            }
            else
            {
                roles = user.Roles;
                embed.WithAuthor(user);


            }

            foreach (var role in roles)
            {
                if (role.Name!="Robot" && !role.IsEveryone)
                {
                    embed.Description += role.Mention+Environment.NewLine;

                }

            }

            await ReplyAsync(embed: embed.Build());
        }

        [Command("role")]
        [Alias("roles","Role","Roles")]
        [Summary("Grants roles to users")]
        public async Task RoleAsync(string command,[Remainder] string roleName)
        {
            var user = Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToLower() == roleName.ToLower());
            var embed=new EmbedBuilder();
            switch (command.ToLower())
            {
                case "add":
                    await ( (IGuildUser) user).AddRoleAsync(role);
                    embed.AddField("Role Added", $"{role.Mention} Added to {user}");
                    break;
                case "remove":
                    await ((IGuildUser) user).RemoveRoleAsync(role);
                    embed.AddField("Role Removed", $"{role.Mention} Removed from {user}");
                    break;


            }

            await ReplyAsync(embed: embed.Build());


        }
        
        
    }
}