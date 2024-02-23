using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Auth;

using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace MotorPool.UI.Areas.Identity.Pages.Account;

public class LoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<LoginModel> logger) : PageModel
{

    [BindProperty]
    public InputModel Input { get; set; } = default!;


    public IList<AuthenticationScheme> ExternalLogins { get; set; } = default!;


    public string ReturnUrl { get; set; } = string.Empty;


    [TempData]
    public string ErrorMessage { get; set; } = string.Empty;


    public class InputModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }

    public async Task OnGetAsync(string? returnUrl = null)
    {
        if (!string.IsNullOrEmpty(ErrorMessage)) ModelState.AddModelError(string.Empty, ErrorMessage);

        returnUrl ??= Url.Content("~/");

        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        if (!ModelState.IsValid) return Page();

        ApplicationUser? user = await userManager.FindByEmailAsync(Input.Email);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "User with this email does not exist.");
            return Page();
        }

        SignInResult result = await signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            logger.LogInformation("User logged in");
            return LocalRedirect(returnUrl);
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return Page();
    }

}