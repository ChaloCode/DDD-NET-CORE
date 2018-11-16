namespace Domain.domain.services.car
{
    using Domain.Entities.car;
    using Domain.repositories.contracts.car;  
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