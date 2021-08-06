using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using ImageMagick;
using static Robot.Modules.Sanatize;

namespace Robot.Modules
{
    
    
    public  class EmoteModule :ModuleBase<SocketCommandContext>
    {
        private int emojiCounter = 0;
        ReaderWriterLock locker = new ReaderWriterLock();

        [Command("emoteupdate"), Alias("eu")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.ManageEmojis)]
        [RequireBotPermission(GuildPermission.ManageEmojis)]
        public async Task FetchAllAsync()
        {
            var emotes = await Context.Guild.GetEmotesAsync();
            var normalEmotes = 0;
            var animatedEmotes = 0;

            foreach (var emote in emotes)
            {
                if (emote.Animated)
                {
                    animatedEmotes++;
                }
                else
                {
                    normalEmotes++;
                }
            }
            
            await Context.Channel.SendMessageAsync($"This server currently has **{normalEmotes}** normal emotes, and **{animatedEmotes}** animated emotes");
        }

        [Command("delmote")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.ManageEmojis)]
        [RequireBotPermission(GuildPermission.ManageEmojis)]
        public async Task DeleteEmoteAsync(string emoteName)
        {
            var id = emoteName.SanitizeEmote();
            var emote = await Context.Guild.GetEmoteAsync(id);
            await Context.Guild.DeleteEmoteAsync(emote);
            await Context.Channel.SendMessageAsync($"Deleted **{emote.Name}**");
        }
        
        [Command("rename")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.ManageEmojis)]
        [RequireBotPermission(GuildPermission.ManageEmojis)]
        public async Task RenameEmoteAsync(string oldName, string newName)
        {
            await EnsureLengthAsync(newName);

            var id = oldName.SanitizeEmote();
            var emote = await Context.Guild.GetEmoteAsync(id);
            await Context.Guild.ModifyEmoteAsync(emote, properties => properties.Name = newName);
            await Context.Channel.SendMessageAsync($"**{emote.Name}** -> **{newName}**");
        }
        
        // Add gif 
        // add png as "gif"
        // add png as png (normal gif)
        [Command("addmote")]
        [Summary("Add an emote to the server via url")]
        [Remarks("addmote <flag> <url> <name>")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.ManageEmojis)]
        [RequireBotPermission(GuildPermission.ManageEmojis)]
        public async Task AddEmoteAsync([Summary("**-n** (normal)\n**-a** (animated)\n**-h** (hack)")] string flag, 
                                        [Summary("Image/Gif url to upload as an emote")] string url, 
                                        [Summary("The name of the emote to upload")] string name)
        {
            await EnsureLengthAsync(name);
            // -addmote -n <url> <name>
            // -addmote -a <url> <name>
            // -addmote -an <url> <name>
            
            switch (flag)
            {
                // Normal PNG
                case "-n":
                {
                    var image = await DownloadImageAsync(url);
                    await ResizeImageAsync(image);
                    await Context.Guild.CreateEmoteAsync(name, new Image(image));
                    File.Delete(image);
                    await Context.Channel.SendMessageAsync($"Successfully added :{name}:");
                    break;
                }
                // Animated gif
                case "-a":
                {
                    DownloadGifAsync(url,name);
                    // ResizeGifAsync(gif);
                    // await Context.Guild.CreateEmoteAsync(name, new Image(gif));
                    // File.Delete(gif);
                    // await Context.Channel.SendMessageAsync($"Successfully added :{name}:");
                    break;
                }
                // Special case to upload a png as a "gif" 
                case "-h":
                {
                    var image = await DownloadImageAsync(url);
                    await ResizeImageAsync(image);
                    var emotePath = await CreateAnimatedAsync(image, name);
                    await Context.Guild.CreateEmoteAsync(name, new Image(emotePath));
                    File.Delete(image);
                    await Context.Channel.SendMessageAsync($"Successfully added :{name}:");
                    break;
                }
            }
        }
        
        internal static async Task<string> DownloadImageAsync(string url)
        {
            await Task.Run(() =>
            {
                if (File.Exists("emote.png"))
                {
                    File.Delete("emote.png");
                }
            
                using var client = new WebClient();
                client.DownloadFile(new Uri(url), "emote.png");

                var imagePath = "emote.png";
                using var image = new MagickImage(imagePath);
                var size = new MagickGeometry
                {
                    Width = 100,
                    Height = 100,
                    IgnoreAspectRatio = true,
                };
            
                image.Resize(size);
                image.Write(imagePath);
            });
            
            return "emote.png";
        }

        internal void  DownloadGifAsync(string url, string name)
        {

            Console.WriteLine("In Gif Async");

            Task.Run(async () =>
            {

                if (File.Exists($"emote.gif"))
                {
                    File.Delete($"emote.gif");
                    
                }

                var request = (HttpWebRequest) WebRequest.Create(url);
            var response = (HttpWebResponse) request.GetResponse();

            using var stream = response.GetResponseStream();
            using var fs = File.Create($"emote.gif");
            stream.CopyTo(fs);
            var imagePath = $"emote.gif";

            using var collection = new MagickImageCollection(imagePath);
            

            foreach (var image in collection)
            {
                // image.Resize(50, 0);
            }

            collection.Write(imagePath);


            Console.WriteLine("here");

            Console.WriteLine(Directory.GetCurrentDirectory());

            }).ContinueWith(async (result)=>{
            await Context.Guild.CreateEmoteAsync(name, new Image($"emote.gif"));
            Console.WriteLine("passed here");
            
            await ReplyAsync("i am done ");
            Console.WriteLine("Done Babe;");
            });
    }





        internal static async Task ResizeImageAsync(string imagePath)
        {
            // await Task.Run( () =>
            // {
            //     
            //     
            //     using var image = new MagickImage(imagePath);
            //     var size = new MagickGeometry
            //     {
            //         Width = 100,
            //         Height = 100,
            //         IgnoreAspectRatio = true,
            //     };
            //
            //     image.Resize(size);
            //     image.Write(imagePath);
            // });
            
        }

        internal static void ResizeGifAsync(string gifPath)
        {
            Task.Run(() =>
            {
                using var collection = new MagickImageCollection(gifPath);


                foreach (var image in collection)
                {
                    image.Resize(100, 0);
                }

                collection.Write(gifPath);
            });
        }

       
        

        internal static async Task<string> CreateAnimatedAsync(string image, string emoteName)
        {
            await Task.Run(() =>
            {
                using var collection = new MagickImageCollection();

                collection.Add(image);
                collection[0].AnimationDelay = 100;

                collection.Add(image);
                collection[1].AnimationDelay = 100;

                var settings = new QuantizeSettings
                {
                    Colors = 256
                };

                collection.Quantize(settings);
                collection.Optimize();

                collection.Write($"emote.gif");
            });
            return $"emote.gif";
        }

        private async Task EnsureLengthAsync(string emoteName)
        {
            if (emoteName.Length>=32)
            {
                throw new Exception($"Expected less than or equal to 32 characters ,got{emoteName.Length} for {emoteName}");
                
            }
        }


    }
}