using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class DiscordBot
    {
        DiscordClient client;
        CommandService commands;

        public DiscordBot()
        {
            commands = client.GetService<CommandService>();
            client = new DiscordClient(input =>
            {
                input.LogLevel = LogSeverity.Info;
                input.LogHandler = Log;
            });

            client.UsingCommands(input =>
            {
                input.PrefixChar("/");
                input.AllowMentionPrefix(true);
            }
            );

            commands.CreateCommand("teste").Do(async (e) =>          
            {
                await e.Channel.SendTTSMessage("Testando o bot putos");
            });

            client.ExecuteAndWait(async() =>
            {
                await client.Connect("MzA5MTU0MTYxMzA2NTAxMTIw.C-rRyA.j7qCtBcLeaO6QHj7YIlPU2nqIy8", TokenType.Bot);
            }
            );
        }

        private void Log(object sender, LogMessageEventArgs e) {
            Console.WriteLine(e.Message);

        }
    }
}
