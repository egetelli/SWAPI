public interface IPlanetReader
{
    Task<IEnumerable<Planet>> Read();
}
