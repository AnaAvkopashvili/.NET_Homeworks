using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoManagement.Application.Exceptions.Subtasks;
using ToDoManagement.Application.Exceptions.ToDos;
using ToDoManagement.Application.Exceptions.Users;
namespace ToDoManagement.Infrastructure
{
    public class GlobalExceptionHandler : ProblemDetails
    {
        public const string UnhandlerErrorCode = "UnhandledError";
        private HttpContext _httpContext;
        private Exception _exception;

        public LogLevel LogLevel { get; set; }
        public string Code { get; set; }

        public string? TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId))
                {
                    return (string?)traceId;
                }

                return null;
            }

            set => Extensions["TraceId"] = value;
        }

        public GlobalExceptionHandler(HttpContext httpContext, Exception exception)
        {
            _httpContext = httpContext;
            _exception = exception;

            TraceId = httpContext.TraceIdentifier;

            Code = UnhandlerErrorCode;
            Status = (int)HttpStatusCode.InternalServerError;
            Title = "მოხდა შეცდომა სერვერზე";
            LogLevel = LogLevel.Error;
            Instance = httpContext.Request.Path;

            HandleException((dynamic)exception);
        }

        private void HandleException(SubtaskNotFound exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        private void HandleException(SubtaskAlreadyExists exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(UserNotFound exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        private void HandleException(UserAlreadyExists exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(ToDoNotFound exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        private void HandleException(ToDoAlreadyExists exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(Exception exception)
        {

        }
    }
}
