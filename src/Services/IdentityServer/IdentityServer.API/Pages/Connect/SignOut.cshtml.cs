using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServer.API.Pages.Connect;

public class SignOutModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<SignOutModel> _logger;

    public SignOutModel(SignInManager<IdentityUser> signInManager, ILogger<SignOutModel> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    public async Task<IActionResult> OnGet(string? post_logout_redirect_uri = null)
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation("User logged out.");

        var properties = new AuthenticationProperties
        {
            RedirectUri = post_logout_redirect_uri ?? "/Identity/Account/Login"
        };

        return SignOut(properties, CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public IActionResult OnPost(string? returnUrl = null)
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = Url.IsLocalUrl(returnUrl) ? returnUrl : "/Identity/Account/Login"
        };

        return SignOut(properties, CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
