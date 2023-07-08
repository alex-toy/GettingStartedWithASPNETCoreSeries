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
