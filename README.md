> Ejemplo practico utilizando la arquitectura DDD (domain driven design) con NET CORE 2.1 y Visual Code (editor de texto).

## Creando proyecto 

 - dotnet new webapi   (Capa: presentation)
 - dotnet new classlib  (Capa: Application, Domain)
 - dotnet new sln  (Raíz del proyecto)   

## Agregando referencia     
   
   - dotnet add 2-Application/2-Application.csproj reference
   3-Domain/3-Domain.csproj
   
   - dotnet add 4-Infrastructure/4-Infrastructure.csproj reference
   3-Domain/3-Domain.csproj
   
   - dotnet add 1-Presentation/api/api.csproj reference
   2-Application/2-Application.csproj
   
## Agregando proyecto a la solución del proyecto

       dotnet sln DDD.NET.CORE.sln add 1-Presentation/api/api.csproj
       2-Application/2-Application.csproj 3-Domain/3-Domain.csproj
       4-Infrastructure/4-Infrastructure.csproj

   
 ## Comandos útiles NET CORE 2.1    
  
  - dotnet clean
  - dotnet build
  - dotnet run --project 1-Presentation/api/api.csproj
     
 ##   Plugin Visual Code 

  -  C# ms-vscode.csharp   
  -  vscode-solution-explorer   
  -  C# IDE Extensions for VSCode
