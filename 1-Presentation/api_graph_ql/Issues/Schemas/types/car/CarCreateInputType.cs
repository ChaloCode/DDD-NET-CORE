using System;
using GraphQL.Types;
namespace Issues.Schemas
{
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
