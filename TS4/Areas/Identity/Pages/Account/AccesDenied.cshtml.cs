using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TS4.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class AccesDeniedModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
