using GraphQL.Types;
using Issues.Models;

namespace Issues.Schemas
{
    /// <summary>
    /// Representa un evento carro que va ser notificado por WebSocket (scription en terminos de GraphQL)
    /// Es la forma en que GraphQL mapea y documenta los objetos   
    /// </summary>
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