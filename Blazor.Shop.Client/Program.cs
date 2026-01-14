using Blazor.Shop.Client.Services;
using Blazor.Shop.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IEmployeeDataService, ClientEmployeeDataService>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
