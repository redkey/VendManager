using System.ComponentModel.DataAnnotations;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Pages.Users
{
    public partial class CreateUser
    {

        [Required]
        private string username;
        [Required]
        private string firstname;
        [Required]
        private string lastname;
        [Required]
        private string password;
        private string Message;
        private bool isSubmitting = false;

        private async Task RegisterCustomer()
        {
            isSubmitting = true;
            StateHasChanged();  

            try
            {

                var adminCreateRequest = new RegistrationRequest { Email = username, FirstName = firstname, LastName = lastname, Password = password, Role = "Customer", Enabled = true };
                await _client.RegisterAsync(adminCreateRequest);
                NavigationManager.NavigateTo("/viewusers");



            }
            catch (Exception e)
            {
                Message = "Invalid operation please try again later.";
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