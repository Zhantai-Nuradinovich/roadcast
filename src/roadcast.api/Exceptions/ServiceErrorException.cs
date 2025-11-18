namespace roadcast.api.Exceptions;

public class ServiceErrorException : Exception
{
    protected const string DEFAULT_GENERIC_ERROR_MESSAGE = "Internal service error";

    public ServiceErrorException(Exception innerException, string genericMessage)
    {
        InnerException = innerException;
        ErrorMessage = genericMessage;
    }

    public ServiceErrorException(string genericMessage)
    {
        ErrorMessage = genericMessage;
    }

    public ServiceErrorException()
    {

    }

    public new Exception? InnerException { get; init; }
    public string ErrorMessage { get; init; } = DEFAULT_GENERIC_ERROR_MESSAGE;
}
