# Clean architecture Demo in ASP.NET MVC Core 3.1

This is a use case demo for implementing Clean Architecture (Onion Architecture) in ASP.NET MVC Core 3.1

## Project Use Case

It's a very simple Library management system concept.
The logged in user which we suppose is a librarian, can add, remove and edit Books and Readers,
also can Loan book to a Reader and Return alredy loaned book.

## Principle, Patterns and external libraries used.

1. Clean (Onion) project architecture with Domain Driven Design aand SOLID principles.
2. ASP.NET Core Dependency Injection
3. Repository Pattern
4. Automapper
5. Logging with Serilog
6. Select2 on the Frontend for dynamicaly loading items from database.

## Installation

1. Download the code
2. Build the solution
3. Run: dotnet ef database update
4. Run the Web.MVC project

## ToDO

1. Unit Testing
2. Repository pattern with Unit of Work
3. Data anotations and model validation
4. Better handling of the business logic, since this is only a concept.

## References 

1. https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/
2. https://www.codewithmukesh.com/project/aspnet-core-webapi-clean-architecture/
3. https://medium.com/@nishancw/clean-architecture-net-core-part-2-implementation-7376896390c5
