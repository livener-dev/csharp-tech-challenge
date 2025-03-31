using System.Diagnostics;
using System.Runtime.InteropServices;

namespace csharp_tech_challenge.Classes
{
    public static class Aggregation
    {
        public static AggregationResult Aggregate(List<LogEntry> entries)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            AggregationResult result = new AggregationResult();

            result.totalUserJoins = entries.Where(a => a.EntryType == LogEntryType.USER_JOIN).Count();
            result.totalUserLeaves = entries.Where(a => a.EntryType == LogEntryType.USER_LEAVE).Count();

            foreach (var entry in entries)
            {
                UserActivityRecord uar = new UserActivityRecord();

                uar.userId = entry.UserID.ToString();
                uar.@event = entry.EntryType.ToString();
                uar.timestamp = entry.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");

                result.userActivity.Add(uar);
            }

            result.errors.ERROR = entries.Where(a=>a.EntryType == LogEntryType.ERROR).Count();
            result.errors.CRITICAL = entries.Where(a => a.EntryType == LogEntryType.CRITICAL).Count();
            result.errors.WARNING = entries.Where(a => a.EntryType == LogEntryType.WARNING).Count();

            sw.Stop();
            Debug.WriteLine($"Time taken to aggregate: {sw.ElapsedMilliseconds}ms");
            return result;
        }
    }
}
