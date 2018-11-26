using GraphQL;
using GraphQL.Types;

namespace Issues.Schemas
{
    /// <summary>
    /// Es la puerta de entrada con el servidor de GraphQL.
    /// Es decir, es donde llega la inyección de dependecias.
    /// </summary>
    public class IssuesSchema : Schema
    {
        /// <summary>
        /// Inicia la lógica de GraphQL
        /// </summary>
        /// <param name="query">Permite realizar consultas</param>
        /// <param name="mutation">Permite realizar persistencia</param>
        /// <param name="subscription">Permite realizar notificaciones por WebSockets</param>
        /// <param name="resolver">Son las inyecciones de dependencias</param>
        public IssuesSchema(IssuesQuery query, CarMutation mutation, CarSubscription subscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
            DependencyResolver = resolver;
        }
    }
}
