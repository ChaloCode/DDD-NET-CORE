namespace Domain.repositories.contracts.car
{
    using System.Collections.Generic;
    using Domain.Entities.car;
    public interface ICarRepository
    {
        string GetEngine();        
        void Create(Car carEntitie);
        void Update(Car carEntitie);
        void Delete(int id);
        Car GetCar(int id);
        List<Car> GetCars();
    }
}