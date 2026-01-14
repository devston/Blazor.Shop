using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Contracts.Repositories;

public interface ITimeRegistrationRepository
{
    Task<List<TimeRegistration>> GetTimeRegistrationsForEmployeeAsync(int employeeId);
    
    Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployeeAsync(int employeeId, int pageSize, int start);
    
    Task<int> GetTimeRegistrationCountForEmployeeIdAsync(int employeeId);
}
