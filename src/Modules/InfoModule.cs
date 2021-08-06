using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Discord;
using Discord.Commands;

namespace Robot.Modules
{
    public class InfoModule :ModuleBase<SocketCommandContext>
    {
        [Command("addemote")]
        public async Task addEmote()
        {
            Image image=new Image("/home/mohamed/Documents/Discord/die.gif");
            await Context.Guild.CreateEmoteAsync($"OhyeaItsAllComingTogether",image);
            
        }
        
        
    }
}