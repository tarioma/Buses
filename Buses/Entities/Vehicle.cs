namespace Buses.Entities;

/// <summary>
/// Транспортное средство.
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Уникальный идентификатор <see cref="Vehicle"/>.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Госномер транспортного средства.
    /// </summary>
    public string LicensePlate { get; set; } = null!;
}