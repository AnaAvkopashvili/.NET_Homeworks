using Forum.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Forum.Web.BackgroundServices
{
    public class BanUserBackgroundService : BackgroundService
    {
        private readonly ILogger<BanUserBackgroundService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public BanUserBackgroundService(ILogger<BanUserBackgroundService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("BanUserBackgroundService is running.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateAsyncScope();
                var _userRoleService = scope.ServiceProvider.GetRequiredService<IUserManagementService>();

                var users = await _userRoleService.GetAllBannedAsync();
                foreach (var user in users)
                {
                    await _userRoleService.UnbanUserAsync(user.Id);
                    _logger.LogInformation($"User {user.UserName} has been unbanned.");
                }

                _logger.LogInformation("BanUserBackgroundService ran at: {time}", DateTime.Now);
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}





//using Forum.Application.Services;
//using Forum.Application.Topics;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using NCrontab;

//namespace Forum.Web.BackgroundServices
//{
//    public class BanUserBackgroundService : BackgroundService
//    {
//        private readonly ILogger<BanUserBackgroundService> _logger;
//        private readonly IServiceProvider _serviceProvider;
//        private DateTime _nextRun;
//        private CrontabSchedule _schedule;

//        private string Schedule => "*/2 * * * *"; // Every 2 minutes
//        public BanUserBackgroundService(ILogger<BanUserBackgroundService> logger, IServiceProvider serviceProvider)
//        {
//            _logger = logger;
//            _serviceProvider = serviceProvider;
//            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = false });
//            _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
//        }

//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            _logger.LogInformation("BanUserBackgroundService is running.");
//            do
//            {
//                var now = DateTime.UtcNow;
//                _schedule.GetNextOccurrence(now);

//                if (now > _nextRun)
//                {
//                    using var scope = _serviceProvider.CreateAsyncScope();
//                    var _userRoleService = scope.ServiceProvider.GetRequiredService<IUserManagementService>();

//                    var users = await _userRoleService.GetAllBannedAsync();
//                    foreach (var user in users)
//                    {
//                        await _userRoleService.UnbanUserAsync(user.Id);
//                        _logger.LogInformation($"User {user.UserName} has been unbanned.");
//                    }

//                    _logger.LogInformation("BanUserBackgroundService ran at: {time}", DateTime.Now);
//                    _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
//                }
//            }
//            while (!stoppingToken.IsCancellationRequested);
//        }
//    }
//}