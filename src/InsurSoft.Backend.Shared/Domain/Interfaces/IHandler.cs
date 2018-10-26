using InsurSoft.Backend.Shared.Events;

namespace InsurSoft.Backend.Shared.Interfaces.Domain
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
