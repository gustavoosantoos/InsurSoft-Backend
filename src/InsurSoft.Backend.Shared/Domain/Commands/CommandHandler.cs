using AutoMapper;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Shared.Notifications.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsurSoft.Backend.Shared.Domain.Commands
{
    public class CommandHandler
    {
        protected readonly IMediatorHandler _mediatorHandler;
        protected readonly IMapper _mapper;
        protected readonly ILogger<CommandHandler> _logger;
        protected readonly DomainNotificationHandler _notifications;

        public CommandHandler(
            IMapper mapper,
            IMediatorHandler mediatorHandler, 
            INotificationHandler<DomainNotification> notifications)
        {
            _mapper = mapper;
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }
        
        public CommandHandler(ILogger<CommandHandler> logger)
        {
            _logger = logger;
        }
        
        protected void NotifyValidationErrors(DomainCommand message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }
    }
}
