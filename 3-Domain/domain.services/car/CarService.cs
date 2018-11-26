namespace Domain.domain.services.car
{
    using Domain.Entities.car;
    using Domain.repositories.contracts.car;
    /// <summary>
    /// La idea de esta clase es que tenga la logica de negocio
    /// ICarRepository -> es para hecer consultas a base de datos
    /// </summary>
    public class CarService : ICarService
    {
        ICarRepository _iCarRepository;
        public CarService(ICarRepository iCarRepository)
        {
            this._iCarRepository = iCarRepository;
        }

        public string Hola()
        {
            return _iCarRepository.GetEngine()+ "With Nitro";
        }      
    }
}