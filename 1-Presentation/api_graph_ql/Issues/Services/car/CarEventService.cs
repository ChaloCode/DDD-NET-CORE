using System;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Issues.Models;
namespace Issues.Services
{
    public class CarEventService : ICarEventService
    {
        private readonly ISubject<CarEvent> _eventStream = new ReplaySubject<CarEvent>(1);
        public ConcurrentStack<CarEvent> AllEvents { get; }
        public CarEventService()
        {
            AllEvents = new ConcurrentStack<CarEvent>();
        }
        public void AddError(Exception exception)
        {
            _eventStream.OnError(exception);
        }
        public CarEvent AddEvent(CarEvent carEvent)
        {
            AllEvents.Push(carEvent);
            _eventStream.OnNext(carEvent);
            return carEvent;
        }
        public IObservable<CarEvent> EventStream()
        {
            return _eventStream.AsObservable();
        }
    }
}
