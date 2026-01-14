using Blazor.Shop.Contracts.Repositories;
using Blazor.Shop.Data;
using Blazor.Shop.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Shop.Repositories;

public class JobCategoryRepository : IJobCategoryRepository, IDisposable
{
    private readonly AppDbContext _appDbContext;

    public JobCategoryRepository(
        IDbContextFactory<AppDbContext> DbFactory)
    {
        _appDbContext = DbFactory.CreateDbContext();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }

    public async Task<IEnumerable<JobCategory>> GetAllJobCategoriesAsync()
    {
        return await Task.FromResult(_appDbContext.JobCategories);
    }

    public async Task<JobCategory> GetJobCategoryByIdAsync(int jobCategoryId)
    {
        return await _appDbContext.JobCategories.FirstOrDefaultAsync(c => c.JobCategoryId == jobCategoryId);
    }
}
