using GraphQL.Types;
using Issues.Services;

namespace Issues.Schemas
{
    public class IssuesQuery : ObjectGraphType<object>
    {
        public IssuesQuery(IIssueService issues, IUserService users, ICarService car)
        {
            Name = "Query";
            Field<ListGraphType<IssueType>>(
                "issues",
                resolve: context => issues.GetIssuesAsync());
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => users.GetUsersAsync());
            Field<ListGraphType<CarType>>(
                "carros",
                resolve: context => car.GetCarsAsync());
            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => 
                {
                    var id = context.GetArgument<int>("id");
                    return users.GetUserByIdAsync(id);
                });
        }
    }
}
