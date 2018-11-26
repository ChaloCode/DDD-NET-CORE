using GraphQL.Types;
using Issues.Services;

namespace Issues.Schemas
{
    /// <summary>
    /// Expone los metodos de GraphQL a Internet
    /// Un equivalente en una API REST seria los Routes
    /// </summary>
    public class IssuesQuery : ObjectGraphType<object>
    {
        private IIssueService issues;
        private IUserService users;
        private ICarService car;
        /// <summary>
        /// Resulve todas las clases que se quiere exponer.
        /// Mediante la inyección de dependencias.
        /// </summary>
        /// <param name="issues">Resulve issues</param>
        /// <param name="users">Resulve users</param>
        /// <param name="car">Resulve car</param>
        public IssuesQuery(IIssueService issues, IUserService users, ICarService car)
        {
            this.issues = issues;
            this.users = users;
            this.car = car;
            Name = "Query";
            Field<ListGraphType<IssueType>>(
                "issues",
                resolve: context => issues.GetIssuesAsync());
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => users.GetUsersAsync());
            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return users.GetUserByIdAsync(id);
                });
            Field<ListGraphType<CarType>>(
                "carros",
                resolve: context => car.GetCarsAsync());
            Field<CarType>(
                "carro",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return  car.GetCarByIdAsync(id);
                });
        }
    }
}
