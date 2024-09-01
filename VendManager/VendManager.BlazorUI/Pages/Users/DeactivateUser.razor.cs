using Microsoft.AspNetCore.Components;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Services;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Pages.Users
{   
    public partial class DeactivateUser
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IClient Client { get; set; }

        [Inject]
        public IUserManagementService UserManagementService { get; set; }

        public List<User> Users { get; set; }
        public string SelectedUserId { get; set; }

        private bool isLoading = true;
        bool Visible { get; set; } = false;

        public string Message { get; set; } = string.Empty;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var users = await Client.DeletedusersAsync();
                Users = users.ToList();
                isLoading = false; // Set loading to false after data retrieval
                StateHasChanged(); // Notify the component to re-render
            }
        }

        protected void ActivateUser(bool state,string userId)
        {
            Visible = true;
            SelectedUserId = userId;

        }


        public async Task ActivateUser()
        {   
            if (String.IsNullOrEmpty(SelectedUserId))
            {
                Message = "Please select a user to delete";
                return;
            }

            Visible = false;
            await UserManagementService.UnDeleteUser(SelectedUserId);
            NavigationManager.NavigateTo($"/viewusers");

        }


        private void CreateUser()
        {
            NavigationManager.NavigateTo("/createuser");
        }
    }
}