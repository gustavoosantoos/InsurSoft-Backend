using InsurSoft.Backend.Shared.Application.Events;

namespace InsurSoft.Backend.Shared.Application.Interfaces
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
