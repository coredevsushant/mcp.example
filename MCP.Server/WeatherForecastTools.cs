using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MCP.Server
{
    public class WeatherForecastModel
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
    [McpServerToolType]
    public static class WeatherForecastTools
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44394/")
        };

        [McpServerTool, Description("Retrieves the current weather forecast.")]
        public static async Task<List<WeatherForecastModel>> GetWeatherForecastAsync()
        {
            var response = await httpClient.GetAsync("WeatherForecast");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<WeatherForecastModel>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [McpServerTool, Description("Creates a new weather forecast entry.")]
        public static async Task<string> CreateWeatherForecastAsync(WeatherForecastModel forecast)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(forecast), Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            var response = await httpClient.PostAsync("WeatherForecast", jsonContent);
            response.EnsureSuccessStatusCode();

            return "Weather forecast created successfully.";
        }

        [McpServerTool, Description("Updates an existing weather forecast entry.")]
        public static async Task<string> UpdateWeatherForecastAsync(WeatherForecastModel forecast)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(forecast), Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            var response = await httpClient.PutAsync("WeatherForecast", jsonContent);
            response.EnsureSuccessStatusCode();

            return "Weather forecast updated successfully.";
        }
    }
}
