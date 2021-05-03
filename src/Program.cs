using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Robot
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commandService;

        static void Main(string[] args)
        {
            // var s=System.Net.WebUtility.UrlEncode("1     +2");
            // Console.WriteLine(s);
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            _client=new DiscordSocketClient();
            _commandService=new CommandService();
            Robot.CommandHandler commandHandler=new CommandHandler(_client,_commandService);
            await commandHandler.InstallCommandsAsync();
            
            
            _client.Log += Log;
            string sFile = "../../../../src/token.txt";


            var token = File.ReadAllText(Path.GetFullPath(sFile));

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);


        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }

        private Task CommandHandler(SocketMessage message)
        {
            string command = "";
            if (!message.Content.StartsWith("!"))
                return Task.CompletedTask;
            if (message.Author.IsBot)
                return Task.CompletedTask;
            command = message.Content.Substring(1, message.Content.Length - 1);


            //Commands begin here
            if (command.Equals("hello"))
                message.Channel.SendMessageAsync($"Hello {message.Author.Mention}");
            else if (command.Equals("age"))
            {
                message.Channel.SendMessageAsync(
                    $"Your account was create at {message.Author.CreatedAt.DateTime.Date}");
            }

            return Task.CompletedTask;
        }
        
        
    }
}