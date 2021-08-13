using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using Microsoft.Extensions.Logging;
using Discourse.Services;
using Discourse.Options;
using Discourse.ExtensionMethods;

namespace Discourse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(AddDSharpPlus)
                .ConfigureServices(AddDiscourse);

        public static void BindBotOptions(
            BotOptions botOptions,
            IConfiguration configuration
        )
        {
            configuration.Bind(BotOptions.Section, botOptions);
        }

        public static DiscordClient CreateDiscordClient(
            IServiceProvider s
        )
        {
            BotOptions opts = s.GetBotOptions().Value;
            return new DiscordClient(
                new DiscordConfiguration
                {
                    Token = opts.Token,
                    LoggerFactory = s.GetRequiredService<ILoggerFactory>()
                }
            );
        }

        public static void AddDSharpPlus(
            HostBuilderContext context,
            IServiceCollection services
        )
        {
            services.AddOptions<BotOptions>()
                    .Configure<IConfiguration>(BindBotOptions);

            services.AddSingleton(CreateDiscordClient);
        }

        public static void AddDiscourse(
            HostBuilderContext context,
            IServiceCollection services
        )
        {
            services.AddHostedService<DiscourseHostedService>();
        }
    }
}
