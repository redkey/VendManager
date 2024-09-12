using Microsoft.AspNetCore.Components;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Pages.Users
{
    public partial class ActivateUser
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IClient Client { get; set; }

        public List<User> Users { get; set; }

        private bool isLoading = true;
        private string userRole;
        public string Message { get; set; } = string.Empty;
        protected void CreateMachine()
        {
            NavigationManager.NavigateTo("/machines/create");
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Fetch user role
                userRole = await UserService.GetRoleAsync();
                var users = await Client.DeactivatesusersAsync();
                Users = users.ToList();
                isLoading = false; // Set loading to false after data retrieval
                StateHasChanged(); // Notify the component to re-render
            }
        }
        protected void NavigateToDetails(string Id)
        {
            // NavigationManager.NavigateTo($"/user/details/{Id}");
            if (!string.IsNullOrEmpty(Id))
            {
                NavigationManager.NavigateTo($"/users/details/{Id}");
            }
            else
            {
                // Handle the case where Id is null or empty
                // For example, show an error message or log the issue
            }


        } 


        private void NavigateToEdit(string Id)
        {
            NavigationManager.NavigateTo($"/user/edit/{Id}");
        }
    }
}