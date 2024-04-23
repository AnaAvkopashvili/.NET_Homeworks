using Forum.Application.Services;
using Forum.Application.Topics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Forum.Web.BackgroundServices
{
    public class TopicArchivalBackgroundService : BackgroundService
    {
        private readonly ILogger<TopicArchivalBackgroundService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public TopicArchivalBackgroundService(ILogger<TopicArchivalBackgroundService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("TopicArchivalBackgroundService is running.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateAsyncScope();
                var topicService = scope.ServiceProvider.GetRequiredService<ITopicService>();
                await topicService.ArchiveInactiveTopicsAsync(stoppingToken);

                _logger.LogInformation("TopicArchivalBackgroundService ran at: {time}", DateTime.Now);

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}




/*using Forum.Application.Topics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;

namespace Forum.Web.BackgroundServices
{
    public class TopicArchivalBackgroundService : BackgroundService
    {
        private readonly ILogger<TopicArchivalBackgroundService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private DateTime _nextRun;
        private CrontabSchedule _schedule;

        private string Schedule => "* * * * *"; // Every day
        public TopicArchivalBackgroundService(ILogger<TopicArchivalBackgroundService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = false });
            _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("TopicArchivalBackgroundService is running.");
            do
            {
                var now = DateTime.UtcNow;
               var nextRun = _schedule.GetNextOccurrence(now);

                if (now > _nextRun)
                {
                    using var scope = _serviceProvider.CreateAsyncScope();
                    var topicService = scope.ServiceProvider.GetRequiredService<ITopicService>();
                    await topicService.ArchiveInactiveTopicsAsync(stoppingToken);

                    _logger.LogInformation("TopicArchivalBackgroundService ran at: {time}", DateTime.Now);
                    _nextRun = nextRun;
                }
            }
            while (!stoppingToken.IsCancellationRequested);
        }
    }
}*/










/*using Forum.Application.Topics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;

public class TopicArchivalBackgroundService : BackgroundService
{
    private readonly ILogger<TopicArchivalBackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly CrontabSchedule _schedule;
    private readonly string _cronExpression = "0 0 * * *"; // Run every day at midnight

    public TopicArchivalBackgroundService(ILogger<TopicArchivalBackgroundService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _schedule = CrontabSchedule.Parse(_cronExpression, new CrontabSchedule.ParseOptions { IncludingSeconds = false });
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("TopicArchivalBackgroundService is running.");

        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.UtcNow;
            var nextRun = _schedule.GetNextOccurrence(now);

            if (now >= nextRun)
            {
                using var scope = _serviceProvider.CreateAsyncScope();
                var topicService = scope.ServiceProvider.GetRequiredService<ITopicService>();
                await topicService.ArchiveInactiveTopicsAsync(stoppingToken);

                _logger.LogInformation("TopicArchivalBackgroundService ran at: {time}", DateTime.Now);
            }

            var delay = nextRun - now;
            await Task.Delay(delay, stoppingToken);
        }
    }
}*/