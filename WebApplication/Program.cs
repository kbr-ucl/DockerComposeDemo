var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("WeatherApi",options =>
{
    options.BaseAddress = new Uri(builder.Configuration["WeatherApiUrl"]);
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
