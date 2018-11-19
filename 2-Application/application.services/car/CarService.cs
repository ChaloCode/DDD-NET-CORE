namespace Application.application.services.car
{
    using Domain.Entities.car;
    using DomainService = Domain.domain.services.car;
    using DomainRepository = Domain.repositories.contracts.car;
    using System.Collections.Generic;

    public class CarService: ICarService
    {
        
        DomainService.ICarService _domainICarService;
        DomainRepository.ICarRepository _domainCarRepository;
        public CarService(DomainService.ICarService domainICarService, DomainRepository.ICarRepository domainCarRepository)
        {
            this._domainICarService = domainICarService;
            this._domainCarRepository = domainCarRepository;
        }

        public void Create(Car carEntitie)
        {
            _domainCarRepository.Create(carEntitie);
        }

        public void Delete(int id)
        {
            _domainCarRepository.Delete(id);
        }

        public Car GetCar(int id)
        {
            return _domainCarRepository.GetCar(id);
        }

        public List<Car> GetCars()
        {
           return _domainCarRepository.GetCars();
        }

        public string Hola()
        {
            return _domainICarService.Hola();
        }

        public void Update(Car carEntitie)
        {
            _domainCarRepository.Update(carEntitie);
        }
    }
}