using DevExpress.Blazor.Popup.Internal;
using Microsoft.AspNetCore.Components;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Models;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Pages.Users
{
    public partial class ViewUsers
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IClient Client { get; set; }

        [Inject]
        public IUserManagementService UserManagementService{ get; set; }

        public List<User> Users { get; set; }

        public string Username { get; set;}

        private bool isLoading = true;
        bool Visible { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public string SelectedUserId { get; set; } 
        protected void CreateMachine()
        {
            NavigationManager.NavigateTo("/machines/create");
        }

        public async Task  DeleteUser()
        {   
            if(String.IsNullOrEmpty(SelectedUserId))
            {
                Message = "Please select a user to delete";
                return;
            }

            Visible = false;
            UserManagementService.DeleteUserDetails(SelectedUserId);
            await FetchUsers();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var users = await Client.UsersAsync();
                Users = users.ToList();
                isLoading = false; // Set loading to false after data retrieval
                StateHasChanged(); // Notify the component to re-render
            }

         
        }
        protected void NavigateToDetails(long machineId)
        {
            NavigationManager.NavigateTo($"/machines/details/{machineId}");
        }

        protected void DeactivateUser(string userId)
        {
            //Visible = true;
            UserManagementService.DeleteUserDetails(userId);
            StateHasChanged(); // Notify the component to re-render
           // NavigationManager.NavigateTo($"/viewusers");
        }

        protected void DeactivateUserTest(bool state, string userId)
        {
            Visible = true;
            SelectedUserId = userId;    

        }

        private async Task FetchUsers()
        {
            isLoading = true;
            // Fetch users data from the server
            var users = await Client.UsersAsync();
            Users = users.ToList();
            isLoading = false;
        }



    }
}