using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Contracts.Api;

public interface IApiEmployeeDataService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}