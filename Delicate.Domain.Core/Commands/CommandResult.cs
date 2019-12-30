using Delicate.Domain.Core.Enums;

namespace Delicate.Domain.Core.Commands
{
    public class CommandResult
    {
        public Command Command { get; private set; }
        public ESeverity Severity { get; private set; }

        public CommandResult(Command command, ESeverity severity)
        {
            Command = command;
            Severity = severity;
        }
    }
}