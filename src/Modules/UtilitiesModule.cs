using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.Commands;

namespace Robot.Modules
{
    public class UtilitiesModule :ModuleBase<SocketCommandContext>
    {
        [Command("googleforyou")]
        [Summary("Generates a let me google that for you link")]
        public async Task GoogleForYou( [Remainder] string question)
        {
            var encodedQuestion = Uri.EscapeDataString(question);
            var encodedUrl = "https://letmegooglethat.com/?q=" + encodedQuestion;
            await ReplyAsync($"Here let me google it for your {encodedUrl}");
        }
        
        [Command("encode")]
        [Summary("Converts text to binary")]
        [Alias("Encode")]
        public async Task EncodeAsync([Remainder] string text)
        {
        
            var result = string.Join(
                string.Empty, // running them all together makes it tricky.
                Encoding.UTF8
                    .GetBytes(text)
                    .Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0'))); // must ensure 8 digits.
            
            result = Regex.Replace(result,".{8}","$0 ");
            
            await ReplyAsync(result);
        }
        [Command("decode")]
        [Summary("Converts binary to text")]
        [Alias("Decode")]
        public async Task DecodeAsync([Remainder] string text)
        {
            text=Regex.Replace(text, @"\s+", "");
            var result=Encoding.UTF8.GetString(
                Regex.Split(
                        text
                        , "(.{8})") // this is the consequence of running them all together.
                    .Where(binary => !String.IsNullOrEmpty(binary)) // keeps the matches; drops empty parts 
                    .Select(binary => Convert.ToByte(binary, 2))
                    .ToArray());
            await ReplyAsync(result);
        }

    }
}