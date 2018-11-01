using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Shared.Notifications.Application
{
    public class ApplicationNotificationHandler : INotificationHandler<ApplicationNotification>
    {
        List<ApplicationNotification> _notifications;

        public ApplicationNotificationHandler()
        {
            _notifications = new List<ApplicationNotification>();
        }

        public Task Handle(ApplicationNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public virtual List<ApplicationNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<ApplicationNotification>();
        }
    }
}
