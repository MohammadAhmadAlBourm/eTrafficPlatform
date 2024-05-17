namespace Domain.Entities;

public class Traffic
{
    public Guid Id { get; set; } = new Guid();
    public string SystemName { get; set; } = string.Empty;
    public string Vendor { get; set; } = string.Empty;
    public string Subsystem { get; set; } = string.Empty;
    public string Location0 { get; set; } = string.Empty;
    public string Location1 { get; set; } = string.Empty;
    public string Location2 { get; set; } = string.Empty;
    public int LaneCount { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
    public string SessionID { get; set; }
    public int CaseCount { get; set; }
    public ICollection<TrafficEvent> TrafficEvents { get; set; } = [];
}