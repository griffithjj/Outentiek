using IdentityServer.Contracts;

namespace IdentityServer.Endpoints;

public static class PostLogout
{
    public static async Task<IResult> HandleAsync(IAuthManager authManager)
    {
        var logoutResult = await authManager.LogoutAsync();

        if (logoutResult.IsFailed)
            return Results.BadRequest(logoutResult.Errors);

        return Results.Ok();
    }
}