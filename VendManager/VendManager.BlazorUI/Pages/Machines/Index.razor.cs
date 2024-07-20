using Microsoft.AspNetCore.Components;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Models;

namespace VendManager.BlazorUI.Pages.Machines
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMachineService MachineService { get; set; }

        public List<MachineVM> Machines { get; set; }

        public string Message { get; set; } = string.Empty;
        protected void CreateMachine()
        {
            NavigationManager.NavigateTo("/machines/create");
        }

        protected override async Task OnInitializedAsync()
        {
            Machines = await MachineService.GetAllMachinesWithSensorDetails();
          
        }

    
    }
}