using DSharpPlus;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Discourse.Services
{
    public class DiscourseHostedService : IHostedService
    {
        private DiscordClient _client;

        public DiscourseHostedService(
            DiscordClient discordClient
        )
        {
            this._client = discordClient;
            this._client.MessageCreated += this._client_MessageCreated;
        }

        private async Task _client_MessageCreated(
            DiscordClient sender,
            MessageCreateEventArgs e
        )
        {
            if (e.MentionedUsers.Any(m => m.Id == sender.CurrentUser.Id))
            {
                await e.Channel.SendMessageAsync("Yes sir?");
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await this._client.ConnectAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await this._client.DisconnectAsync();
        }
    }
}
