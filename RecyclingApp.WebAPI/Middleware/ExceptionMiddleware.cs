using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RecyclingApp.Application;
using RecyclingApp.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecyclingApp.WebAPI.Middleware;

internal sealed class ExceptionMiddleware : IMiddleware
{
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public ExceptionMiddleware(ProblemDetailsFactory problemDetailsFactory)
        => _problemDetailsFactory = problemDetailsFactory;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problemDetails = _problemDetailsFactory.CreateProblemDetails(
            httpContext: context,
            statusCode: GetStatusCode(exception),
            title: exception.Message,
            instance: context.Request.Path);

        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            EntityNotFoundException => StatusCodes.Status404NotFound,
            Exception => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

    private static IReadOnlyDictionary<string, string[]>? GetErrors(Exception exception)
    {
        if (exception is ValidationException validationException)
            return validationException.Errors;

        return null;
    }
}
