using Buses.Entities;

// Глобальные маршруты
List<GlobalRoute> globalRoutes =
[
    new("Троллейбус №19А")
];

// Остановки
List<Station> stations =
[
    new("Леч. Городок"),
    new("Парк Победы"),
    new("Городской стадион"),
    new("Школа №9"),
    new("Зелёный рынок"),
    new("Лиманный рынок"),
    new("Орион"),
    new("Манго"),
    new("Бородино")
];

// Время на путь от одной остановки до другой
List<StationsEdge> stationsEdges =
[
    new(stations[0], stations[1], 3), // Леч. Городок -> Парк Победы
    new(stations[1], stations[2], 4), // Парк Победы -> Городской стадион
    new(stations[2], stations[3], 2), // Городской Стадион -> Школа №9
    new(stations[3], stations[4], 5), // Школа №9 -> Зелёный рынок
    new(stations[4], stations[5], 2), // Зелёный рынок -> Лиманный рынок
    new(stations[5], stations[6], 3), // Лиманный рынок -> Орион
    new(stations[6], stations[7], 4), // Орион -> Манго
    new(stations[7], stations[8], 7) // Манго -> Бородино
];

// Конкретные пути глобальных маршрутов в определённые даты
List<Route> routes =
[
    new("Маршрут для троллейбуса №19А c 1 января 2024 года", DateTime.Parse("2024-1-1"), DateTime.Parse("2026-1-1"), globalRoutes[0]),
    new("Маршрут для троллейбуса №19А c 1 января 2026 года", DateTime.Parse("2026-1-1"), null, globalRoutes[0])
];

// Пути между остановками, входящие в определённый маршрут по порядку
List<RouteStationEdge> routeStationEdges =
[
    new(0, routes[1], stationsEdges[0]), // Леч. Городок -> Парк Победы
    new(1, routes[1], stationsEdges[1]), // Парк Победы -> Городской Стадион
    new(2, routes[1], stationsEdges[2]), // Городской Стадион -> Школа №9
    new(3, routes[1], stationsEdges[3]), // Школа №9 -> Зелёный рынок
    new(4, routes[1], stationsEdges[4]), // Зелёный рынок -> Лиманный рынок
    new(5, routes[1], stationsEdges[5]), // Лиманный рынок -> Орион
    new(6, routes[1], stationsEdges[6]), // Орион -> Манго
    new(7, routes[1], stationsEdges[7]) // Манго -> Бородино
];

// Транспортные средства
List<Vehicle> vehicles =
[
    new("T123AA")
];

// Какие пути должны проходить конкретные транспортные средства в определённый промежуток времени и дни недели
List<VehicleGlobalRoute> vehicleGlobalRoutes =
[
    new(globalRoutes[0], vehicles[0], TimeOnly.Parse("8:00"), TimeOnly.Parse("20:00"), DayOfWeek.Sunday, DateTime.Parse("2020-1-1"), null)
];

// Какие остановки проезжало конкретное транспортное средство в определённое время
// Данные, присылаемые каждым транспортным средством при проезде каждой остановки
List<Checkpoint> checkpoints =
[
    new(vehicles[0], stations[0], DateTime.Parse("2026-1-1 8:00")),
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 8:03")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 8:07")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 8:09")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 8:14")),
    new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 8:16")),
    new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 8:19")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 8:23")),
    new(vehicles[0], stations[8], DateTime.Parse("2026-1-1 8:30"))
];

// Допустим, сегодня 1 марта 2026 года, Воскресенье
var today = DateTime.Parse("2026-3-1");
const DayOfWeek dayOfWeek = DayOfWeek.Sunday;

// Допустим, в системе есть одно транспортное средство и мы используем только его
var vehicle = vehicles[0];

// Теперь попробуем определить глобальные маршруты для указанной даты и дня недели
var actualVehicleGlobalRoutes = vehicleGlobalRoutes.Where(r => r.Vehicle == vehicle &&
                                                               r.DayOfWeek == dayOfWeek &&
                                                               r.StartDate <= today &&
                                                               (r.EndDate is null || r.EndDate >= today));

// Так мы узнаём, что указанное транспортное средство 1 марта 2026 года в воскресенье должно двигаться по двум маршрутам

// Узнаем конкретные актуальные маршруты
var actualRoutes = routes.Where(r => r.StartDate <= today &&
                                     (r.EndDate is null || r.EndDate >= today) &&
                                     actualVehicleGlobalRoutes.Any(gr => gr.GlobalRoute == r.GlobalRoute));

// Теперь мы знаем, что это транспортное средство должно двигаться по маршруту "Маршрут для троллейбуса №19А c 1 января 2026 года"

// Можем получить остановки, которые должно проходить транспортное средство
var actualRouteStationEdges = routeStationEdges.Where(e => actualRoutes.Any(r => r == e.Route));

// Теперь мы знаем, через какие остановки должно проходить транспортное средство

// Вычислим время, необходимое для прохождения всего пути
var fullRouteTime = stationsEdges
    .Where(e => actualRouteStationEdges.Any(se => se.StationsEdge.From == e.From &&
                                                  se.StationsEdge.To == e.To))
    .Sum(e => e.Interval);

// Время на один рейс составляет 30 минут

