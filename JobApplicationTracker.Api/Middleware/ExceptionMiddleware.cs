using System.Net;
using System.Text.Json;
using FluentValidation;
using JobApplicationTracker.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex) // FluentValidation errors
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });

                var response = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation failed",
                    Detail = "One or more validation errors occurred.",
                    Extensions = { { "errors", errors } }
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (NotFoundException ex) // Custom NotFoundException
            {
                _logger.LogWarning($"Resource not found: {ex.Message}");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                var response = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Resource Not Found",
                    Detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (CustomValidationException ex) // Custom validation errors
            {
                _logger.LogWarning($"Custom validation failed: {ex.Message}");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Error",
                    Detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex) // Catch all unhandled exceptions
            {
                _logger.LogError($"Exception: {ex.Message}", ex);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please try again later."
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}