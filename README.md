> Ejemplo practico utilizando la arquitectura DDD (Domain Driven Design) con NET CORE 2.1 EntityFrameworkCore y Visual Code (editor de texto).

## Creando proyecto 

 - dotnet new webapi   (Capa: Presentation)
 - dotnet new classlib  (Capa: Application, Domain, Domain.Entiites)
 - dotnet new sln  (Raíz del proyecto)   

## Agregando referencia (Raíz del proyecto)     
   
   - dotnet add 2-Application/2-Application.csproj reference
   3-Domain/3-Domain.csproj
   
   - dotnet add 4-Infrastructure/4-Infrastructure.csproj reference
   3-Domain/3-Domain.csproj
   
   - dotnet add 1-Presentation/api/api.csproj reference
   2-Application/2-Application.csproj

   - dotnet add 4-Infrastructure/4-Infrastructure.csproj reference 3.1-Domain.Entities/3.1-Domain.Entities.csproj

   - dotnet add 1-Presentation/api/api.csproj reference
   4-Infrastructure/4-Infrastructure.csproj
   
   - dotnet add 3-Domain/3-Domain.csproj reference 3.1-Domain.Entities/3.1-Domain.Entities.csproj
  
   - dotnet add 2-Application/2-Application.csproj reference 3.1-Domain.Entities/3.1-Domain.Entities.csproj

   - dotnet add 1-Presentation/api/api.csproj reference 3.1-Domain.Entities/3.1-Domain.Entities.csproj
   
## Agregando los proyectos a la solución del proyecto (Raíz del proyecto) 

       dotnet sln DDD.NET.CORE.sln add 1-Presentation/api/api.csproj
       2-Application/2-Application.csproj 3-Domain/3-Domain.csproj
       4-Infrastructure/4-Infrastructure.csproj 3.1-Domain.Entities/3.1-Domain.Entities.csproj

 ## Comandos útiles NET CORE 2.1    
  
  - dotnet clean
  - dotnet build
  - dotnet run --project 1-Presentation/api/api.csproj
     
 ##   Plugins útiles Visual Code 

  -  C# ms-vscode.csharp   
  -  vscode-solution-explorer   
  -  C# IDE Extensions for VSCode
  -  .NET Core Test Explorer
  -  Rainbow Brackets
  -  Markdown Preview Enhanced
  -  Beautify

 ## Instalar Entity Famework (Capa: Infrastructure, Presentation)

  - [Documentación de apoyo](https://docs.microsoft.com/en-us/ef/core/get-started/install/)
  - dotnet add package Microsoft.EntityFrameworkCore
  - dotnet add package Microsoft.EntityFrameworkCore.Sqlite
  - dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  - dotnet add package Microsoft.EntityFrameworkCore.Design
  - dotnet add package Microsoft.EntityFrameworkCore.Tools
  - dotnet add package Microsoft.Extensions.Configuration
  - dotnet add package Microsoft.Extensions.Configuration.Json

## Ejecutar comandos, Entity Famework (Capa: Presentation)

  - dotnet ef migrations add CarDBExample -p ../../4-Infrastructure/4-Infrastructure.csproj 
  - dotnet ef database update

## Instalar NuGet 

  - dotnet add package Newtonsoft.Json (Capa: Presentation)