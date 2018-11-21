using System;
using GraphQL.Types;
namespace Issues.Schemas
{
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
