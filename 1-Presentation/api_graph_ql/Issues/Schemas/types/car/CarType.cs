using System;
using Domain.Entities.car;
using GraphQL.Types;
using Issues.Services;

namespace Issues.Schemas
{
    /// <summary>
    /// Representa los atributos del objeto carro 
    /// Es la forma en que GraphQL mapea y documenta los objetos   
    /// </summary>
    public class CarType: ObjectGraphType<Car>
    {
        public CarType(ICarService cars)
        {
             Field(f => f.Id)
                .Description("Id del carro");
            Field(f => f.Name)
                .Description("Nombre del carro");
            Field(f => f.Engine)
                .Description("Motor del carro");           
            Field(f => f.Model)
                .Description("Modelo del carro");
        }
    }
}
