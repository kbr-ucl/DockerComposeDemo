using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.ClientProxy;

namespace WebApplication.Pages;

public class IndexModel : PageModel
{
    //private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<IndexModel> _logger;
    private readonly IWeatherServerProxy _weatherServerProxy;
    public IEnumerable<WeatherForecast>? WeatherForecasts { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IWeatherServerProxy weatherServerProxy)
    {
        _logger = logger;
        _weatherServerProxy = weatherServerProxy;
        //_httpClientFactory = httpClientFactory;
    }

    public async Task OnGet()
    {
        //var httpClient = _httpClientFactory.CreateClient("WeatherApi");
        //var httpResponseMessage = await httpClient.GetAsync("WeatherForecast");

        WeatherForecasts = await _weatherServerProxy.GetAll();

        //if (httpResponseMessage.IsSuccessStatusCode)
        //    WeatherForecasts = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
    }
}