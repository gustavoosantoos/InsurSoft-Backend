using System;

namespace InsurSoft.Backend.Shared.Application.Events
{
    public class EventObject : Event
    {
        public EventObject(Event theEvent, string data)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
        }

        protected EventObject() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }
    }
}
