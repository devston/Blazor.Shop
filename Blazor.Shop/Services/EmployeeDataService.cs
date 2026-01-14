using Blazor.Shop.Client;
using Blazor.Shop.Contracts.Repositories;
using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Services;

public class EmployeeDataService : IEmployeeDataService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EmployeeDataService(
        IEmployeeRepository employeeRepository,
        IWebHostEnvironment webHostEnvironment,
        IHttpContextAccessor httpContextAccessor)
    {
        _employeeRepository = employeeRepository;
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _employeeRepository.GetAllEmployeesAsync();
    }

    public async Task<Employee> GetEmployeeDetailsAsync(int employeeId)
    {
        return await _employeeRepository.GetEmployeeByIdAsync(employeeId);
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        return await _employeeRepository.AddEmployeeAsync(employee);
    }
    
    public async Task UpdateEmployeeAsync(Employee employee)
    {
        if (employee.ImageContent != null)
        {
            string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{employee.ImageName}";
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
            fileStream.Close();

            employee.ImageName = $"https://{currentUrl}/uploads/{employee.ImageName}";
        }

        await _employeeRepository.UpdateEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        await _employeeRepository.DeleteEmployeeAsync(employeeId);
    }
}
