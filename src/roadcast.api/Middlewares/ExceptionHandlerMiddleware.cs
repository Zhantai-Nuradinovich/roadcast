using roadcast.api.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace roadcast.api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly bool _isDevelopment;

    public ExceptionHandlerMiddleware(RequestDelegate next, bool isDevelopment)
    {
        _next = next;
        _isDevelopment = isDevelopment;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        int statusCode;
        string message;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = StatusCodes.Status400BadRequest;
                message = validationException.Message;
                break;
            case ResourceNotFoundExcepiton notFoundException:
                statusCode = StatusCodes.Status404NotFound;
                message = notFoundException.Message;
                break;
            case UnauthorizedAccessException:
                statusCode = StatusCodes.Status401Unauthorized;
                message = "Unauthorized";
                break;
            case ServiceErrorException serviceErrorException:
                statusCode = StatusCodes.Status500InternalServerError;
                message = serviceErrorException.ErrorMessage;
                if (_isDevelopment)
                    return response.WriteAsync(
                        JsonSerializer.Serialize(new
                        {
                            Error = message,
                            StackTrace = serviceErrorException.StackTrace,
                            InternalException = serviceErrorException.InnerException
                        }));
                break;
            default:
                statusCode = StatusCodes.Status500InternalServerError;
                message = "An unexpected error occurred. Please try again later.";
                break;
        }

        return response.WriteAsync(JsonSerializer.Serialize(new { Error = message }));
    }
}
