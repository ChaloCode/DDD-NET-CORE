namespace Application.application.services.car
{
    using DomainService = Domain.domain.services.car;

    public class CarService: ICarService
    {
        DomainService.ICarService _domainICarService;
        public CarService(DomainService.ICarService domainICarService)
        {
            this._domainICarService = domainICarService;
        }

        public string Hola()
        {
            return _domainICarService.Hola();
        }
    }
}