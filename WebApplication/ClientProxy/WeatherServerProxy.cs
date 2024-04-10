namespace WebApplication.ClientProxy;

public class WeatherServerProxy : IWeatherServerProxy
{
    private HttpClient _httpClient;

    public WeatherServerProxy(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    async Task<IEnumerable<WeatherForecast>?> IWeatherServerProxy.GetAll()
    {

        //var httpResponseMessage = await httpClient.GetAsync("WeatherForecast");
        //WeatherForecasts = await _weatherServerProxy.GetAll();

        //if (httpResponseMessage.IsSuccessStatusCode)
        //    WeatherForecasts = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
            
        var httpResponseMessage = await _httpClient
            .GetFromJsonAsync< IEnumerable<WeatherForecast>>("WeatherForecast");
        return httpResponseMessage;
    }
}