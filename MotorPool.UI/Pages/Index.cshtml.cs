using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MotorPool.UI.Pages;

public class Index : PageModel
{

    public void OnGet()
    {
        if (User.Identity is { IsAuthenticated: false })
        {
            Response.Redirect("/Identity/Account/Login");
        }
    }

}