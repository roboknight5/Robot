using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.Commands;

namespace Robot.Modules
{
    public class AdMechModule :ModuleBase<SocketCommandContext>
    {
        [Command("encode")]
        [Summary("Converts text to binary")]
        [Alias("Encode")]
        public async Task EncryptAsync([Remainder] string text)
        {
            var result = string.Join(
                String.Empty, // running them all together makes it tricky.
                Encoding.UTF8
                    .GetBytes(text)
                    .Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0'))); // must ensure 8 digits.

            await ReplyAsync(result);
        }
        [Command("decode")]
        [Summary("Converts binary to text")]
        [Alias("Decode")]
        public async Task DecryptAsync([Remainder] string text)
        {
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