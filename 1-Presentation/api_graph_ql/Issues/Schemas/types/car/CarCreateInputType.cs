using System;
using GraphQL.Types;
namespace Issues.Schemas
{
    /// <summary>
    /// Representa la entrada de un carro
    /// Es la forma en que GraphQL mapea y documenta los objetos   
    /// </summary>
    public class CarCreateInputType: InputObjectGraphType
    {
        public CarCreateInputType()
        {
            Name = "CarInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("engine");
            Field<NonNullGraphType<StringGraphType>>("model");
        }
    }
}
