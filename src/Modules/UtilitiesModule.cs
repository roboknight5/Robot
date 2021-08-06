using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.Commands;
using System.Drawing;
using System.IO;
using System.Net.Http;
using Discord;
using FFMpegCore;
using FFMpegCore.Pipes;
using ImageMagick;
using Python.Runtime;
using Color = System.Drawing.Color;
using Image = Discord.Image;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace Robot.Modules
{

    [NamedArgumentType]
    public class LogoNamedArgs
    {
        public string Text { get; set; } = "";
        public string Foreground { get; set; } = "";
        public string Background { get; set; } = "";

    }
    public class UtilitiesModule :ModuleBase<SocketCommandContext>
    {
        HttpClient client = new HttpClient();

        [Command("googleforyou")]
        [Summary("Generates a let me google that for you link")]
        public async Task GoogleForYou( [Remainder] string question)
        {
            var encodedQuestion = Uri.EscapeDataString(question);
            var encodedUrl = "https://letmegooglethat.com/?q=" + encodedQuestion;
            await ReplyAsync($"Here let me google it for your {encodedUrl}");
        }
        
        
        [Command("invert")]
        [Summary("Invert Image")]
        public async Task Invert(string url) 
        {
            await using var stream =await  client.GetStreamAsync(url);
            MagickImage image=new MagickImage(stream);
            image.Negate(Channels.RGB);
            var ms=new MemoryStream(image.ToByteArray());
            await Context.Channel.SendFileAsync(ms,"image.png");
        }
                
        [Command("deepfry")]
        [Summary("Deepfry Image")]
        public async Task Deepfry(string url) 
        {
            await using var stream =await  client.GetStreamAsync(url);
            MagickImage image=new MagickImage(stream);
            using (Py.GIL())
            {
                
                // PythonEngine.Exec();
                
            }
            
            
            
            
            
            var ms=new MemoryStream(image.ToByteArray());
            await Context.Channel.SendFileAsync(ms,"image.png");
        }
        
        
       
        [Command("imageinfo")]
        [Summary("Prints the info of an image")]
        public async Task ImageInfo(string url) 
        {
            await using var stream =await  client.GetStreamAsync(url);
            MagickImage image=new MagickImage(stream);
            // await ReplyAsync(image.Width.ToString());
            // await ReplyAsync(image.Height.ToString());
            // await ReplyAsync(image.Gamma.ToString());
            // await ReplyAsync(image.IsOpaque.ToString());
            // await ReplyAsync(image.Orientation.ToString());
            // await ReplyAsync(image.Format.ToString());
            var bytes = image.ToByteArray();
            await ReplyAsync(Util.FormatSize(new MemoryStream(bytes).Length));


            
        }
        [Command("convert")]
        [Summary("convert mp4 to gif")]
        public async Task convert(string url,int width=100,int height=100) 
        {
            Stream outputstream=new MemoryStream();
            using var stream =await  client.GetStreamAsync(url);
            var message = await Context.Channel.SendMessageAsync("Resizing Image");
            await FFMpegArguments.FromUrlInput(new Uri(url)). OutputToFile("/home/mohamed/file.gif",true,options =>options.ForceFormat("gif").Resize(width,width))
                .ProcessAsynchronously();
            var file = Context.Channel.SendFileAsync("/home/mohamed/file.gif").Result;
            await ReplyAsync(file.Attachments.ElementAt(0).Size.ToString());
            
            var attachment = file.Attachments.ElementAt(0);
            if (attachment != null)
            {
                await ImageInfo(attachment.Url);
            }

            await Context.Channel.DeleteMessageAsync(message);


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

        [Command("logo")]
        [Summary("generate a logo")]
        [Alias("Logo")]
        public async Task GenerateLogoAsync(LogoNamedArgs args=null)
        {
            if (args==null)
            {
                return;
                
            }
            string color = args.Background;
            string textColor = args.Foreground;
            string text = args.Text;
            
            // int largestDimension = Math.Max(500, 500);
            // Size squareSize = new Size(largestDimension, largestDimension);
            // using (var image = new MagickImage(new MagickColor(color.ToLower()),squareSize.Width,squareSize.Height))
            // {
            //     MagickReadSettings settings = new MagickReadSettings()
            //     {
            //         
            //         BackgroundColor = MagickColors.LightBlue, // -background lightblue
            //         FillColor = MagickColors.Black, // -fill black
            //         TextGravity = Gravity.Center,
            //         Width = 500, // -size 530x
            //         Height = 500 // -size x175
            //     };
            //     
            //     image.Read("caption:This is a testsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss.", settings); // caption:"This is a test."
            //     image.Write("logo.png");
            //    
            // }
            //
            Brush brush=new SolidBrush(Color.FromName(color));
            if (string.IsNullOrEmpty(textColor))
            {
                textColor = "white";
            
            }
            Brush textBrush=new SolidBrush(Color.FromName(textColor));
            
            
            int largestDimension = Math.Max(500, 500);
            Size squareSize = new Size(largestDimension, largestDimension);
            Bitmap squareImage = new Bitmap(squareSize.Width, squareSize.Height);
            using (Graphics graphics = Graphics.FromImage(squareImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                Font font = new Font("Arial", 128f);
                font = FindBestFitFont(graphics, text, font, squareSize);
                
                SizeF sizeF=graphics.MeasureString(text,font);
                // graphics.DrawString("My String",  new Font("Arial", 12), Brushes.Black, new PointF(squareImage.Width/2,squareImage.Height/2));
            
                Rectangle rect = new Rectangle(new Point(0, 0),new Size( squareSize.Width,squareSize.Height ));
                graphics.FillRectangle(brush, rect);
                graphics.DrawString(text, font, textBrush, ( squareSize.Width-sizeF.Width)/2, ( squareSize.Height-sizeF.Height)/2);
                squareImage.Save("./logo.png",ImageFormat.Png);
            }
            //

            
            var fileName = "logo.png";
            var embed = new EmbedBuilder()
            {
                ImageUrl = $"attachment://{fileName}"
            }.Build();
            await Context.Channel.SendFileAsync(fileName, embed: embed);
            await Context.Guild.ModifyAsync(g => g.Icon =new Optional<Image?>(new Image("logo.png")));


        }
        private Font FindBestFitFont(Graphics g, String text, Font font, Size proposedSize)
        {
            // Compute actual size, shrink if needed
            while (true)
            {
                SizeF size = g.MeasureString(text, font);

                // It fits, back out
                if (size.Height <= proposedSize.Height &&
                    size.Width <= proposedSize.Width) { return font; }

                // Try a smaller font (90% of old size)
                Font oldFont = font;
                font = new Font(font.Name, (float)(font.Size * .9), font.Style);
                oldFont.Dispose();
            }
        }
        
    }

   
}