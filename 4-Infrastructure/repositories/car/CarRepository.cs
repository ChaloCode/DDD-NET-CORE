namespace Infrastructure.repositories.car
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Entities.car;
    using Domain.repositories.contracts.car;
    using Microsoft.EntityFrameworkCore;

    public class CarRepository : ICarRepository
    {
        private CarContext _carContext;
        public CarRepository()
        {
            _carContext = new CarContext();

        }
        public void Create(Car carEntitie)
        {
            _carContext.Cars.Add(carEntitie);
            _carContext.SaveChanges();
        }
        public void Delete(int id)
        {
            _carContext.Cars.Remove(_carContext.Cars.Find(id));
            _carContext.SaveChanges();
        }
        public Car GetCar(int id)
        {
            return _carContext.Cars.Find(id);
        }
        public List<Car> GetCars()
        {
            IQueryable<Car> query =
            from Car in _carContext.Cars
            orderby Car.Name descending
            select Car;
            return query.ToList();
        }
        public string GetEngine()
        {
            return "V8";
        }
        public void Update(Car carEntitie)
        {
            _carContext.Cars.Attach(carEntitie);
            _carContext.Entry(carEntitie).State = EntityState.Modified;
            _carContext.SaveChanges();
        }
    }
}
