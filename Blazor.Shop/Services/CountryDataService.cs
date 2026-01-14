using Blazor.Shop.Contracts.Repositories;
using Blazor.Shop.Contracts.Services;
using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Services;

public class CountryDataService : ICountryDataService
{
    private readonly ICountryRepository _countryRepository;

    public CountryDataService(
        ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        return await _countryRepository.GetAllCountriesAsync();
    }

    public async Task<Country> GetCountryByIdAsync(int countryId)
    {
        return await _countryRepository.GetCountryByIdAsync(countryId);
    }
}
