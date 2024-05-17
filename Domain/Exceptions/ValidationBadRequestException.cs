namespace Domain.Exceptions;

public class ValidationBadRequestException(string[] errors) : Exception("Multiple errors occurred. See error details.")
{
    public string[] Errors { get; set; } = errors;
}