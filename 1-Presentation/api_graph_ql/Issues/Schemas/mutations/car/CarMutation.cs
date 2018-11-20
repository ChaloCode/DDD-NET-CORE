using System;
using Domain.Entities.car;
using GraphQL.Types;
using Issues.Models;
using Issues.Services;

namespace Issues.Schemas
{
    public class CarMutation : ObjectGraphType<object>
    {
        public CarMutation(ICarService cars)
        {
            Name = "Mutation";
            Field<CarType>(
                "createCar",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CarCreateInputType>> { Name = "car" }),
                resolve: context => 
                {
                    var carInput = context.GetArgument<CarCreateInput>("car");
                    var car = new Car(
                        carInput.Name,
                        carInput.Engine,
                        carInput.Model
                    );
                    return cars.CreateAsync(car);
                }
            );
        }
    }
}