# Dependency Injection Lifetime

Dependency injection is an important technique in application programming in general and in asp.net core in particular. Dependency injection helps reduce the dependence of classes on each other while initializing them. 

![Alt](https://mindmup-export.s3.amazonaws.com/map.png/out/1b5089e0751811ebb944d78e77ff7ea9.map.png?AWSAccessKeyId=ASIASNCK5ADR2LHC52MY&Expires=1614096796&Signature=5rNsuv79gHiI%2F08zj2nCMfi0DSc%3D&x-amz-security-token=IQoJb3JpZ2luX2VjEM3%2F%2F%2F%2F%2F%2F%2F%2F%2F%2FwEaCXVzLWVhc3QtMSJHMEUCIQDQUt5Rly4vXPzmA7cQ0bDjwTs5lxO5572mls1yGNmt1gIgTwpp%2Ffb585c80yi%2FC98fEckDQQYW58JWjD%2FIrJEmdq8q2AEI1f%2F%2F%2F%2F%2F%2F%2F%2F%2F%2FARAAGgwxNjU1MTMzMzA5MTUiDN39MNZ6s9yElcwhkCqsAaDH0Lgtu91PgIB%2Fckc0tP2xELdbo%2FBohR%2Bn3XyR0XbRkcWlrs%2FbiuNmG1DdFN1B080gX89PocOavr48pGgE0BQY%2BTqWnVx9maujBqaJqqyTfJewsfqy6Yy%2BJKfMop0Y8QZ8jbuMfGtOcjtI%2Fskobae8owQwEj4VyMqRY053OMwWzQwOwXTsOCIzhQ2dB9SySwy4LGUK01sjb9jSuRnPqb9EbPajkWjAdbNH%2B7kwz8DOgQY64AGvv81Ct6QVa9tGPqmGyYRsqWCqFANTiRyL91FTXMeDxGFNRcLc6xeoCfoGrmISsMsLgI4%2FzzlwpM48cvQS46w%2B8w5zSrNIm2GB7WLRd63mBsQrwXYha2fPPehMHxkNRbcvJCMYNbpQo4jEa7XRrIXwQudrM5BIMzN8SArMiXQpUa8HNFjioHkWPICCbpHd%2FMGpU3JrCd2NZaZ0LxrHL%2FBgI58vpJv%2FWmOjfnM3%2BdzVqCglSMCTKMmsYmT0uvLCsnvD%2FNwHJO527dE1abLo96cp42A%2FpFbJbH3XIBjMTVXIog%3D%3D)

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
