﻿
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
        string json = null;
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
    }

}