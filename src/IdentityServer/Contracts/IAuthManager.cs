using FluentResults;

namespace IdentityServer.Contracts;

public interface IAuthManager
{
    Task<Result> LoginAsync(string email, string password);
    Task<Result> LogoutAsync();
}