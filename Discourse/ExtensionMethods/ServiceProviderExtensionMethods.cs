using Discourse.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discourse.ExtensionMethods
{
    public static class ServiceProviderExtensionMethods
    {
        public static IOptions<BotOptions> GetBotOptions(
            this IServiceProvider s) =>
            s.GetRequiredService<IOptions<BotOptions>>();
    }
}
