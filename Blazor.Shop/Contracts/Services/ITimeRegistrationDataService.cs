using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Contracts.Services;

public interface ITimeRegistrationDataService
{
    Task<List<TimeRegistration>> GetTimeRegistrationsForEmployeeAsync(int employeeId);
    
    Task<int> GetTimeRegistrationCountForEmployeeIdAsync(int employeeId);
    
    Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployeeAsync(int employeeId, int pageSize, int start);
}
