using Blazor.Shop.Contracts.Repositories;
using Blazor.Shop.Contracts.Services;
using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Services;

public class TimeRegistrationDataService : ITimeRegistrationDataService
{
    private readonly ITimeRegistrationRepository _timeRegistrationRepository;

    public TimeRegistrationDataService(
        ITimeRegistrationRepository timeRegistrationRepository)
    {
        _timeRegistrationRepository = timeRegistrationRepository;
    }

    public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployeeAsync(int employeeId)
    {
        return await _timeRegistrationRepository.GetTimeRegistrationsForEmployeeAsync(employeeId);
    }

    public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployeeAsync(int employeeId, int pageSize, int start)
    {
        return await _timeRegistrationRepository.GetPagedTimeRegistrationsForEmployeeAsync(employeeId, pageSize, start);
    }

    public async Task<int> GetTimeRegistrationCountForEmployeeIdAsync(int employeeId)
    {
        return await _timeRegistrationRepository.GetTimeRegistrationCountForEmployeeIdAsync(employeeId);
    }
}
