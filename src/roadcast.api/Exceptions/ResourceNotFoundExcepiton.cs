namespace roadcast.api.Exceptions;

public class ResourceNotFoundExcepiton : Exception
{
    public ResourceNotFoundExcepiton(string resourceName)
    {
        ResourceName = resourceName;
    }

    public string ResourceName { get; set; }
}
