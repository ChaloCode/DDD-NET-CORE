using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.car;
using ApplicationLayer=Application.application.services.car;
using DoaminService = Application.application.services.car;
namespace Issues.Services
{
    public class CarService : ICarService
    {
        ApplicationLayer.ICarService _applicationCarservice;
        private IList<Car> _cars;
        
        public CarService()
        {
            _cars =new List<Car>();
            _cars.Add(new Car(1,"a","b","c"));
            _cars.Add(new Car(1,"d","e","f"));
            _cars.Add(new Car(1,"j","k","m"));
        }
        

        public CarService(ApplicationLayer.ICarService applicationCarservice)
        {
            this._applicationCarservice = applicationCarservice;
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
            _cars = new List<Car>();
            _cars = _applicationCarservice.GetCars();
            return Task.FromResult(_cars.AsEnumerable());
        }

        public Task<Car> CreateAsync(Car car)
        {
            _cars.Add(car);
            _applicationCarservice.Create(car);
            return Task.FromResult(car);
        }
    }
}
