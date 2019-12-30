using System.Threading.Tasks;
using Delicate.Domain.Core.Commands;
using Delicate.Domain.Core.Events;

namespace Delicate.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
