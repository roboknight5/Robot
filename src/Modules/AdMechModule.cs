using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Robot.AdMech;

namespace Robot.Modules
{
    [NamedArgumentType]
    public class AdMechCommandParams
    {
        public string Attribute { get; set; }
        public int Number { get; set; } = 0;
        public int Amount { get; set; } = 0;
        public bool Random { get; set; } =true;
        


    }
    public class AdMechModule :ModuleBase<SocketCommandContext>
    {
        [Command("admech")]
        [Summary("A collection of adeptus mechanicus commands")]
        public async Task AdMechAsync()
        {
            
        }
        
        [Command("admech")]
        [Summary("A collection of adeptus mechanicus commands")]
        public async Task AdMechAsync(string command ,AdMechCommandParams arguments=null)
        {
            var embed = new EmbedBuilder();
            
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


                    embed.Title = "Quest for knowledge";
                    embed.AddField("The Mysteries of the Cult Mechanicus", mysteries);
                    embed.AddField("The Warnings of the Cult Mechanicus", warnings).WithColor(Color.Gold);
                    await ReplyAsync(embed: embed.Build());
                    break;
                case "quote":
                    Quotes quotes=new Quotes();
                    var quotesList = quotes.QuoteList;
                    if (arguments != null)
                    {
              
                        
                        if (arguments.Attribute != null)
                        {
                            quotesList = quotesList.Where(x => x.Attribute.ToLower() == arguments.Attribute.ToLower())
                                .Select(x => x).ToList();
                            if (quotesList.Count == 0)
                            {
                                embed.AddField("Error Invalid Attribute", $"No quotes with specified attribute {arguments.Attribute}")
                                    .WithColor(Color.Red);
                                await ReplyAsync(embed: embed.Build());
                                return;
                            }
                        }
                        
                        if (arguments.Random)
                        {
                            Random rand=new Random();
                            int num = rand.Next(0, quotesList.Count);
                            quotesList = new List<Quote>() {quotesList[num]};
                            arguments.Number = 0;
                            arguments.Amount = 0;
                        }
                        else if(arguments.Number==0&&arguments.Amount==0&&arguments.Attribute==null)
                        {
                            return;
                        }
   
                        


                        if (arguments.Amount > 0)
                        {
                            quotesList = quotesList.Take(arguments.Amount).Select(x => x).ToList();
                        }

                        if (arguments.Number > 0)
                        {
                            if (arguments.Number > quotesList.Count)
                            {
                                string attribute = "";
                                if (arguments.Attribute != null)
                                    attribute = " and attribute "+$"\'{arguments.Attribute}\'";
                                    
                                embed.AddField("Error quote not found",$"Quote with number {arguments.Number}{attribute} not found").WithColor(Color.Red);
                                await ReplyAsync(embed: embed.Build());
                                return;
                            }
                            quotesList = new List<Quote>() {quotesList[arguments.Number - 1]};
                        }

                        
                        


                        int length = 0;
                        foreach (var quote in quotesList)
                        {
                           
                                int times = quote.Text.Length / 1024;
                                times++;
                                int chunkSize = quote.Text.Length/times;
                                int stringLength = quote.Text.Length;
                                Console.WriteLine(times);
                                for (int i = 0; i < stringLength ; i += chunkSize)
                                {
                                    if (i + chunkSize > stringLength) chunkSize = stringLength  - i;
                                    embed.AddField(quote.Speaker, quote.Text.Substring(i,chunkSize) + Environment.NewLine)
                                        .WithFooter(quote.Source).WithColor(Color.Gold);
                                    await ReplyAsync(embed: embed.Build());
                                    embed = new EmbedBuilder();

                                }
                                
                                    
                                


                        }

                        // await ReplyAsync(embed: embed.Build());
                    }
                    else
                    {
                        embed.AddField("Quote", "Number:\'enter quote number\'"+Environment.NewLine+
                                                "Amount:\'enter the amount of quotes allowed\'"+Environment.NewLine+
                                                "Attribute:\'Enter Attribute A-Z\'"+Environment.NewLine
                                                ).WithFooter($"{quotesList.Count} quotes")
                                                .WithColor(Color.Green);
                        await ReplyAsync(embed: embed.Build());

                    }

                    break;
                    
                

                    
            }
            
        }
    }
}