namespace Domain.Entities;

public class TrafficEvent
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
    public Traffic Traffic { get; set; }
}