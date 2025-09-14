using System.ComponentModel.DataAnnotations;
using IdentityServer.Contracts;

namespace IdentityServer.Endpoints;

public static class PostLogin
{
    public static async Task<IResult> HandleAsync(PostLoginRequest request, IAuthManager authManager)
    {
        var loginResult = await authManager.LoginAsync(request.Email, request.Password);
        
        if(loginResult.IsFailed)
            return Results.BadRequest(loginResult.Errors);
        
        return Results.Ok();
    }
}

public class PostLoginRequest
{
    [Required]
    public required string Email { get; init; }
    [Required]
    public required string Password { get; init; }
}