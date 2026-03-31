namespace Buses.Entities;

/// <summary>
/// Сообщение от транспортного средства, что оно проехало определённую остановку.
/// </summary>
public class Checkpoint
{
    /// <summary>
    /// Уникальный идентификатор <see cref="Checkpoint"/>.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Уникальный идентификатор остановки, которую проехало транспортное средство.
    /// </summary>
    public Guid StationId { get; set; }

    /// <summary>
    /// Остановка, которую проехало транспортное средство.
    /// </summary>
    public Station Station { get; set; } = null!;
}