using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ControlIngresoApp.Client;
using ControlIngresoApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5164/") });
builder.Services.AddScoped<SidebarService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IRegistroService, RegistroService>();
builder.Services.AddScoped<IParametroService, ParametroService>();

await builder.Build().RunAsync();
    