using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Robot.Modules
{
    public class AdMechModule :ModuleBase<SocketCommandContext>
    {
        [Command("admech")]
        [Summary("A collection of adeptus mechanicus commands")]
        public async Task AdMechAsync()
        {
            
        }
        
        [Command("admech")]
        [Summary("A collection of adeptus mechanicus commands")]
        public async Task AdMechAsync(string command)
        {
            switch (command.ToLower())
            {
                case "quest":
                    string mysteries = "- Life is directed motion" + Environment.NewLine 
                                       + "- The spirit is the spark of life" + Environment.NewLine
                                       + "- Sentience is the ability to learn the value of knowledge" + Environment.NewLine
                                       + "- Intellect is the understanding of knowledge"  + Environment.NewLine
                                       + "- Sentience is the basest form of Intellect" + Environment.NewLine
                                       + "- Understanding is the True Path to Comprehension" + Environment.NewLine
                                       + "- Comprehension is the key to all things" + Environment.NewLine
                                       + "- The Omnissiah knows all, comprehends all";
                    string warnings = "- The alien mechanism is a perversion of the True Path" + Environment.NewLine +
                                       "- The soul is the conscience of sentience" + Environment.NewLine
                                       + "- A soul can be bestowed only by the Omnissiah" + Environment.NewLine
                                       + "- The Soulless sentience is the enemy of all"  + Environment.NewLine
                                       + "- The knowledge of the ancients stands beyond question" + Environment.NewLine
                                       + "- The Machine Spirit guards the knowledge of the Ancients" + Environment.NewLine
                                       + "- Flesh is fallible, but ritual honours the Machine Spirit" + Environment.NewLine
                                       + "- To break with ritual is to break with faith";

                    var embed=new EmbedBuilder
                    {
                        Title = "Quest for knowledge"
                    };
                    embed.AddField("The Mysteries of the Cult Mechanicus", mysteries);
                    embed.AddField("The Warnings of the Cult Mechanicus", warnings).WithColor(Color.Gold);
                    await ReplyAsync(embed: embed.Build());
                    break;
                

                    
            }
            
        }
    }
}