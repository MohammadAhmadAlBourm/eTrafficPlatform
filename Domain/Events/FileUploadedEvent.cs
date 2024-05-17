using MediatR;

namespace Domain.Events;

public sealed record FileUploadedEvent(string FilePath) : INotification;