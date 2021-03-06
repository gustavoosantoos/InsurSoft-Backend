﻿using System;
using System.Threading.Tasks;
using InsurSoft.Backend.Shared.Application.Commands;
using InsurSoft.Backend.Shared.Application.Events;
using InsurSoft.Backend.Shared.Application.Interfaces;
using InsurSoft.Backend.Shared.Application.Notifications.Application;
using InsurSoft.Backend.Shared.Application.Notifications.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsurSoft.Backend.Shared.Application.Handler
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        readonly IMediator _mediator;
        readonly ILogger<MediatorHandler> _logger;

        public MediatorHandler(ILogger<MediatorHandler> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public Task SendCommand<T>(T command) where T : DomainCommand
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }

        public Task RaiseDomainEvent(string key, string value)
        {
            DomainNotification n = new DomainNotification(key, value);
            _logger.LogDebug(value);
            return _mediator.Publish(n);
        }

        public Task RaiseAppEvent(string key, string value)
        {
            ApplicationNotification n = new ApplicationNotification(key, value);
            _logger.LogDebug(value);
            return _mediator.Publish(n);
        }

        public Task RaiseDomainEvent(Type type, string value)
        {
            _logger.LogDebug(value);
            return RaiseDomainEvent(type.ToString(), value);
        }

        public Task RaiseAppEvent(Type type, string value)
        {
            _logger.LogDebug(value);
            return RaiseAppEvent(type.ToString(), value);
        }

        public Task RaiseDomainEvents(Type type, string[] values)
        {
            return Task.Run(() =>
            {
                foreach (var value in values)
                {
                    RaiseDomainEvent(type, value);
                }
            });
        }

        public Task RaiseAppEvent(object caller, string value)
        {
            return RaiseAppEvent(caller.GetType().ToString(), value);
        }

        public Task RaiseDomainEvent(object caller, string value)
        {
            return RaiseDomainEvent(caller.GetType().ToString(), value);
        }

        public Task RaiseAppEvents(object caller, string[] values)
        {
            return Task.Run(() =>
            {
                foreach (var value in values)
                {
                    RaiseAppEvent(caller.GetType().Name, value);
                }
            });
        }

        public Task RaiseDomainEvents(object caller, string[] values)
        {
            return Task.Run(() =>
            {
                foreach (var value in values)
                {
                    RaiseDomainEvent(caller.GetType().Name, value);
                }
            });
        }
    }
}
