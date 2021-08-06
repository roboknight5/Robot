using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Robot.Modules
{
    public class TimeModule : ModuleBase<SocketCommandContext>
    {
        [Command("timer")]
        [Summary("run a timer")]
        public async  void TimerAsync(params int[] input)
        {
            Task.Run(async () => {
            int hours = 0, min = 0, seconds = 0;
            if (input.Length == 3)
            {
                if (input[0]<0||input[1]<0||input[2]<0)
                    return;
                hours = input[0];
                min = input[1];
                seconds = input[2];
            }
            else if (input.Length == 2)
            {
                if (input[0]<0||input[1]<0)
                    return;
                min = input[0];
                seconds = input[1];
            }
            else if (input.Length == 1)
            {
                if (input[0]<0)
                    return;
                seconds = input[0];
            }

            var embed = new EmbedBuilder();
     
            embed.AddField("Timer", ($"Hours:{hours} Minute:{min} Seconds:{seconds}"))
                .WithCurrentTimestamp()
                .WithAuthor(Context.User);
            var message = await Context.Channel.SendMessageAsync(embed:embed.Build());

            // var message = await Context.Channel.SendMessageAsync(($"Hours:{hours} Minute:{min} Seconds:{seconds}"));

            while (true)
            {
                if (seconds==0)
                {
                    min -= 1;
                    seconds = 59;
                }


                else if (min == 0 && hours != 0)
                {
                    hours -= 1;
                    min = 59;
                }

                if (hours<0 ||min<0|| seconds<0)
                {
                    hours = min = seconds = 0;
                    // await message.ModifyAsync(msg=>msg.Content= $"Hours:{hours} Minute:{min} Seconds:{seconds}");
                    await message.ModifyAsync(msg=>
                    {
                        var embed = new EmbedBuilder();
     
                        embed.AddField("Timer", ($"Hours:{hours} Minute:{min} Seconds:{seconds}"))
                            .WithCurrentTimestamp()
                            .WithAuthor(Context.User);
                        msg.Embed =embed.Build() ;
                    });
                    await Task.Delay(1000);
                    await message.ModifyAsync(msg=>
                    {
                        var embed = new EmbedBuilder();
     
                        embed.AddField("Time Up!", ($"{Context.User.Mention}"))
                            .WithCurrentTimestamp()
                            .WithAuthor(Context.User);
                        msg.Embed =embed.Build() ;
                    });
                    // await Context.Channel.SendMessageAsync($"Time Up!! {Context.User.Mention}");
                    // await message.DeleteAsync();
                    break;
                }

                // await message.ModifyAsync(msg=>msg.Content= $"Hours:{hours} Minute:{min} Seconds:{seconds}");
                await message.ModifyAsync(msg=>
                {
                    var embed = new EmbedBuilder();
     
                    embed.AddField("Timer", ($"Hours:{hours} Minute:{min} Seconds:{seconds}"))
                        .WithCurrentTimestamp()
                        .WithAuthor(Context.User);
                    msg.Embed =embed.Build() ;
                });
                await Task.Delay(1000);
                seconds--;


            }
            
            
            
            });


        }

    
        
    }
}