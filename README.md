# Getting Started With ASP.NET Core Series

## Middleware

Middleware is a component assembled into an app pipeline to handle requests and responses. Middlewares are chained one after the other, so each of them gets to chose whether to pass the request to the next component and also perform work before and after the next component in the pipeline. In this project, we will use middlewares in an ASP.NET Core application, set up middleware, set up a request pipeline using them. We will explore the different options of setting up the middleware using the Run, Use and Map methods. We will also create a custom middleware using the IMiddleware interface and look at some of the practices around creating them.


## Dependency Injection

ASP NET Core provides a built-in service container, IServiceProvider. Services are registered in the app's Startup.ConfigureServices method.  The framework takes the responsibility of creating and managing the lifetime of the dependency object.

In this project, we will use the default Dependency Injection container shipped with ASP NET Core to manage dependencies. We will see the different ways of registering services to the container, understand more about the lifetime scopes in the container. We will see the differences between Transient, Scoped, and Singleton lifetime scopes and how to register and use them in the application.

<img src="/pictures/scopes.png" title="scopes"  width="900">


## Configuration in ASP.NET Core

 The .NET Framework, through configuration files, gives developers and administrators control and flexibility over the way applications run. Developers can put settings in configuration files, eliminating the need to recompile an application every time a setting changes. Configuration in ASP NET is performed using one or more configuration providers. Configuration providers read configuration data from key-values using a variety of config sources. In this project, we will configure values in ASP NET Core, read it in your application, set up default configuration providers and write customer configuration providers.

### Secret Manager
```
dotnet user-secrets init --project <project_name>
dotnet user-secrets set "myAPI:apiKeyTopSecret" "Top secret API Key" --project <project_name>
```


## Loggin in ASP.NET Core

Logging is an integral part of software development. .NET Core supports logging API that works with a variety of built-in and third-party logging providers. Logging providers mostly store logs except for a few like Console, which displays logs. In this project, we will see the built-in logging providers, how they are configured, and how you to use them for your applications. We will also see how to set up logging configuration, to control the logs that get written for different environments.

### Install Packages
```
Seq.Extensions.Logging
```


## Routing in ASP.NET Core

Routing is responsible for matching incoming HTTP requests and dispatching those requests to the app's executable endpoints. Endpoints are units of executable code that handles requests coming to the application. Endpoints are defined and configured when the app starts. In this project, we will learn about the basics of routing and how it builds over the middleware pipeline in ASP NET Core. We will see how to define endpoints, how URLs are formed and routed. We will also see the route templates and how to add constraints to routes. We will also see how some of these core concepts translate to API Controllers and how to use them there as well.


## Model Binding in ASP.NET Core

Route data may provide a record key, and posted form fields may provide values for the properties of the model. Writing code to retrieve each of these values and convert them from strings to .NET types would be tedious and error-prone. Model binding automates this. In this project, we will study Model Binding in ASP NET Core, how it works, and how to customize it to meet our needs. We will walk through how to bind primitive types, complex types, how to bind data from the request body (JSON and XML formats).

### Install Packages
```
Microsoft.AspNetCore.Mvc.Formatters.Xml
```
- send json data
<img src="/pictures/data.png" title="json data"  width="900">

- send xml data
<img src="/pictures/data2.png" title="xml data"  width="900">


## Model Validation in ASP.NET Core

Validating user input is an important part of application development. ASP NET Core provides some built-in mechanisms for validating user input. In this project, we will see how to validate user input for Web API Controllers. This is also applicable to Razor Pages app. We will use ModelState, data annotation attributes, create custom attributes, and also add class level validations for model classes.

- valid data
<img src="/pictures/validation.png" title="validate data"  width="900">

- unvalid data
<img src="/pictures/validation1.png" title="validate data"  width="900">

- unvalid data
<img src="/pictures/validation2.png" title="validate data"  width="900">

- custom validation data
<img src="/pictures/validation3.png" title="validate data"  width="900">

- custom validation data using *IValidatableObject*
<img src="/pictures/validation4.png" title="validate data"  width="900">


## Model Validation in ASP.NET Core

Filters in ASP.NET Core allow code to be run before or after specific stages in the request processing pipeline. There are built-in filters like Authorization and Response Caching. You can also write Custom Filters to handle cross-cutting concerns like error handling, caching, configuration, authorization, logging, etc. Filters avoid duplicating code and consolidating functionality into a single place. In this project, we will study Filters in ASP NET Core, how they work, how to set it in the request pipeline by creating custom filters. We will study Synchronous and Asynchronous Filters and how they work. We will also study the different scopes that filters can be applied and how the ordering of it works. We will then study more about different types of Filter (Authorization Filter, Resource Filter, Action Filter, Exception Filter, and Result Filters). We will also see the different ways you can inject dependencies into Filter Attributes. Dependency Injection in Filters is supported via *ServiceFilterAttribute* and *TypeFilterAttribute*. Finally, we will see short-circuiting in filters and how you can easily get out of the whole filter pipeline.


## Error Handling in ASP.NET Core

Exception handling or error handling is an important aspect of building applications. However much we want our applications to work fine, there will always be some unexpected cases. It's important that we handle these scenarios and return back appropriate messages. This is no different when building our APIs. In this project, we will study exception handling in ASP NET Core Applications and the different ways we can handle them. We will also see how to set up global error handling and the required middleware for that.


## Layering in ASP.NET Core

As applications grow in complexity one way to manage that is to break it up according to various responsibilities or concerns. Following this Separation of concerns principle, helps organize the codebase. It organizes code into different layers, and you might be familiar with this pattern by the name of  N-tier, N-Layer, or Layered architecture in general. In this project, we will explore a simple scenario of such an example, why this happens, and what we are doing wrong. We will then see a guiding principle, the Dependency Inversion Principle, a golden rule that you can follow when separating your code into different layers, folders, or applications. The core design principles of *Dependency Inversion* and *Ownership inversion* guide you in managing the dependency flow. It also serves as a guide to organize code into different projects.