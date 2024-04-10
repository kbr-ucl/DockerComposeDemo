namespace WebApplication.ClientProxy
{
    // https://timdeschryver.dev/blog/refactor-your-net-http-clients-to-typed-http-clients#refactor-to-typed-http-clients
    public interface IWeatherServerProxy
    {
        Task<IEnumerable<WeatherForecast>?> GetAll();
    }
}
