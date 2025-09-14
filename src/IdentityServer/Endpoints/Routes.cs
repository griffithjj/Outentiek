namespace IdentityServer.Endpoints;

public static class Routes
{
    public static IEndpointRouteBuilder MapIdentityServer(this IEndpointRouteBuilder app)
    {
        app.MapGet("/identityserver", () => "identityserver");
        app.MapPost("/login", PostLogin.HandleAsync);
        app.MapPost("/logout", PostLogout.HandleAsync);
        return app;
    }
}