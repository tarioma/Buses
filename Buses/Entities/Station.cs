namespace Buses.Entities;

/// <summary>
/// Остановка, на которой обязано остановиться какое-то транспортное средство.
/// </summary>
public class Station
{
    /// <summary>
    /// Уникальный идентификатор <see cref="Station"/>.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название остановки.
    /// </summary>
    /// <example>9-я школа</example>
    public string Name { get; set; } = null!;
}