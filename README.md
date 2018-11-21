> Ejemplo práctico implementado con la arquitectura DDD (Domain Driven Design) usando NET CORE 2.1, Entity Framework Core, GraphQL y Visual Code (editor de texto).

## Requisitos
- Este proyecto se probo sobre S.O Windows
- [Instalar Visual Code](https://code.visualstudio.com/)
- [Instalar Git](https://git-scm.com/downloads)
- [Instalar NET CORE 2.1](https://docs.microsoft.com/es-es/dotnet/core/#download-net-core-21) 

## Comandos útiles NET CORE 2.1
[Documentación de apoyo](https://docs.microsoft.com/es-es/dotnet/core/tools/dotnet-new?tabs=netcore21) 
- dotnet clean
- dotnet build
- dotnet run -p 1-Presentation/api/api.csproj

## Plugins útiles Visual Code  

- [C# ms-vscode.csharp](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
- [vscode-solution-explorer](https://marketplace.visualstudio.com/items?itemName=fernandoescolar.vscode-solution-explorer)
- [C# IDE Extensions for VSCode](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions)
- [.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)
- [Rainbow Brackets](https://marketplace.visualstudio.com/items?itemName=2gua.rainbow-brackets)
- [Markdown Preview Enhanced](https://marketplace.visualstudio.com/items?itemName=jasonroger.markdown-preview-enhanced-fork)

# Paso I
> Con este paso podrá realizar "Hola Mundo" sobre la arquitectura  DDD, [rama del proyecto HolaMundo](https://github.com/gonzaloperezbarrios/DDD-NET-CORE/tree/HolaMundo)

## Creando proyecto DDD
>Ejecute los siguientes comandos en un shell o cmd:
1. Crea la carpeta raíz del proyecto
**md DDD.NET.CORE**
2.  Acceder al proyecto
**cd DDD.NET.CORE** 
3. Crear la estructura del proyecto:
- *Capa: presentación*
	- **md 1-Presentation**
	-  **md api**
	- **cd api**
	- **dotnet new webapi**
	- **cd .. cd ..** (Regresar a la carpeta raíz)	
- *Capa Aplicación*				
	- **md 2-Application**
	- **cd 2-Application**
	- **dotnet new classlib**
	- **cd . .** (Regresar a la carpeta raíz)
- *Capa Dominio*
	- **md 3-Domain**
	- **cd 3-Domain**
	- **dotnet new classlib**
	- **cd . .** (Regresar a la carpeta raíz)
- *Capa Dominio entidad*
	- **md 3.1-Domain.Entities**
	- **cd 3.1-Domain.Entities**
	- **dotnet new classlib**
	- **cd . .** (Regresar a la carpeta raíz)
4. Agregar la solución del proyecto
	- **dotnet new sln**  

## Agregando referencias 
>Ejecute los siguientes comandos en un shell o cmd (Raíz del proyecto):

- dotnet add 1-Presentation/api/api.csproj reference 2-Application/2-Application.csproj  3.1-Domain.Entities/3.1-Domain.Entities.csproj 4-Infrastructure/4-Infrastructure.csproj

- dotnet add 2-Application/2-Application.csproj reference 3-Domain/3-Domain.csproj 3.1-Domain.Entities/3.1-Domain.Entities.csproj 

- dotnet add 3-Domain/3-Domain.csproj reference 3.1-Domain.Entities/3.1-Domain.Entities.csproj

- dotnet add 4-Infrastructure/4-Infrastructure.csproj reference 3-Domain/3-Domain.csproj 3.1-Domain.Entities/3.1-Domain.Entities.csproj

## Agregando los proyectos a la solución del proyecto

>Ejecute el siguiente comando en un shell o cmd (Raíz del proyecto):
  
    dotnet sln DDD.NET.CORE.sln add 1-Presentation/api/api.csproj 2-Application/2-Application.csproj 3-Domain/3-Domain.csproj 4-3.1-Domain.Entities/3.1-Domain.Entities.csproj 4-Infrastructure/4-Infrastructure.csproj 
 
# Paso II
> Con este paso podrá conectarse a una base de datos usando Entity Framework Core, [rama del proyecto EntityFameworkCore](https://github.com/gonzaloperezbarrios/DDD-NET-CORE/tree/EntityFameworkCore)

## Instalar Entity Famework 

>Ejecute los siguientes comandos en un shell o cmd (raíz del proyecto)
>[Documentación de apoyo](https://docs.microsoft.com/en-us/ef/core/get-started/install/)

 - *Capa: presentación* 
	 - cd 1-Presentation/api/  
	- dotnet add package Microsoft.EntityFrameworkCore
	- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
	- dotnet add package Microsoft.Extensions.Configuration
	- dotnet add package Microsoft.Extensions.Configuration.Json
	- **cd .. cd ..** (Regresar a la carpeta raíz)
 - *Capa: Infraestructura* 
	 - cd 4-Infrastructure 
	- dotnet add package Microsoft.EntityFrameworkCore
	- dotnet add package Microsoft.EntityFrameworkCore.Sqlite (opcional)
	- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
	- dotnet add package Microsoft.EntityFrameworkCore.Design
	- dotnet add package Microsoft.EntityFrameworkCore.Tools
	- dotnet add package Microsoft.Extensions.Configuration
	- dotnet add package Microsoft.Extensions.Configuration.Json
  
## Ejecutar comandos, Entity Famework 

>Ejecute los siguientes comandos en un shell o cmd (raíz del proyecto)

- cd 1-Presentation/api/  
- dotnet ef migrations add CarDBExample -p ../../4-Infrastructure/4-Infrastructure.csproj
- dotnet ef database update
 
## Instalar NuGet 
>Ejecute los siguiente comando en un shell o cmd (raíz del proyecto)

- cd 1-Presentation/api/  
- dotnet add package Newtonsoft.Json 
  
# Paso III
> Con este paso podrá implementar [GraphQL](https://graphql.org/) en la capa de presentación. 
[Documentación de apoyo](https://graphql-dotnet.github.io/docs/getting-started/introduction)

## Api GraphQL
>Ejecute los siguientes comandos en un shell o cmd (raíz del proyecto)
[Repositorio guía](https://github.com/thedull/GraphQLWorkshop/tree/0_1_Initial)

**Crear servidor GraphQL**
- cd 1-Presentation
- md api_graph_ql
- cd api_graph_ql
- md server
- cd server
- dotnet new web
- cd .. cd .. cd .. (Regresar a la carpeta raíz)
- dotnet sln DDD.NET.CORE.sln add 1-Presentation/api_graph_ql/server/server.csproj 
- Crear en la raiz del directorio nuget.config
```

<configuration>

<packageSources>

<add key="graphql-dotnet" value="https://myget.org/F/graphql-dotnet/api/v3/index.json" />

</packageSources>

</configuration>

```
**Crear cliente GraphQL**
- cd 1-Presentation/api_graph_ql
- md Issues
- cd Issues
- dotnet new classlib
- cd .. cd .. cd .. (Regresar a la carpeta raíz)
- dotnet sln DDD.NET.CORE.sln add .\1-Presentation\api_graph_ql\Issues\Issues.csproj 

## Instalar NuGet 
>Ejecute los siguientes comandos en un shell o cmd (raíz del proyecto)

**Servidor GraphQL**
- cd 1-Presentation\api_graph_ql\server\

- dotnet add package GraphQL.Server.Transports.AspNetCore --version 2.0.0

- dotnet add package GraphQL.Server.Transports.WebSockets --version 2.0.0

- dotnet add package Microsoft.AspNetCore.StaticFiles --version 2.1.1
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- dotnet add package Microsoft.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- dotnet add package Microsoft.Extensions.Configuration
- dotnet add package Microsoft.Extensions.Configuration.Json
- cd ..  (Regresar a la carpeta padre)

**Cliente GraphQL**
- cd Issues
- dotnet add package GraphQL --version 2.1.0
- dotnet add package System.Reactive --version 3.1.1
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- dotnet add package Microsoft.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer

## Agregando referencias 
>Ejecute los siguientes comandos en un shell o cmd (raíz del proyecto)

**Servidor GraphQL**
- cd 1-Presentation\api_graph_ql\server\
- dotnet add server.csproj reference ../../../3.1-Domain.Entities/3.1-Domain.Entities.csproj ../../../2-Application/2-Application.csproj ../../../4-Infrastructure/4-Infrastructure.csproj
- cd ..  (Regresar a la carpeta padre)

**Cliente GraphQL**
- cd Issues
- dotnet add reference ../Issues/Issues.csproj
- dotnet add Issues.csproj reference ../../../3.1-Domain.Entities/3.1-Domain.Entities.csproj ../../../2-Application/2-Application.csproj ../../../4-Infrastructure/4-Infrastructure.csproj

## Probar GraphQL

>Ejecute los siguientes comandos en un shell o cmd (raíz del proyecto)
- dotnet build
- dotnet run -p .\1-Presentation\api_graph_ql\server\
>Pegue el siguiente código en el [cliente del servidor GraphQL](https://localhost:5001)

>Documentación de apoyo [Queries y Mutations](https://graphql.github.io/learn/queries/) 

**Ejemplo para consultas y persistencia**
[Rama del proyecto GraphQL_CreatedRead](https://github.com/gonzaloperezbarrios/DDD-NET-CORE/tree/GraphQL_CreatedRead)

```
mutation createCar($car: CarInput!) {
  createCar(car: $car) {
    ...myCar
  }
}

query getCars {
  carros {
    ...myCar
  }
}

query getCar {
  carro(id: 2005) {
   ...myCar
  }
}

fragment myCar on CarType {
  id
  name
  engine
  model
}
```
**Query Variables**
```
{
  "car": 
  {      
    "name":"graphName",
    "engine":"graphEngine",
    "model": "2018"   
  }
}
```
**Ejemplo para actualizar datos**
[Rama del proyecto GraphQL_CreatedReadUpdate](https://github.com/gonzaloperezbarrios/DDD-NET-CORE/tree/GraphQL_CreatedReadUpdate)
```
mutation updateCar($update: CarInputUpdate!){
  updateCar(update: $update){
    ...myCar
  }
}

query getCars {
  carros {
    ...myCar
  }
}
```
**Query Variables**
```
{
  "update": {
    "id": 3,
    "name": "graphNameUpdate",
    "engine": "graphEngineUpdate",
    "model": "2019"
  }
}
```