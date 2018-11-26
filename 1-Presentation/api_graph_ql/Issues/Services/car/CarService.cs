using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.car;
using ApplicationLayer=Application.application.services.car;
using DoaminService = Application.application.services.car;
using Issues.Models;

namespace Issues.Services
{
    public class CarService : ICarService
    {
        ApplicationLayer.ICarService _applicationCarservice;
        private readonly ICarEventService _events;
        public CarService(ApplicationLayer.ICarService applicationCarservice, ICarEventService events)
        {
            this._applicationCarservice = applicationCarservice;
            _events = events;
        }

        public Car GetCarById(int id)
        {
             return GetCarByIdAsync(id).Result;
        }

        public Task<Car> GetCarByIdAsync(int id)
        {
           Car _car =  _applicationCarservice.GetCar(id);
           return Task.FromResult(_car);
        }

        public Task<IEnumerable<Car>> GetCarsAsync()
        {
            List<Car> _cars = new List<Car>();
            _cars = _applicationCarservice.GetCars();
            return Task.FromResult(_cars.AsEnumerable());
        }

        public Task<Car> CreateAsync(Car car)
        {           
            _applicationCarservice.Create(car);
              var carEvent= new CarEvent(
                car.Id,
                car.Name,
                car.Engine,
                car.Model,
                CarStatuses.CREADO
            );            
            _events.AddEvent(carEvent);
            return Task.FromResult(car);
        }
        public Task<Car> UpdateAsync(Car car)
        {
           // _applicationCarservice.Update(car);
            var carEvent= new CarEvent(
                car.Id,
                car.Name,
                car.Engine,
                car.Model,
                CarStatuses.ACTUALIZADO
            );            
            _events.AddEvent(carEvent);
            return Task.FromResult(car);
        }

        public Task<Car> DeleteAsync(int carId)
        {
            Car carro=new Car();
            carro=_applicationCarservice.GetCar(carId);
            _applicationCarservice.Delete(carId);
            var carEvent= new CarEvent(
                carro.Id,
                carro.Name,
                carro.Engine,
                carro.Model,
                CarStatuses.BORRADO
            );            
            _events.AddEvent(carEvent);
            return Task.FromResult(carro);
        }
    }
}
