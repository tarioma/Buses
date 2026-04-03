namespace Buses.Entities;

/// <summary>
/// Путь между двумя остановками. Можно описать как ребро графа.
/// </summary>
/// <param name="From">Остановка, с которой начинается путь. Можно описать как вершину графа.</param>
/// <param name="To">Остановка, на которой заканчивается путь. Можно описать как вершину графа.</param>
/// <param name="Interval">Время, за которое транспортное средство должно пройти этот путь.</param>
public record StationsEdge(Station From, Station To, int Interval);