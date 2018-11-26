using GraphQL;
using GraphQL.Types;

namespace Issues.Schemas
{
    public class IssuesSchema : Schema
    {
        public IssuesSchema(IssuesQuery query, CarMutation mutation, CarSubscription subscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
            DependencyResolver = resolver;
        }
    }
}
