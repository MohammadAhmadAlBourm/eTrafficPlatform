namespace Application.Models;

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot(ElementName = "TrafficData")]
public class TrafficData
{
    [XmlAttribute(AttributeName = "Version")]
    public string Version { get; set; } = string.Empty;

    [XmlElement(ElementName = "Header")]
    public Header Header { get; set; } = new();

    [XmlArray(ElementName = "Events")]
    [XmlArrayItem(ElementName = "m")]
    public List<Event> Events { get; set; } = [];
}

public class Header
{
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
}

public class Event
{
    [XmlAttribute(AttributeName = "t")]
    public DateTime Time { get; set; }

    [XmlAttribute(AttributeName = "n")]
    public int Number { get; set; }

    [XmlAttribute(AttributeName = "c")]
    public string Category { get; set; } = string.Empty;

    [XmlAttribute(AttributeName = "li")]
    public int LaneId { get; set; }

    [XmlAttribute(AttributeName = "o")]
    public string Other { get; set; } = string.Empty;

    [XmlAttribute(AttributeName = "v")]
    public int Value { get; set; }

    [XmlAttribute(AttributeName = "di")]
    public int Direction { get; set; }
}