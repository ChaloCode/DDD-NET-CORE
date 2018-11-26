namespace Domain.repositories.contracts.car
{
    using System.Collections.Generic;
    using Domain.Entities.car;
    /// <summary>
    /// Son las consultas a base de datos
    /// La implementa la capa de infraestructura
    /// </summary>
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