using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aggravation
{
    public static class Astley
    {
        public static async Task Go(Config config)
        {
            foreach (var job in config.Jobs)
            {
                await RunJob(job);
            }
        }

        private static async Task RunJob(Job job)
        {
            await Task.Delay(TimeSpan.FromSeconds(job.TimeDelay));
            var parameters = string.Empty;
            if (job.Parameters != null && job.Parameters.Any())
            {
                parameters = string.Join(' ', job.Parameters);
            }
            Process.Start(job.ApplicationPath, parameters);
        }
    }
}