# Dependency Injection Lifetime

Dependency injection is an important technique in application programming in general and in asp.net core in particular. Dependency injection helps reduce the dependence of classes on each other while initializing them. 

![](https://mindmup-export.s3.amazonaws.com/map.png/out/f7346b4089ac11eb9467155a5728b495.map.png?AWSAccessKeyId=ASIASNCK5ADR2XFHRNWN&Expires=1616359753&Signature=cIOXXhoA5flfiMeUdQYRLOz%2F5Rc%3D&x-amz-security-token=IQoJb3JpZ2luX2VjEEEaCXVzLWVhc3QtMSJIMEYCIQCu4rLmBFaVQXzNXWfHx76%2FFwAW1LuT7SspoMmyfseWawIhAIXTLl%2BGlzy0TNJzulXmAf572xIaHF%2FDoMui05w%2B%2B%2FU4Ks8BCHoQABoMMTY1NTEzMzMwOTE1IgxVfby2iXkYSUrIbRYqrAFDwgwPjons2TyKcQOmpPcwqYembQm1km8WI79qf2C60VK%2BPtfeyLftoPI7OPl4KNJoh8G8HSvycqaM9gTRWa7fuuStmLDUMdXH5jA9bJnCsplyuE3zUlFJHNLRZVSD433B3%2B%2FMqyPIfpCp8R%2ByvEnIVmUUpwV%2BizW3uIyHFccQAc6H%2B%2F39v08e5k1z%2BOr8nFt7qGhrXMj2VNcS7s9z3VmIOWNhICI5Aue05vUiMPbN2IIGOt8BPqNQTSiKbX46Fwu%2Fs0T%2FzM33em5Gkm46nmzSqcctKzirVjGaAYRr1zT4X5ylYQUrvmiuxFg2cWd%2BWCji%2BtWnP4hOCkAi7%2FtuQhPfRTN4sLQ0mH2i0G%2BGv%2FxhBf5cvg%2BMfe38lGz%2FodzQUiQL4%2Fu2FSVKJG3LOPM9Bdf7nt5U3VYq9TPNw2zQLUebmMMfN7%2BrLOQtx3nPtefDevI1Hvv2MkJs0P1Nf46yGIUVJuq58PBrUghIWRSicjEibqaShin4od%2B1id7wySkf0wQuCB%2BBQneIoS95IkobJfIKF0YtUg%3D%3D)

# Usage

After cloning this repository and installing [Visual Studio](https://visualstudio.microsoft.com/tr/downloads/) enter the project's folder through the command line and type the following code to run the program:
`dotnet run`

## Dependencies
- [.Net5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Microsoft.EntityFrameworkCore5.0.3](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
- [Swashbuckle.AspNetCore5.6.3](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Swagger/)



## Service Life Times

1.  **Transient** services are created each time they are injected or requested.
2.  **Scoped** services are created per scope. In a web application, every web request creates a new separated service scope. That means scoped services are generally created per web request and they are destroyed after the request finalize. An HTTP is a stateless protocol therefore the values of form data would be available for the current request. it will refresh on every request of the same user/different user.
3.  **Singleton** services are created per DI container. Generally means that they are created only one time per application and then used for whole the application life time. So what should be a singleton? Singleton should be used in cases where limited resources are available. For example, we have a WebSocket connection. If a new socket is created in every request, socket (io) - our source Outgoing TCP connections are limited by port numbers ~ 65000 per IP- will run out over time and we cannot provide service. Instead, a socket pool is created and this socket pool is made singleton. When the call comes, a socket is given from this pool, and when the job is finished, it is thrown into the pool again.

## Best Practices

-   Register your services as **transient** wherever possible. Because it’s simple to design transient services. You generally don’t care about **multi-threading** and **memory leaks** and you know the service has a short life.
-   Use  **scoped** service lifetime  **carefully** since it can be tricky if you create child service scopes or use these services from a non-web application.
-   Use  **singleton** lifetime carefully since then you need to  **deal** with  **multi-threading**  and potential  **memory leak**  problems.
-   **Do not depend**  on a transient or scoped service from a singleton service. Because the transient service becomes a singleton instance when a singleton service injects it and that may cause problems if the transient service is not designed to support such a scenario. ASP.NET Core’s default DI container already throws  **exceptions** in such cases.

## Referances
- https://medium.com/volosoft/asp-net-core-dependency-injection-best-practices-tips-tricks-c6e9c67f9d96
- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore
- https://www.tektutorialshub.com/asp-net-core/asp-net-core-dependency-injection-lifetime/
- https://stackoverflow.com/questions/46413431/what-is-the-difference-between-request-and-session-scope-in-spring
