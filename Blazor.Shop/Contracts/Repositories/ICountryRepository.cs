using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Contracts.Repositories;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllCountriesAsync();
    
    Task<Country> GetCountryByIdAsync(int countryId);
}
