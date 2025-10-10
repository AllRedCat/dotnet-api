namespace vl_dotnet_backend.Models;

public abstract class OperationalSchedule
{
    public int Day { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
}