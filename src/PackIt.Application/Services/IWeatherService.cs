using PackIt.Application.Commands;
using PackIt.Application.DTOs.External;

namespace PackIt.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeatherAsync(LocalizationReadModel localization);
    }
}
