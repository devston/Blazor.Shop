using Blazor.Shop.Contracts.Repositories;
using Blazor.Shop.Contracts.Services;
using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Services;

public class JobCategoryDataService : IJobCategoryDataService
{
    private readonly IJobCategoryRepository _jobCategoryRepository;

    public JobCategoryDataService(
        IJobCategoryRepository jobCategoryRepository)
    {
        _jobCategoryRepository = jobCategoryRepository;
    }

    public async Task<IEnumerable<JobCategory>> GetAllJobCategoriesAsync()
    {
        return await _jobCategoryRepository.GetAllJobCategoriesAsync();
    }

    public async Task<JobCategory> GetJobCategoryByIdAsync(int jobCategoryId)
    {
        return await _jobCategoryRepository.GetJobCategoryByIdAsync(jobCategoryId);
    }
}
