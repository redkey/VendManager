namespace VendManager.BlazorUI.Pages.Users
{
    public partial class ViewUsers
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
                if (true)
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