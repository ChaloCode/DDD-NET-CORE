namespace Application.application.services.car
{
    using System.Collections.Generic;
    using Domain.Entities.car;
    /// <summary>
    /// Tiene los metodos que requiere la logica 
    /// </summary>
    public interface ICarService
    {
        string Hola();
        void Create(Car carEntitie);
        void Update(Car carEntitie);
        void Delete(int id);
        Car GetCar(int id);
        List<Car> GetCars();
    }
}