using Blazor.Shop.Auth;
using Blazor.Shop.Client;
using Blazor.Shop.Components;
using Blazor.Shop.Components.Account;
using Blazor.Shop.Contracts.Repositories;
using Blazor.Shop.Contracts.Services;
using Blazor.Shop.Data;
using Blazor.Shop.Repositories;
using Blazor.Shop.Services;
using Blazor.Shop.State;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents(); ;

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]
        ));

builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();
builder.Services.AddScoped<ITimeRegistrationDataService, TimeRegistrationDataService>();
builder.Services.AddScoped<ICountryDataService, CountryDataService>();
builder.Services.AddScoped<IJobCategoryDataService, JobCategoryDataService>();


builder.Services.AddScoped<ITimeRegistrationRepository, TimeRegistrationRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<ApplicationState>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();


builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Blazor.Shop.Client._Imports).Assembly); ;

app.MapAdditionalIdentityEndpoints();


app.MapGet("/api/employee", async (IEmployeeDataService employeeDataService) => await employeeDataService.GetAllEmployeesAsync());

app.Run();
