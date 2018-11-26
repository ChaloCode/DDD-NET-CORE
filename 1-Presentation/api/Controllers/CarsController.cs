using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.application.services.car;
using Domain.Entities.car;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        ICarService carService;
        /// <summary>
        /// Conecta la capa de aplicación usando inyección de dependencia.
        /// </summary>
        /// <param name="carService">Obtiene acceso a la capa de aplicación</param>
        public CarsController(ICarService carService)
        {
            this.carService = carService;           
        }

        // GET api/cars
        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonConvert.SerializeObject(carService.GetCars());
        }

        // GET api/cars/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return JsonConvert.SerializeObject(carService.GetCar(id));
        }

        // POST api/cars
        [HttpPost]
        public void Post(Car carPost)
        {
            carService.Create(carPost);
        }

        // PUT api/cars/5
        [HttpPut("{id}")]
        public void Put(int id, Car carPost)
        {
            Car carro=new Car();
            carro=carPost;
            carro.Id=id;
            carService.Update(carro);
        }

        // DELETE api/cars/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            carService.Delete(id);
        }
    }
}
