using Discord;
using Discord.WebSocket;
using System.Diagnostics;
using System.Security.Cryptography;

namespace FarinResponceTool.Extensions
{
    internal static class DiscordExtension
    {
        public static async Task PushRequest(this string responce, string triggers, string id)
        {
            EmbedBuilder embed = new() {
                Title = "A request from master Benji~",
                Description = responce,
                Footer = new() { Text = $"{(id.StartsWith("Farin") ? "Farin" : "Any").PadRight(10, '\u2002')}{id}{$"{Environment.UserName}".Md5Hash()}" },
                Author = new() {
                    Name = "Benji",
                    IconUrl = "https://cdn.discordapp.com/attachments/1003400196920709130/1003401311473111191/Benji_Cut.png"
                },
                Color = Discord.Color.DarkRed
            };

            embed.AddField("Triggers:", string.Join(", ", triggers.Split("\r\n")));

            IMessageChannel channel = (IMessageChannel)Client.GetChannel(1003462959286210612);
            IUserMessage msg = await channel.SendMessageAsync(embed: embed.Build());
            await msg.AddReactionAsync(new Emoji("✅"));
            await msg.AddReactionAsync(new Emoji("❎"));
        }

        public static async Task ReportToDiscord(this Exception ex, ulong channelId = 1003462959286210612)
        {
            IMessageChannel channel = (IMessageChannel)Client.GetChannel(channelId);
            await channel.SendMessageAsync(embeds:ex.GetDiscordEmbed());
        }

        public static Embed[] GetDiscordEmbed(this Exception ex)
        {
            // Create embed collection
            List<Embed> embeds = new();

            // Build root embed
            EmbedBuilder embed = new() {
                Title = ex.GetType().ToString(),
                Description = ex.Message,
                Footer = new() { Text = $"{ex.Source}.{ex.TargetSite}" },
                Timestamp = DateTime.Now,
                Color = Discord.Color.Blue
            };

            // Evaluate stack trace
            string stack = ex.StackTrace ?? "No stack trace.";
            if (stack.Length <= 200) {
                embed.AddField("Stack Trace", stack);
            }
            else {
                embed.AddField("Stack Trace", "- - - - - - - - -");

                foreach (var trace in stack.Split("   at ")) {
                    if (trace.Trim().Length > 1 && embed.Fields.Count < 15) {
                        embed.AddField("at", trace.Trim());
                    }
                    else if (embed.Fields.Count > 15) {
                        embed.Fields.Clear();
                        break;
                    }
                }

                if (embed.Fields.Count == 0) {
                    embeds.Add(embed.Build());

                    foreach (var trace in stack.Split("   at ")) {
                        if (trace.Trim().Length > 1 && embed.Fields.Count < 15) {
                            EmbedBuilder subEmbed = new();
                            subEmbed.AddField("at", trace);
                            embeds.Add(subEmbed.Build());
                        }
                    }
                }
            }

            // Build embed
            embeds.Add(embed.Build());

            // Add inner exception
            if (ex.InnerException != null) {
                embeds.AddRange(ex.InnerException.GetDiscordEmbed());
            }

            // Return embeds
            return embeds.ToArray();
        }

        //
        // Discord connection logic
        #region Expand

        public static DiscordSocketClient Client { get; } = new(new DiscordSocketConfig() { GatewayIntents = GatewayIntents.All });
        public static bool WorkerStatus { get; set; } = true;

        public static async Task Connect(Func<Task> onReady)
        {
            // Start worker
            WorkerStatus = true;

            // Connect the client
            await Client.LoginAsync(TokenType.Bot, User.Key);
            await Client.StartAsync();
            Client.Ready += onReady;
            Client.Log += ReportLog;
        }

        public static Task ReportLog(LogMessage ex)
        {
            Debug.WriteLine(ex.ToString());
            return Task.CompletedTask;
        }

        #endregion
    }
}
