using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.car;

namespace Issues.Services
{
    public interface ICarService
    {
        Car GetCarById(int id);
        Task<Car> GetCarByIdAsync(int id);
        Task<IEnumerable<Car>> GetCarsAsync();
        Task<Car> CreateAsync(Car car);
    }
}
