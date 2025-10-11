namespace vl_dotnet_backend.Models;

public class PublicSchedule
{
    public class Weekly
    {
        public string Day { get; set; } = string.Empty;
        public bool IsOpen { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
    }
    
    public List<Weekly> WeeklySchedule { get; set; } = new List<Weekly>();
    public List<DateOnly>? Holydays { get; set; }
}