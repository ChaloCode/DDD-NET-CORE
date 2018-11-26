namespace Application.application.services.car
{
    using Domain.Entities.car;
    using DomainService = Domain.domain.services.car;
    using DomainRepository = Domain.repositories.contracts.car;
    using System.Collections.Generic;

    /// <summary>
    /// La idea es que tenga metodos que conecte la logica del dominio
    /// Pero si la logica no tiene reglas de negocio:
    ///     Es decir se quiere solo hacer CRUD en base de datos,
    ///     puede usar en el constructor el repository del dominio. 
    ///     Lo anterior tambien se le llama acceso indirecto a los datos.
    /// </summary>
    public class CarService: ICarService
    {
        DomainService.ICarService _domainICarService;
        DomainRepository.ICarRepository _domainCarRepository;
        /// <summary>
        /// Se puede inyectar las referencias que se requieran, separando las interfaces por coma.
        /// Nota: En el archivo (NativeInjectorBootStrapper.cs) de inyección en la capa de presentación (proyecto de arranque) 
        /// solo se indica la interfaz con la clase que se implementan directamente, no las interfaces que se pasa por el constructor. 
        /// Lo aterior es la menera que se construye las intancias a las clases de forma automatica.
        /// </summary>
        /// <param name="domainICarService">Obtiene el acceso a la logica del dominio</param>
        /// <param name="domainCarRepository">Obtiene el acceso a la base de datos indirectamente</param>
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