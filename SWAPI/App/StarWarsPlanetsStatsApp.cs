using SWAPI.UserInteraction;

public class StarWarsPlanetsStatsApp
{

    private readonly IPlanetReader _planetsReader;
    private readonly IPlanetStatisticsAnalyzer _planetsStatisticsAnalyzer;
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;

    public StarWarsPlanetsStatsApp(
        IPlanetReader planetsReader,
        IPlanetStatisticsAnalyzer planetsStaticticsAnalyzer,
        IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsReader = planetsReader;
        _planetsStatisticsAnalyzer = planetsStaticticsAnalyzer;
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();

        _planetsStatsUserInteractor.Show(planets);

        _planetsStatisticsAnalyzer.Analyze(planets);
    }




}
