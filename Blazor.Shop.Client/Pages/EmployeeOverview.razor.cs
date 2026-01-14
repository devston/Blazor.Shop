using Blazor.Shop.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace Blazor.Shop.Client.Pages;

public partial class EmployeeOverview
{
    public List<Employee> Employees { get; set; } = default!;
    private Employee? _selectedEmployee;

    private string Title = "Employee overview";
    private string Description = "employee overview";

    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Employees = (await EmployeeDataService.GetAllEmployeesAsync()).ToList();
    }

    public void ShowQuickViewPopup(Employee selectedEmployee)
    {
        _selectedEmployee = selectedEmployee;
    }
}
