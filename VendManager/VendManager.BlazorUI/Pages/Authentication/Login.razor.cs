using Microsoft.AspNetCore.Components;

namespace VendManager.BlazorUI.Pages.Authentication
{
    public partial class Login
    {
        private string username;
        private string password;
        private string Message;
        private bool isSubmitting = false;

        private async Task SignIn()
        {
            isSubmitting = true;
            StateHasChanged();
            try
            {
                if (await AuthenticationService.AuthenticateAsync(username, password))
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    Message = "Invalid username or password.";
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                isSubmitting = false;
                StateHasChanged();
            }
        }

        private void CreateAccount()
        {
            // Handle account creation logic here
        }
    }
}