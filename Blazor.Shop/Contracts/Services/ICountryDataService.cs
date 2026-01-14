using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Contracts.Services;

public interface ICountryDataService
{
    Task<IEnumerable<Country>> GetAllCountriesAsync();
    
    Task<Country> GetCountryByIdAsync(int countryId);
}
