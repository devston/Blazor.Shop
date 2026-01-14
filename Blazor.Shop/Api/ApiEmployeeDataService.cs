using Blazor.Shop.Contracts.Api;
using Blazor.Shop.Contracts.Repositories;
using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Api;

public class ApiEmployeeDataService: IApiEmployeeDataService
{
    private readonly IEmployeeRepository _employeeRepository;

    public ApiEmployeeDataService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return (await _employeeRepository.GetAllEmployeesAsync()).OrderByDescending(i => i.EmployeeId);
    }
}
