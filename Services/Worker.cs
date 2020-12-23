using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aggravation.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Aggravation.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Config _config;

        public Worker(ILogger<Worker> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
                foreach (var job in _config.Jobs)
                {
                    await RunJob(job);
                }
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