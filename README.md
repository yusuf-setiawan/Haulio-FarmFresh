# FarmFresh (N-Tier Asp.Net Core MVC & JQuery)

## **Introduction**
This is a n-layer architecture Asp.NET Core MVC with Ajax JQuery.
Asp.NET Core MVC is for BackEnd, and JQuery is for Front End.

---

## Technologies
- ASP .NET Core 3.1 MVC & JQuery
- Entity Framework Core (SQL Server)
- AutoMapper
- Bootstrap 5.0
- JWT Authentication

---

## Features
- N-tier architecture
- Entity Framework Core (Code First) with generic repository pattern for data access layer
- Authentication with JWT Authentication
- Dependency Injection
- Server Side Pagination
- API for backend testable by Postman
  Endpoint :
  - Api/Authenticate (Authentication)
  - Api/Product (Get List of Products)
  - Api/Product/{ProductId} (Get Product by ProductId)

---

## Layers

- Haulio.FarmFresh.Entity - Database entities.
- Haulio.FarmFresh.DAL - Data Access Layer responsible for interacting database, it have generic repository pattern.
- Haulio.FarmFresh.DTO - Data transfer objects.
- Haulio.FarmFresh.BusinessLogic - Business Logic Layer responsible for data exchange between DAL and Presentation Layer.
- Haulio.FarmFresh.IoC - Responsible for *dependency injection* it has ```DependencyInjection``` class and ```InjectDependencies``` method in it.
- Haulio.FarmFresh.Utility 
   - Layer for All Utility in the Project
   - Has *AutoMapperProfiles* (You can get detailed information about *Automapper* from [here](https://automapper.org/)) class in it.
- Haulio.FarmFresh.Web - Presentation Layer *.Net Core MVC project*.

---

## Dependencies between projects

<div align="center">

![N-Tier-Dependencies](https://github.com/yusuf-setiawan/Haulio-FarmFresh/blob/main/diagram.png)

</div>

---

## **Getting Started**

- Select the 'Haulio.FarmFresh.Web' project as the startup project.
- Check the connection string in the appsettings.json file of the 'Haulio.FarmFresh.Web' project, change it if you want.
- Open Package Manager Console, Select the 'Haulio.FarmFresh.DAL' project as the default project. and run the **Update-Database** command to create your database.
- You need to be authorized for Search Product. 
  Please login first by click Triangle Button after Cart Image. 
  Credential : Username : *Haulio* , Password : *FarmFresh*

