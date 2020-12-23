using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RickRoll
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var path = $"{ Directory.GetCurrentDirectory() }\\appConfig.json";
            var configText = File.ReadAllText(path);
            var config = JsonConvert.DeserializeObject<Config>(configText);
            await Astley.Go(config);
        }
    }
}