using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Discord.Commands;

namespace Robot.Modules
{
    public class InfoModule :ModuleBase<SocketCommandContext>
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

        [Command("googleforyou")]
        [Summary("Generates a let me google that for you link")]
        public async Task GoogleForYou( [Remainder] string question)
        {
            var encodedQuestion = Uri.EscapeDataString(question);
            var encodedUrl = "https://letmegooglethat.com/?q=" + encodedQuestion;
            await ReplyAsync($"Here let me google it for your {encodedUrl}");
        }

    }
}