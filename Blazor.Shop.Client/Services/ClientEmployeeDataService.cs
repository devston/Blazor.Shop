using Blazor.Shop.Client.Helper;
using Blazor.Shop.Shared.Domain;
using Blazored.LocalStorage;
using System.Text.Json;

namespace Blazor.Shop.Client.Services;

public class ClientEmployeeDataService : IEmployeeDataService
{
    private readonly HttpClient? _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public ClientEmployeeDataService(
        HttpClient httpClient,
        ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public Task<Employee> AddEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeAsync(int employeeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        bool employeeExpirationExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeesListExpirationKey);
        
        if (employeeExpirationExists)
        {
            var employeeListExpiration = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.EmployeesListExpirationKey);
            
            if (employeeListExpiration > DateTime.UtcNow)//get from local storage
            {
                if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeesListKey))
                {
                    return await _localStorageService.GetItemAsync<List<Employee>>(LocalStorageConstants.EmployeesListKey);
                }
            }
        }

        var list = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                (await _httpClient.GetStreamAsync("api/employee"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListKey, list);
        await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListExpirationKey, DateTime.UtcNow.AddMinutes(1));
        return list;
    }

    public Task<Employee> GetEmployeeDetailsAsync(int employeeId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }
}
