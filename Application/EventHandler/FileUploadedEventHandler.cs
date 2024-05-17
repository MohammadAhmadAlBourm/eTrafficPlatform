using Application.Models;
using Domain.Entities;
using Domain.Events;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;
using System.Xml.Serialization;

namespace Application.EventHandler;

internal sealed class FileUploadedEventHandler(IUnitOfWork _unitOfWork) : INotificationHandler<FileUploadedEvent>
{
    public async Task Handle(FileUploadedEvent notification, CancellationToken cancellationToken)
    {
        string filePath = notification.FilePath;

        TrafficData trafficData = DeserializeXmlFile<TrafficData>(filePath);
        Traffic traffic = PrepareTrafficRequest(trafficData);

        var isExist = await _unitOfWork.TrafficRepository.IsExist(traffic.SessionID, cancellationToken);
        if (isExist)
        {
            throw new BadRequestException($"Traffic Data with provided Session Id {traffic.SessionID} already exist");
        }

        await _unitOfWork.TrafficRepository.Create(traffic, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
    }

    #region PrepareTrafficRequest
    private static Traffic PrepareTrafficRequest(TrafficData trafficData)
    {
        List<TrafficEvent> trafficEvents = [];

        foreach (var events in trafficData.Events)
        {
            TrafficEvent trafficEvent = new()
            {
                SessionID = trafficData.Header.SessionID,
                Time = events.Time,
                Number = events.Number,
                Category = events.Category,
                LaneId = events.LaneId,
                Other = events.Other,
                Value = events.Value,
                Direction = events.Direction
            };
            trafficEvents.Add(trafficEvent);
        }

        Traffic traffic = new()
        {
            Id = Guid.NewGuid(),
            SystemName = trafficData.Header.SystemName,
            Vendor = trafficData.Header.Vendor,
            Subsystem = trafficData.Header.Subsystem,
            Location0 = trafficData.Header.Location0,
            Location1 = trafficData.Header.Location1,
            Location2 = trafficData.Header.Location2,
            LaneCount = trafficData.Header.LaneCount,
            Begin = trafficData.Header.Begin,
            End = trafficData.Header.End,
            SessionID = trafficData.Header.SessionID,
            CaseCount = trafficData.Header.CaseCount,
            TrafficEvents = trafficEvents
        };

        return traffic;
    }
    #endregion

    #region DeserializeXmlFile
    private static T DeserializeXmlFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file at path {filePath} was not found.");
        }

        XmlSerializer serializer = new(typeof(T));

        using FileStream fileStream = new(filePath, FileMode.Open);
        return (T)serializer.Deserialize(fileStream)!;
    }
    #endregion
}