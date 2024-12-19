
using SWAPI.ApiDataAccess;
using SWAPI.DTOs;
using System.Text.Json;
try
{
    await new StarWarsPlanetsStatsApp(
        new ApiDataReader(),
        new MockStarWarsApiDataReader()).Run();
}
catch(Exception ex)
{
    Console.WriteLine("An error occured. " +
        "Exception message: " + ex.Message);
}



Console.WriteLine("Press any key to close.");
Console.ReadKey();


public class StarWarsPlanetsStatsApp
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _secondaryDataReader;

    public StarWarsPlanetsStatsApp(
        IApiDataReader apiDataReader, 
        IApiDataReader secondaryDataReader)
    {
        _apiDataReader = apiDataReader;
        _secondaryDataReader = secondaryDataReader;
    }
    public async Task Run()
    {
        string? json = null;
        try
        {
            json = await _apiDataReader.Read(
                "https://swapi.py4e.com/", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("API request was unsuccessful. " +
                "Switching to mock data. " +
                "Exception message: " + ex.Message);
        }
        if (json is null)
        {
            json = await _secondaryDataReader.Read(
                "https://swapi.py4e.com/", "api/planets");
        }

        var root = JsonSerializer.Deserialize<Root>(json);

        var planets = ToPlanets(root);
    }

    private IEnumerable<Planet> ToPlanets(Root? root)
    {
        if(root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }
        throw new NotImplementedException();
    }
}


public readonly record struct Planet
{
    public string Name { get; }
    public int Diameter { get; }
    public int? SurfaceWater { get; }
    public int? Population { get; }


    public Planet(
        string name, 
        int diameter, 
        int? surfaceWater, 
        int? population)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }
}