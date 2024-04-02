using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<IndexModel> _logger;
    public IEnumerable<WeatherForecast>? WeatherForecasts { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGet()
    {
        var httpClient = _httpClientFactory.CreateClient("WeatherApi");
        var httpResponseMessage = await httpClient.GetAsync("WeatherForecast");

        if (httpResponseMessage.IsSuccessStatusCode)
            WeatherForecasts = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
    }
}