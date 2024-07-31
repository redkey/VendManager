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

        public List<User> Users { get; set; }

        private bool isLoading = true;

        public string Message { get; set; } = string.Empty;
        protected void CreateMachine()
        {
            NavigationManager.NavigateTo("/machines/create");
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

    }
}