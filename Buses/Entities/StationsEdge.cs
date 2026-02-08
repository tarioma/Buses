namespace Buses.Entities;

/// <summary>
/// Путь между двумя остановками. Можно описать как ребро графа.
/// </summary>
public class StationsEdge
{
    /// <summary>
    /// Уникальный идентификатор <see cref="StationsEdge"/>.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Уникальный идентификатор остановки, с которой начинается путь.
    /// </summary>
    public Guid FromId { get; set; }

    /// <summary>
    /// Остановка, с которой начинается путь.
    /// Можно описать как вершину графа.
    /// </summary>
    public Station From { get; set; } = null!;

    /// <summary>
    /// Уникальный идентификатор остановки, на которой заканчивается путь.
    /// </summary>
    public Guid ToId { get; set; }

    /// <summary>
    /// Остановка, на которой заканчивается путь.
    /// Можно описать как вершину графа.
    /// </summary>
    public Station To { get; set; } = null!;

    /// <summary>
    /// Время, за которое транспортное средство должно пройти этот путь.
    /// </summary>
    public int IntervalInMinutes { get; set; }
}