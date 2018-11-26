using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.car;

namespace Issues.Services
{
    /// <summary>
    /// Contiene los metodos de la logica de carro
    /// </summary>
    public interface ICarService
    {
        Car GetCarById(int id);
        Task<Car> GetCarByIdAsync(int id);
        Task<IEnumerable<Car>> GetCarsAsync();
        Task<Car> CreateAsync(Car car);
        Task<Car> UpdateAsync(Car car);
        Task<Car> DeleteAsync(int carId);
    }
}
