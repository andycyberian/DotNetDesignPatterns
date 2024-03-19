using Facade.Facade.Entities;

namespace Facade.Facade;

public interface IWeatherFacade
{
    WeatherFacadeResults GetTempInCity(string zipCode);
}
