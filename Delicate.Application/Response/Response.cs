using System.Collections.Generic;
using System.Linq;
using Delicate.Domain.Core.Enums;
using FluentValidation.Results;


namespace Delicate.Application.Response
{

    public class Response<TResult>
    {
        public IEnumerable<Notification> Notifications { get; set; }

        public ESeverity Severity { get; set; }
        public TResult Data { get; set; }


        public Response(IEnumerable<Notification> notification, ESeverity severity, TResult data)
        {

            Notifications= notification;
            Severity = severity;
            Data = data;
        }

        public Response(ESeverity severity, TResult data)
        {
            Severity = severity;
            Data = data;
        }


        public static ValidationResult CreateValidationResult(Notification notification)
        {

            var validationFailureItem = new ValidationFailure(notification.Property, notification.Message)
            {
                FormattedMessagePlaceholderValues = new Dictionary<string, object>() { { notification.Property, notification.Message } }
            };

            return new ValidationResult(
                 new List<ValidationFailure>() { validationFailureItem }
             );

        }

        public static ValidationResult CreateValidationResult(string property, string message)
        {
            return CreateValidationResult(new Notification(property, message));
        }

    }
}