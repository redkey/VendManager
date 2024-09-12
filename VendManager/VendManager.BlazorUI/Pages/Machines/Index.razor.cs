using Microsoft.AspNetCore.Components;
using Serilog;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Models;

namespace VendManager.BlazorUI.Pages.Machines
{
    public partial class Index
    {

        //public Index(ILogger<Index> logger)
        //{
        //    _logger = logger;
        //}
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMachineService MachineService { get; set; }

        private string userRole;

        public List<MachineVM> Machines { get; set; }

        private bool isLoading = true;
     //   private readonly ILogger<Index> _logger;

        public string Message { get; set; } = string.Empty;
        protected void CreateMachine()
        {
            NavigationManager.NavigateTo("/machines/create");
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    Machines = await MachineService.GetAllMachinesWithSensorDetails();
        //    isLoading = false; // Set loading to false after data retrieval

        //}
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
               // _logger.LogInformation("Getting All Machines");
                Log.Information("Getting All Machines");

                // Fetch user role
                userRole = await UserService.GetRoleAsync();

                Machines = await MachineService.GetAllMachinesWithSensorDetails();
                isLoading = false; // Set loading to false after data retrieval
                StateHasChanged(); // Notify the component to re-render
            }
        }
        protected void NavigateToDetails(long machineId)
        {
            NavigationManager.NavigateTo($"/machines/details/{machineId}");
        }

        private void NavigateToEdit(long machineId)
        {
            NavigationManager.NavigateTo($"/machines/edit/{machineId}");
        }


    }
}