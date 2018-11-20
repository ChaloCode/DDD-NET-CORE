using GraphQL;
using GraphQL.Types;

namespace Issues.Schemas
{
    public class IssuesSchema : Schema
    {
        public IssuesSchema(IssuesQuery query, CarMutation mutation, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
        }
    }
}
