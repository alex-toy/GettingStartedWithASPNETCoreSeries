# Getting Started With ASP.NET Core Series

## Middleware

Middleware is a component assembled into an app pipeline to handle requests and responses. Middlewares are chained one after the other, so each of them gets to chose whether to pass the request to the next component and also perform work before and after the next component in the pipeline. In this project, we will use middlewares in an ASP.NET Core application, set up middleware, set up a request pipeline using them. We will explore the different options of setting up the middleware using the Run, Use and Map methods. We will also create a custom middleware using the IMiddleware interface and look at some of the practices around creating them.

## Dependency Injection

ASP NET Core provides a built-in service container, IServiceProvider. Services are registered in the app's Startup.ConfigureServices method.  The framework takes the responsibility of creating and managing the lifetime of the dependency object.

In this project, we will use the default Dependency Injection container shipped with ASP NET Core to manage dependencies. We will see the different ways of registering services to the container, understand more about the lifetime scopes in the container. We will see the differences between Transient, Scoped, and Singleton lifetime scopes and how to register and use them in the application.

### Queue

- create a storage account

- in the *Queues* section of the storage account, create a queue
<img src="/pictures/queue.png" title="queue storage account"  width="900">
