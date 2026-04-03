namespace Buses.Entities;

/// <summary>
/// Рейс, представляющий собой конкретный маршрут,
/// по которому должны ходить транспортные средства.
/// </summary>
/// <param name="Name">Название рейса.</param>
public record GlobalRoute(string Name);