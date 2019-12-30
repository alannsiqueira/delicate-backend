
using System;
using Delicate.Domain.Core.Events;
using FluentValidation.Results;

namespace Delicate.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public readonly DateTime Timestamp;
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();

    }
}