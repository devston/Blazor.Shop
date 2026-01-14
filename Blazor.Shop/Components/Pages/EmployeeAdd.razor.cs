using Blazor.Shop.Client;
using Blazor.Shop.Services;
using Blazor.Shop.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace Blazor.Shop.Components.Pages
{
    public partial class EmployeeAdd
    {
        [SupplyParameterFromForm]
        public Employee Employee { get; set; }

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        protected string Message = string.Empty;
        protected bool IsSaved = false;

        protected override void OnInitialized()
        {
            Employee ??= new();
        }

        private async Task OnSubmit()
        {
            await EmployeeDataService.AddEmployeeAsync(Employee);
            IsSaved = true;
            Message = "Employee added successfully";

        }

    }
}
