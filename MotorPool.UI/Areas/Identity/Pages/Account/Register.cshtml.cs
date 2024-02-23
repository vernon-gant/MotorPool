using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Auth;

namespace MotorPool.UI.Areas.Identity.Pages.Account;

public class RegisterModel(
    UserManager<ApplicationUser> userManager,
    IUserStore<ApplicationUser> userStore,
    SignInManager<ApplicationUser> signInManager,
    ILogger<RegisterModel> logger)
    : PageModel
{

    [BindProperty]
    public InputModel Input { get; set; } = default!;


    public string? ReturnUrl { get; set; }


    public IList<AuthenticationScheme> ExternalLogins { get; set; } = new List<AuthenticationScheme>();


    public class InputModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }


    public async Task OnGetAsync(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;
        ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        if (!ModelState.IsValid) return Page();

        ApplicationUser? user = await userManager.FindByEmailAsync(Input.Email);

        if (user != null)
        {
            ModelState.AddModelError(string.Empty, "User with this email already exists.");
            return Page();
        }

        user = new ApplicationUser
        {
            UserName = Input.UserName,
            Email = Input.Email
        };

        IdentityResult result = await userManager.CreateAsync(user, Input.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            return Page();
        }

        logger.LogInformation("User created a new account with password");

        await signInManager.SignInAsync(user, isPersistent: false);

        return LocalRedirect(returnUrl);
    }

}