using System.Diagnostics;

namespace csharp_tech_challenge.Classes
{
    public class LogFile
    {
        string _filename;
        IConfiguration _configuration;

        public List<LogEntry> LogEntries;
        const string LOGS_PATH_KEY = "PathToLogs";

        string pathToLogs;
        string logFilename;

        public LogFile(string filename, IConfiguration configuration) { 
        
            _filename = filename;
            _configuration = configuration;

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));


            if (_configuration[LOGS_PATH_KEY] == null)
                throw new Exception($"Setting not set in appsettings: {LOGS_PATH_KEY}");

            pathToLogs = _configuration[LOGS_PATH_KEY];

            if (Directory.Exists(pathToLogs) == false)
                throw new Exception($"Directory for {LOGS_PATH_KEY} does not exist in appsettings.");

            logFilename = $"{pathToLogs}\\{_filename}";

            if (File.Exists(logFilename) == false)
                throw new FileNotFoundException($"Log file does not exist", logFilename);
        }

        public List<LogEntry> Parse()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Using a streamreader as the log file could be huge
            StreamReader sr = System.IO.File.OpenText(logFilename);

            List<LogEntry> logEntries = new List<LogEntry>();

            LogEntry logEntry = null; //Reuse pointer for efficiency
            string line = null;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                try
                {
                    logEntry = new LogEntry(line);
                    logEntries.Add(logEntry);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            sr.Close();
            this.LogEntries = logEntries;

            sw.Stop();
            Debug.WriteLine($"Time taken to parse file: {sw.ElapsedMilliseconds}ms");
            return logEntries;
        }
    }
}
