
using SWAPI.ApiDataAccess;
using SWAPI.DTOs;
using System.Text.Json;

IApiDataReader apiDataReader = new ApiDataReader();
var json = await apiDataReader.Read(
    "https://swapi.py4e.com/", "api/planets");
var root = JsonSerializer.Deserialize<Root>(json);

Console.WriteLine("Press any key to close.");
Console.ReadKey();
