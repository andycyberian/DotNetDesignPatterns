using Facade.BallOfMud;
using Facade.Facade;
using Facade.Facade.Entities;
using Facade.GenericFacade.Services;

// Ball of mub

BigClassFacade bigClass = new BigClassFacade();

bigClass.IncreaseBy(50);
bigClass.DecreaseBy(20);

Console.WriteLine($"Final Number : {bigClass.GetCurrentValue()}");


// Facade

const string zipCode = "98074";

IWeatherFacade weatherFacade = new WeatherFacade();
WeatherFacadeResults results = weatherFacade.GetTempInCity(zipCode);

Console.WriteLine("The current temperature is {0}F/{1}C in {2}, {3}",
                    results.Fahrenheit,
                    results.Celsius,
                    results.City.Name,
                    results.State.Name);

// Generic facade

IServiceFacade facade = new ServiceFacade();

Tuple<int, double, string> result = facade.CallFacade();

Console.WriteLine(result.Item1 + " - " + result.Item2 + " - " + result.Item3);
