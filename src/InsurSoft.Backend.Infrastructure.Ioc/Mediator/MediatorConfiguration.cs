using InsurSoft.Backend.Shared.Application.Handler;
using InsurSoft.Backend.Shared.Application.Interfaces;
using InsurSoft.Backend.Shared.Application.Notifications.Application;
using InsurSoft.Backend.Shared.Application.Notifications.Domain;
using MediatR;
using SimpleInjector;

namespace InsurSoft.Backend.Infrastructure.Ioc.Mediator
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
