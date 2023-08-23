using Microsoft.Extensions.Configuration;
using System.IO;

namespace Calculator
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup()
        {
            Configuration = new ConfigurationBuilder()
             .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
             .Build();
        }
    }
}
