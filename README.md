## Table of contents
* [Repository Contents](#repo-contente)
* [Technologies](#technologies)
* [Architecture](#architecture)
* [Features in Tech Stack](#architecture)
* [Setup](#setup)
* [SSL Cert](#SSL)

## What this repo contains
This system is architectured to be loosley coupled with a seperation of concerns.
The repo contains 2 seperate projects, and some files namely:
* Angular 11 project (Front End)
* Web API Core 5 (Backend)
* ERD (In its own folder)
* Typescript object file that is referenced to generate dummy DB data in the DB on the fly.
	
## Technologies
Project is created with:
* Web API Core 5
* Angular 11
* Toastr
* C#
* Font Awesome
* Bootstrap 5
* JWT Web Tokens
* AutoMapper
* SQL Server
* EF Core 6
* Postman
* Resharper
* VS Code and Visual Studio
* Swashbuckle for API documentation

## Design Patterns Used:
* Repository pattern with IUnitOfWork and a N-tier architecture on the Web API.
* Based on past experience, systems such as an online store, can grow very quickly, and it is essential to ensure as little tight coupling from the start as possible.
* The repository pattern is one of my favourite patterns that I have been using over the years in my projects. It makes it so easy to just unplug or plug in new functionality. * These days pluging in service layers is becoming very common place in projects, therefore a solution needs to be setup in such a way that it can be scaled and remain stable with all the new improvements it is experiencing.
* With .NET Core, Dependancy Injection is now built in by default. This makes life even easier as we are now being encouraged to follow these best practices by frameworks such as .NET Core and Angular as well. Angular also uses a lot of DI to keep things seperated, however the component driven framework helps us build even morecomplex systems with a lot more ease than standard MVC type projects. Anyway let me move on. 

## Features Used (Web API 5)
* Data Seeding - In .Net core this features enables us to automatically populate a database with test data, upon the setup of a new project. For this project, I have generated dummy data using an online tool, which returns JSON. That JSON is then loaded into a file and referenced upon program start when there is no data detected in the Database.
* Code first approach: With features such as eager loading, I can't see why I wasnt using this soon to join tables and retrieve data with ease.
* Dapper: In EF Core 6, there is no feature for using stored procs. What I do with Dapper is use it's dynamic parameters feature to convert a C# class model into parameters that SQL Server will understand. The response from these store procedures is then mapped to one of our domain models which are then accessed through the repository as is the case with EF using LINQ.
* Singleton pattern for injecting Repos such as Email sending classes where you only want no more than one instance of the class being created in the system.
* Built in JSON Parser, so no need to use NewtonSoft sicne .Net Core 3.1.
* Task class for asynchronous programming on code that interacts with the DB and could end up taking a while or struggling being run synchronously.
* AutoMapper: One of the best practices I like to follow, is using DTO classes when it comes to exposing data to our clients. The saying goes "Never expose you Domain Models to the outside world" as this could give hackers more insight into where the loopholes in your system could be. We seperate our Domain and API layer. However we need to map the properties which is time consuming. This is one of the main features I use in Automapper. There are many more other features as well.
* JWT (JSON Web Tokens) - One of the nice features in .Net Core is the JWT feature. Long gone are the days when a server had to authenticate each user by having to establish DB cnnections. As we are dealing with a stateless technology such as Web API, all that happens is the user is authenticate against the DB once. Once approved they are then assigned a token which they can store however they wish. This token has a specific validity period and for Authorized endpoints, may need to be passed in the headers when calling those APIs. This opens up a whole world of opportunities for us to scale.
* Global Exception handling: Gone are the days when you had to write a try/catch statement around as much code as you could. With .Net Core and DI, it's been made a lot more simple to make it a habit to implement exception handling and inject it as Middleware in our Middleware pipeline. This means that logs are created from one point and reduces the risk of maybe not catching all your errors. Errors are then formatted and returned in a professional and neat JSON format.

## Fetures Used (Angular 11)
* Route Gaurds to manage access to certain areas or componets in the application on the front end only.
* Observables to ensure that all areas of the software are updated when a value changes in one place. Reminds me of the Observer pattern from my University day.
* RXJS
* Reactive forms: These come in handy as they are reusable and easy to configure an tweak.
* Services and DI into components for use there.
* HTTP Interceptors: I use this to intercept my http requests and append the bearer token from one central location. This means that my bearer token is always sent through without having to push it through idependently from each service to the API which gets messy.
* Can Deactivate Gaurds: If a user is filling in a form and they leave the and come back later, their form should still contain the same data. we use host listener for this. Someone can even try closing the Tab, and we can notify them before they make a fianl decision.
* 
## Setup
To run this project, install it locally using npm:

```
$ cd into the app folder for the Angular client.
$ ng serve
$ cd into Euromonitor.Api and open terminal. Type "dotnet watch run" this will run the API on a static port and automatically rebuild about each save.
$ Change the connection string in the appsettings.json file to your local or Azure SQL DB and run the API.
$ Data will be generated for you using the Data Seeding feature.

## SSL Certificate
* I have added this to the Angular client application for you. Install it and you'll be good to go as it is valid for another 30 years.

Thanks for reading. Kindly reach out of you have any questions for me.
 I would be glad to help.
 
 Kind Regards,
 Kieran Gajjar
 Passionate Software Developer
