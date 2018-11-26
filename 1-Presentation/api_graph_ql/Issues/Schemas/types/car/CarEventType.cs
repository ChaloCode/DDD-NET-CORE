using GraphQL.Types;
using Issues.Models;

namespace Issues.Schemas
{
    public class CarEventType : ObjectGraphType<CarEvent>
    {
        public CarEventType()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.Engine);
            Field(e => e.Model);
            Field<CarStatusesEnum>("status",
                resolve: context => context.Source.Status);
        }
    }
} 