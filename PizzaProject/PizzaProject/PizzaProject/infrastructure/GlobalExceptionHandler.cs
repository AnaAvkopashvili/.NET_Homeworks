using PizzaRestaurant.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PizzaRestaurant.API.infrastructure
{
        public class GlobalExceptionHandler: ProblemDetails
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

        private void HandleException(PizzaNotFound exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        private void HandleException(PizzaAlreadyExists exception)
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
            Status = (int)HttpStatusCode.BadRequest;
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
        private void HandleException(AddressNotFound exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        private void HandleException(AddressAlreadyExists exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(RankHistoryNotFound exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(RankHistoryAlreadyExists exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        private void HandleException(OrderAlreadyExists exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(OrderNotFound exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }
        private void HandleException(Exception exception)
        {

        }
    }
}
