using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Pages.Users
{
    public partial class AddAdmin
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




        private async Task RegisterAdmin()
        {
            isSubmitting = true;
            StateHasChanged();  
     
            try
            {
                
                var adminCreateRequest = new RegistrationRequest { Email = username, FirstName = firstname, LastName = lastname, Password = password , Role = "Admin" , Enabled = true};   
                await _client.RegisterAsync(adminCreateRequest);
                toastService.ShowSuccess($"Admin {firstname} successfully created");
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