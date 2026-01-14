using Blazor.Shop.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace Blazor.Shop.Client.Components;

public partial class EmployeeCard
{
    [Parameter]
    public Employee Employee { get; set; } = default!;

    [Parameter]
    public EventCallback<Employee> EmployeeQuickViewClicked { get; set; }

    protected override void OnInitialized()
    {
        
    }
}
