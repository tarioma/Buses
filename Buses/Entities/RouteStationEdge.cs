namespace Buses.Entities;

/// <summary>
/// Путь между двумя остановками в рамках одного полного пути <see cref="Route"/>.
/// </summary>
public class RouteStationEdge
{
    /// <summary>
    /// Последовательный номер пути в маршруте <see cref="Route"/>.
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// Уникальный идентификатор полного пути, частью которого является данный путь между двумя остановками.
    /// </summary>
    public Guid RouteId { get; set; }

    /// <summary>
    /// Полный путь, частью которого является данный путь между двумя остановками.
    /// </summary>
    public Route Route { get; set; } = null!;

    /// <summary>
    /// Уникальный идентификатор пути между двумя остановками.
    /// </summary>
    public Guid StationsEdgeId { get; set; }

    /// <summary>
    /// Путь между двумя остановками.
    /// </summary>
    public StationsEdge StationsEdge { get; set; } = null!;
}