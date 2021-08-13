using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Discourse.Options
{
    public class BotOptions
    {
        public static string Section = "BotOptions";
        public string Token { get; set; } = default!;
    }
}
