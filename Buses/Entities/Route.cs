namespace Buses.Entities;

/// <summary>
/// Маршрут с описанием остановок, которые должны быть пройдены.
/// </summary>
/// <example>
/// Есть <see cref="GlobalRoute"/> и этот класс описывает, какие остановки он содержит.
/// </example>
/// <param name="Name">Название маршрута.</param>
/// <param name="StartDate">Дата, начиная с которой действует маршрут.</param>
/// <param name="EndDate">
/// Дата, до которой действует маршрут.
/// Может быть не указана, если маршрут актуален на данный момент.
/// </param>
/// <param name="GlobalRoute">Глобальный маршрут, который описывается в этом классе.</param>
public record Route(string Name, DateTime StartDate, DateTime? EndDate, GlobalRoute GlobalRoute);