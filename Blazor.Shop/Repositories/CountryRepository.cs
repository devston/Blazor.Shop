using Blazor.Shop.Contracts.Repositories;
using Blazor.Shop.Data;
using Blazor.Shop.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Shop.Repositories;

public class CountryRepository : ICountryRepository, IDisposable
{
    private readonly AppDbContext _appDbContext;

    public CountryRepository(
        IDbContextFactory<AppDbContext> DbFactory)
    {
        _appDbContext = DbFactory.CreateDbContext();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();    
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        return await Task.FromResult(_appDbContext.Countries);
    }

    public async Task<Country> GetCountryByIdAsync(int countryId)
    {
        return await _appDbContext.Countries.FirstOrDefaultAsync(c => c.CountryId == countryId);
    }
}
