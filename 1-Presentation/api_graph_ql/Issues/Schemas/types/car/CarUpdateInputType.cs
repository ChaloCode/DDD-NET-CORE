using System;
using GraphQL.Types;
namespace Issues.Schemas
{
    /// <summary>
    /// Representa los atributos del objeto carro que van a ser modificados
    /// Es la forma en que GraphQL mapea y documenta los objetos   
    /// </summary>
    public class CarUpdateInputType: InputObjectGraphType
    {
        public CarUpdateInputType()
        {
            Name = "CarInputUpdate";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("engine");
            Field<NonNullGraphType<StringGraphType>>("model");
        }
    }
}
