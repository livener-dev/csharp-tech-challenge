using csharp_tech_challenge.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace csharp_tech_challenge.Controllers
{
    public class APIController: Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public static readonly string LOG_FILENAME = "webrtc_studio.log";

        public APIController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult CallParseLogFile()
        {
            LogFile logFile = new LogFile(LOG_FILENAME, _configuration);
            var logEntries = logFile.Parse();

            return Json(logEntries.Count);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult loganalysis()
        {
            LogFile logFile = new LogFile(LOG_FILENAME, _configuration);
            var logEntries = logFile.Parse();

            logEntries = logEntries.OrderByDescending(a => a.Timestamp).ToList(); // Sort by newest first - Handy for debugging

            var result = Aggregation.Aggregate(logEntries);

            return Json(result);
        }



    }
}
