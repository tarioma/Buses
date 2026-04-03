namespace Buses.Entities;

/// <summary>
/// Путь между двумя остановками в рамках одного полного пути <see cref="Route"/>.
/// </summary>
/// <param name="Index">Последовательный номер пути в маршруте <see cref="Route"/>.</param>
/// <param name="Route">Полный путь, частью которого является данный путь между двумя остановками.</param>
/// <param name="StationsEdge">Путь между двумя остановками.</param>
public record RouteStationEdge(int Index, Route Route, StationsEdge StationsEdge);