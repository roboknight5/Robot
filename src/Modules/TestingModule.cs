using System.Threading.Tasks;
using Discord.Commands;

namespace Robot.Modules
{
    public class TestingModule  :ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task TestAsync(params string [] args)
        {
            string text = "";
            foreach (var arg in args)
            {
                text += arg + " ";
            }

            await ReplyAsync(text);

        }
        
    }
}