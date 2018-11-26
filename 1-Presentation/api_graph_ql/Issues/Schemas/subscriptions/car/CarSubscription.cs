using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GraphQL.Types;
using GraphQL.Subscription;
using GraphQL.Resolvers;
using Issues.Models;
using Issues.Services;

namespace Issues.Schemas
{
    public class CarSubscription: ObjectGraphType<object>
    {
        private readonly ICarEventService _events;

        public CarSubscription(ICarEventService events)
        {
            _events = events;
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "carEvent",
                Arguments = new QueryArguments(new QueryArgument<ListGraphType<CarStatusesEnum>>
                {
                    Name = "statuses"
                }),
                Type = typeof(CarEventType),
                Resolver = new FuncFieldResolver<CarEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<CarEvent>(Subscribe)
            });
        }

        private IObservable<CarEvent> Subscribe(ResolveEventStreamContext context)
        {
            var statusList = context.GetArgument<IList<CarStatuses>>("statuses", new List<CarStatuses>());
            if (statusList.Count > 0)
            {
                CarStatuses statuses = 0;
                foreach (var status in statusList)
                {
                    statuses = statuses | status;    
                }
                return _events.EventStream().Where(e => (e.Status & statuses) == e.Status);
            }
            else
            {
                return _events.EventStream();
            }
        }

        private CarEvent ResolveEvent(ResolveFieldContext context)
        {
            var carEvent = context.Source as CarEvent;
            return carEvent;
        }
    }
} 