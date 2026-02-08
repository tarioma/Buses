namespace Buses.Entities;

/// <summary>
/// Маршрут с описанием остановок, которые должны быть пройдены.
/// </summary>
/// <example>
/// Есть <see cref="GlobalRoute"/> и этот класс описывает, какие остановки он содержит.
/// </example>
public class Route
{
    /// <summary>
    /// Уникальный идентификатор <see cref="Route"/>.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название маршрута.
    /// </summary>
    /// <example>Маршрут №14 c 1 января 2024</example>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Дата, начиная с которой действует маршрут.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата, до которой действует маршрут.
    /// Может быть не указана, если маршрут актуален на данный момент.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Уникальный идентификатор глобального маршрута, который описывается в этом классе.
    /// </summary>
    public Guid GlobalRouteId { get; set; }
    
    /// <summary>
    /// Глобальный маршрут, который описывается в этом классе.
    /// </summary>
    public GlobalRoute GlobalRoute { get; set; } = null!;
}