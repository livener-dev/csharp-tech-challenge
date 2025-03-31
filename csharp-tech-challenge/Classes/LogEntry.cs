using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace csharp_tech_challenge.Classes
{
    public class LogEntry
    {
        static Regex logEntryRegex = new Regex(@"\[(.*?)\]\s(.*?)\s([0-9]*)\sstream_(.*?)\s(.*?)$", RegexOptions.Compiled);

        public DateTime Timestamp { get; set; }
        public LogEntryType EntryType { get; set; }
        public int UserID{get;set;}
        public int StreamID { get; set; }
        public string Message { get; set; }

        public LogEntry(string line)
        {
            // [2023-10-27 10:00:00] STREAM_RECONNECT 196 stream_1065 Stream reconnected. 
            
            Match match = logEntryRegex.Match(line);

            if (match.Success)
            {
                Timestamp = DateTime.Parse(match.Groups[1].Value); // Need failover in case of parsing issues
                EntryType = Enum.Parse<LogEntryType>(match.Groups[2].Value);
                UserID = int.Parse(match.Groups[3].Value);
                StreamID = int.Parse(match.Groups[4].Value);
                Message = match.Groups[5].Value;
            }
            else
                throw new ArgumentException($"Could not parse log line: {line}", "line");

        }
    }

    public enum LogEntryType
    {
        DEBUG,
        INFO,
        WARNING,
        CRITICAL,
        ERROR,
        STREAM_START,
        STREAM_STOP,
        STREAM_RECONNECT,
        STREAM_RESTART,
        USER_JOIN,
        USER_LEAVE
    }
}
