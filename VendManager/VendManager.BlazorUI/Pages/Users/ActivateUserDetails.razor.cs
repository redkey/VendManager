using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Pages.Users
{
    public partial class ActivateUserDetails
    {

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IUserManagementService IUserService { get; set; }


        [Required]
        private int? EmailNotificationIntervalMinutes;
        [Required]
        private int? EmailNotificationOnlyOutStockPeriodMinutes;
        [Required]
        private int? SmsNotificationIntervalMinutes;
        [Required]
        private int? SmSlNotificationOnlyOutStockPeriodMinutes;
        private string Message;
        private bool isSubmitting = false;

        private VendManager.BlazorUI.Services.Base.User user = new();
        private VendManager.BlazorUI.Services.Base.UserDetails users = new();

        // private AnotherModel anotherModel = new AnotherModel();

        protected override async Task OnInitializedAsync()
        {
            user = await IUserService.GetUsersDetails(Id);
        }

        private async Task RegisterAdmin()
        {
            isSubmitting = true;
            StateHasChanged();

            try
            {

                //var adminCreateRequest = new RegistrationRequest { Email = username, FirstName = firstname, LastName = lastname, Password = password, Role = "Admin", Enabled = true };
                //await _client.RegisterAsync(adminCreateRequest);
                //NavigationManager.NavigateTo("/viewusers");



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


        private async Task SaveData()
        {
            // Save the data from anotherModel
            // await IUserService.SaveData(anotherModel);

            // Navigate to the desired page
            // NavigationManager.NavigateTo("/");
        }
    }
}