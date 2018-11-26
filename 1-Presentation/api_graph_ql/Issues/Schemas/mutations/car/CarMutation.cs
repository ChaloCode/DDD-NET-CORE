using System;
using Domain.Entities.car;
using GraphQL.Types;
using Issues.Models;
using Issues.Services;

namespace Issues.Schemas
{
    /// <summary>
    /// Representa Mutaciones/Persistencia del objeto carro
    /// </summary>
    public class CarMutation : ObjectGraphType<object>
    {
        public CarMutation(ICarService cars)
        {
            Name = "Mutation";
            //Create
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
            //Update
            Field<CarType>(
                "updateCar",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CarUpdateInputType>> { Name = "update"}),
                resolve: context =>
                {
                    var carInput = context.GetArgument<Car>("update");
                    var car = new Car(
                        carInput.Id,
                        carInput.Name,
                        carInput.Engine,
                        carInput.Model
                    );
                    return cars.UpdateAsync(car);
                }
            );
            //Delete
            FieldAsync<CarType>(
                "deleteCar",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "carId"}),
                resolve: async  context =>
                {
                    int carId = context.GetArgument<int>("carId");
                    return await context.TryAsyncResolve(
                        async c => await cars.DeleteAsync(carId));
                }
            );
        }
    }
}