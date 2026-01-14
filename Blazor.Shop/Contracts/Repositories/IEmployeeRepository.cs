using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Contracts.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    
    Task<Employee> GetEmployeeByIdAsync(int employeeId);
    
    Task<Employee> AddEmployeeAsync(Employee employee);
    
    Task<Employee> UpdateEmployeeAsync(Employee employee);
    
    Task DeleteEmployeeAsync(int employeeId);
}
