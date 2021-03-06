using System.Threading.Tasks;
using NinjaStore.Core.Messages.CommonMessages;
using FluentValidation.Results;

namespace NinjaStore.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : DomainEvent;

        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
