namespace Buses.Entities;

/// <summary>
/// Сообщение от транспортного средства, что оно проехало определённую остановку.
/// </summary>
/// <param name="Station">Остановка, которую проехало транспортное средство.</param>
public record Checkpoint(Vehicle Vehicle, Station Station, DateTime DateTime);