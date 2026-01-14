using Blazor.Shop.Contracts.Repositories;
using Blazor.Shop.Data;
using Blazor.Shop.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Shop.Repositories;

public class TimeRegistrationRepository : ITimeRegistrationRepository, IDisposable
{
    private readonly AppDbContext _appDbContext;

    public TimeRegistrationRepository(
        IDbContextFactory<AppDbContext> DbFactory)
    {
        _appDbContext = DbFactory.CreateDbContext();
    }

    public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployeeAsync(int employeeId)
    {
        return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).OrderBy(t => t.StartTime).ToListAsync();
    }

    public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployeeAsync(int employeeId, int pageSize, int start)
    {
        return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).OrderBy(t => t.StartTime).Skip(start).Take(pageSize).ToListAsync();
    }

    public async Task<int> GetTimeRegistrationCountForEmployeeIdAsync(int employeeId)
    {
        return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).CountAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}
