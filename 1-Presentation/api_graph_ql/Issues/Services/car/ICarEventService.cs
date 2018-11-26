using System;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Issues.Models;

namespace Issues.Services
{
    public interface ICarEventService
    {
        ConcurrentStack<CarEvent> AllEvents { get; }
        void AddError(Exception exception);
        CarEvent AddEvent(CarEvent carEvent);
        IObservable<CarEvent> EventStream();
    }
}
