using FluentResults;
using IdentityServer.Contracts;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Services;

public class AuthManagerService : IAuthManager
{
    private readonly SignInManager<IdentityServerUser> _signInManager;
    private readonly ILogger<AuthManagerService> _logger;

    public AuthManagerService(SignInManager<IdentityServerUser> signInManager, ILogger<AuthManagerService> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    public async Task<Result> LoginAsync(string email, string password)
    {
        // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            _logger.LogError("Invalid login attempt");
            return Result.Fail("Invalid login attempt.");
        }
        
        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        var result = await _signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            _logger.LogInformation("User logged in");
            return Result.Ok();
        }
        if (result.IsLockedOut)
        {
            _logger.LogWarning("User account locked out");
            return Result.Fail("User account locked out.");
        }
        else
        {
            _logger.LogError("Invalid login attempt");
            return Result.Fail("Invalid login attempt.");
        }
    }

    public async Task<Result> LogoutAsync()
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation("User logged out.");
        
        return Result.Ok();
    }
}