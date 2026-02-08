namespace Buses.Entities;

/// <summary>
/// Рейс, представляющий собой конкретный маршрут,
/// по которому должны ходить транспортные средства.
/// </summary>
public class GlobalRoute
{
    /// <summary>
    /// Уникальный идентификатор <see cref="GlobalRoute"/>.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название рейса.
    /// </summary>
    /// <example>Маршрут 14</example>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Маршруты, входящие в глобальный рейс для разных премежутков времени.
    /// </summary>
    public List<Route> Routes { get; set; } = [];
}