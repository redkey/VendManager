using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace RouterManagerServer.UI.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
       

        public LoginModel()
        {
           
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

      
        

        private bool IsLoading { get; set; } = false;
        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public bool KeepSignedIn { get; set; }

        }
    }
}
