using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Fediseer;
using FediseerGui.Components;
using FediseerGui.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient("fediseer", (sp, client) =>
{
    client.BaseAddress = new Uri("https://fediseer.com/api/");    
});
builder.Services.AddTransient<FediseerClient>((sp) =>
{
    var hcFac = sp.GetRequiredService<IHttpClientFactory>();
    var cl = hcFac.CreateClient("fediseer");
    return new FediseerClient(cl);
});
builder.Services.AddDataProtection();
builder.Services.AddTransient<LocalStorage>();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
