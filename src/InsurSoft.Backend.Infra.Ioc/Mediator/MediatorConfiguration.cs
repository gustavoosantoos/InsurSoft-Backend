using InsurSoft.Backend.Shared.Domain.Handler;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Shared.Notifications.Application;
using InsurSoft.Backend.Shared.Notifications.Domain;
using MediatR;
using SimpleInjector;

namespace InsurSoft.Backend.Infra.Ioc.Mediator
{
    public static class MediatorConfiguration
    {
        public static void RegisterMediatorIoc(this Container container)
        {
            container.BuildMediator();
            container.Register<IMediatorHandler, MediatorHandler>(Lifestyle.Scoped);

            container.Register<INotificationHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
            container.Register<INotificationHandler<ApplicationNotification>, ApplicationNotificationHandler>(Lifestyle.Scoped);

            container.Collection.Register<INotificationHandler<DomainNotification>>(
                typeof(DomainNotificationHandler));

            container.Collection.Register<INotificationHandler<ApplicationNotification>>(
                typeof(ApplicationNotificationHandler));
        }
    }
}
