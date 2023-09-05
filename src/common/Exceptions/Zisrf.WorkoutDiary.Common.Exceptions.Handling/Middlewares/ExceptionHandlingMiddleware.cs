using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Zisrf.WorkoutDiary.Common.Exceptions.Application.DataAccess;
using Zisrf.WorkoutDiary.Common.Exceptions.Domain;

namespace Zisrf.WorkoutDiary.Common.Exceptions.Handling.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException exception)
        {
            await HandleExceptionAsync(context, (int)HttpStatusCode.NotFound, exception.Message);
        }
        catch (DomainException exception)
        {
            await HandleExceptionAsync(context, (int)HttpStatusCode.BadRequest, exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError("Error: {ExceptionMessage}", exception.Message);

            await HandleExceptionAsync(context, (int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        int httpStatusCode,
        string exceptionMessage)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = httpStatusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(new
        {
            Code = httpStatusCode,
            Error = exceptionMessage
        }));
    }
}