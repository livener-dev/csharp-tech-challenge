namespace csharp_tech_challenge.Classes
{
    public class AggregationResult
    {
        public int totalUserJoins { get; set; }
        public int totalUserLeaves { get; set; }
        public List<UserActivityRecord> userActivity { get; set; } = new List<UserActivityRecord>();
        public ErrorTotals errors { get; set; } = new ErrorTotals();
    }

    public class UserActivityRecord
    {
        public string userId { get; set; } = string.Empty;
        public string @event { get;set; } = string.Empty;
        public string timestamp { get; set; } = string.Empty;
    }

    public class ErrorTotals
    {
        public int ERROR { get; set; }
        public int CRITICAL { get; set; }
        public int WARNING { get; set; }
    }
}
