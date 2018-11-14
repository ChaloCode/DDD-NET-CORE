dotnet new webapi
dotnet new classlib
dotnet new sln

dotnet add 2-Application/2-Application.csproj reference 3-Domain/3-Domain.csproj
dotnet add 4-Infrastructure/4-Infrastructure.csproj  reference 3-Domain/3-Domain.csproj
dotnet add 1-Presentation/api/api.csproj reference 2-Application/2-Application.csproj

dotnet clean
dotnet build
dotnet run --project 1-Presentation/api/api.csproj

dotnet sln DDD.NET.CORE.sln add 1-Presentation/api/api.csproj 2-Application/2-Application.csproj 3-Domain/3-Domain.csproj 4-Infrastructure/4-Infrastructure.csproj