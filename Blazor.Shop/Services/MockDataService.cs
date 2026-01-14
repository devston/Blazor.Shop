using Blazor.Shop.Shared.Domain;

namespace Blazor.Shop.Services;

public class MockDataService
{
    private static List<Employee>? _employees = default!;
    private static List<JobCategory> _jobCategories = default!;
    private static List<Country> _countries = default!;

    public static List<Employee>? Employees
    {
        get
        {
            _countries ??= InitializeMockCountries();
            _jobCategories ??= InitializeMockJobCategories();
            _employees ??= InitializeMockEmployees();
            return _employees;
        }
    }

    private static List<Employee> InitializeMockEmployees()
    {
        var e1 = new Employee
        {
            MaritalStatus = MaritalStatus.Single,
            BirthDate = new DateTime(1989, 3, 11),
            City = "London",
            Email = "beth@blazorshop.com",
            EmployeeId = 1,
            FirstName = "Beth",
            LastName = "Jones",
            Gender = Gender.Female,
            PhoneNumber = "324777888773",
            Smoker = false,
            Street = "123 test",
            Zip = "1000",
            JobCategory = _jobCategories[2],
            JobCategoryId = _jobCategories[2].JobCategoryId,
            Comment = "Lorem Ipsum",
            ExitDate = null,
            JoinedDate = new DateTime(2015, 3, 1),
            Country = _countries[0],
            CountryId = _countries[0].CountryId,
            IsOnHoliday = false
        };

        var e2 = new Employee
        {
            MaritalStatus = MaritalStatus.Married,
            BirthDate = new DateTime(1979, 1, 16),
            City = "London",
            Email = "peg@blazorshop.com",
            EmployeeId = 2,
            FirstName = "Peg",
            LastName = "Legg",
            Gender = Gender.Female,
            PhoneNumber = "33999909923",
            Smoker = false,
            Street = "123 Test",
            Zip = "2000",
            JobCategory = _jobCategories[1],
            JobCategoryId = _jobCategories[1].JobCategoryId,
            Comment = "Lorem Ipsum",
            ExitDate = null,
            JoinedDate = new DateTime(2017, 12, 24),
            Country = _countries[0],
            CountryId = _countries[0].CountryId,
            IsOnHoliday = false
        };

        var e3 = new Employee
        {
            MaritalStatus = MaritalStatus.Married,
            BirthDate = new DateTime(1979, 1, 16),
            City = "London",
            Email = "test@blazorshop.com",
            EmployeeId = 2,
            FirstName = "Test",
            LastName = String.Empty,
            Gender = Gender.Female,
            PhoneNumber = "33999909923",
            Smoker = false,
            Street = "123 Test",
            Zip = "2000",
            JobCategory = _jobCategories[1],
            JobCategoryId = _jobCategories[1].JobCategoryId,
            Comment = "Lorem Ipsum",
            ExitDate = null,
            JoinedDate = new DateTime(2017, 12, 24),
            Country = _countries[0],
            CountryId = _countries[0].CountryId
        };

        return new List<Employee>() { e1 , e2};//, e3 };
    }

    private static List<JobCategory> InitializeMockJobCategories() => [
            new JobCategory{JobCategoryId = 1, JobCategoryName = "Store staff"},
            new JobCategory{JobCategoryId = 2, JobCategoryName = "Sales"},
            new JobCategory{JobCategoryId = 3, JobCategoryName = "Management"},
            new JobCategory{JobCategoryId = 4, JobCategoryName = "Research"},
            new JobCategory{JobCategoryId = 5, JobCategoryName = "Finance"},
            new JobCategory{JobCategoryId = 6, JobCategoryName = "QA"},
            new JobCategory{JobCategoryId = 7, JobCategoryName = "IT"},
            new JobCategory{JobCategoryId = 8, JobCategoryName = "Cleaning"}
        ];

    private static List<Country> InitializeMockCountries() => [
            new Country {CountryId = 1, Name = "UK"},
            new Country {CountryId = 2, Name = "Netherlands"},
            new Country {CountryId = 3, Name = "USA"},
            new Country {CountryId = 4, Name = "Japan"},
            new Country {CountryId = 5, Name = "China"},
            new Country {CountryId = 6, Name = "Belgium"},
            new Country {CountryId = 7, Name = "France"},
            new Country {CountryId = 8, Name = "Brazil"}
        ];
}
