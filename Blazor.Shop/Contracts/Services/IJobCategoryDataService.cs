using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Contracts.Services;

public interface IJobCategoryDataService
{
    Task<IEnumerable<JobCategory>> GetAllJobCategoriesAsync();
    
    Task<JobCategory> GetJobCategoryByIdAsync(int jobCategoryId);
}
