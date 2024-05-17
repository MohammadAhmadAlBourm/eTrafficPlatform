namespace Application.Traffics.Queries.GetTrafficById;

public sealed class GetTrafficByIdResponse
{
    public Guid Id { get; set; }
    public string SystemName { get; set; } = string.Empty;
    public string Vendor { get; set; } = string.Empty;
    public string Subsystem { get; set; } = string.Empty;
    public string Location0 { get; set; } = string.Empty;
    public string Location1 { get; set; } = string.Empty;
    public string Location2 { get; set; } = string.Empty;
    public int LaneCount { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
    public string SessionID { get; set; } = string.Empty;
    public int CaseCount { get; set; }
    public List<TrafficEvents> TrafficEvents { get; set; } = [];
}
public sealed class TrafficEvents
{
    public int Id { get; set; }
    public string SessionID { get; set; }
    public DateTime Time { get; set; }
    public int Number { get; set; }
    public string Category { get; set; } = string.Empty;
    public int LaneId { get; set; }

    public string Other { get; set; } = string.Empty;

    public int Value { get; set; }
    public int Direction { get; set; }
}