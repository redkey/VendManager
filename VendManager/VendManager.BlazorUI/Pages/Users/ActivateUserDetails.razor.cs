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

        private User user = new();
        private Services.Base.UserDetails users = new();

        // private AnotherModel anotherModel = new AnotherModel();

        protected override async Task OnInitializedAsync()
        {
            user = await IUserService.GetUsersDetails(Id);
        }

        private async Task ActivateUser()
        {
            isSubmitting = true;
            StateHasChanged();

            try
            {

               
                var user = await IUserService.GetUsersDetails(Id);
                var aspNetUser = new User { Id = Id , Email = user.Email , FirstName = user.FirstName , LastName = user.LastName};
                var userDetails = new Services.Base.UserDetails { EmailNotificationIntervalMinutes = EmailNotificationIntervalMinutes, EmailNotificationOnlyOutStockPeriodMinutes = EmailNotificationOnlyOutStockPeriodMinutes, SmsNotificationIntervalMinutes = SmsNotificationIntervalMinutes, SmSlNotificationOnlyOutStockPeriodMinutes = SmSlNotificationOnlyOutStockPeriodMinutes, EmailNotificationLastProcessedAtDateTimeUTC = DateTimeOffset.Now, SmSlNotificationLastProcessedAtDateTimeUTC = DateTimeOffset.Now, AspNetUserId = Id , AspNetUser = aspNetUser };
                await IUserService.ActivateUser(Id);
                await IUserService.CreateUserDetails(userDetails);
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


        private async Task SaveData()
        {
            // Save the data from anotherModel
            // await IUserService.SaveData(anotherModel);

            // Navigate to the desired page
            // NavigationManager.NavigateTo("/");
        }
    }
}