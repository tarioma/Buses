namespace Buses.Entities;

/// <summary>
/// Глобальный маршрут, на котором находится транспортное средство.
/// По этой сущности можно идентифицировать, по какому маршруту шло
/// конкретное транспортное средство в конкретный день.
/// </summary>
/// <example>
/// Например, троллейбус с номером T123AA может ездить по маршруту №19А,
/// а с 13:00 до 18:00 уже по марщруту №2.
/// А в выходные дни вообще по маршруту №4.
/// </example>
public class VehicleGlobalRoute
{
    /// <summary>
    /// Уникальный идентификатор <see cref="VehicleGlobalRoute"/>.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Уникальный идентификатор глобального рейса, по которому ходит
    /// транспортное средство в данный период времени.
    /// </summary>
    public Guid GlobalRouteId { get; set; }
    
    /// <summary>
    /// Глобальный рейс, по которому ходит транспортное средство в данный период времени.
    /// </summary>
    public GlobalRoute GlobalRoute { get; set; } = null!;

    /// <summary>
    /// Уникальный идентификатор транспортного средства, маршрут которого описывается.
    /// </summary>
    public Guid VehicleId { get; set; }

    /// <summary>
    /// Транспортное средство, маршрут которого описывается.
    /// </summary>
    public Vehicle Vehicle { get; set; } = null!;

    /// <summary>
    /// Время, в которое транспортное средство должно начать путь.
    /// </summary>
    /// <example>8:00</example>
    public TimeOnly From { get; set; }

    /// <summary>
    /// Время, в которое транспортное средство должно завершить путь.
    /// </summary>
    /// <example>21:30</example>
    public TimeOnly To { get; set; }

    /// <summary>
    /// День недели, для которого действителен этот маршрут.
    /// </summary>
    public DayOfWeek DayOfWeek { get; set; }

    /// <summary>
    /// Дата, начиная с которой действует маршрут для данного транспортного средства.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата, до которой действует маршрут для данного транспортного средства.
    /// </summary>
    public DateTime? EndDate { get; set; }
}