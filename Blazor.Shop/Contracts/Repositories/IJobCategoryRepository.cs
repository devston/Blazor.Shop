using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Contracts.Repositories;

public interface IJobCategoryRepository
{
    Task<IEnumerable<JobCategory>> GetAllJobCategoriesAsync();
    
    Task<JobCategory> GetJobCategoryByIdAsync(int jobCategoryId);
}
