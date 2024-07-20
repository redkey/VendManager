using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;




namespace RouterManagerServer.UI.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {

        public RegisterModel()
        {
          
        }
        [BindProperty]
        public InputModel Input { get; set; }   
        public string ReturnUrl { get; set; }
        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        
        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string CustomerName { get; set; }
            public bool KeepSignedIn { get; set; }

        }
    }
}
