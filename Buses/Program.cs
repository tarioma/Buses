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
    // В одну сторону, от первой к последней остановке
    new(stations[0], stations[1], 3), // Леч. Городок -> Парк Победы
    new(stations[1], stations[2], 4), // Парк Победы -> Городской стадион
    new(stations[2], stations[3], 2), // Городской Стадион -> Школа №9
    new(stations[3], stations[4], 5), // Школа №9 -> Зелёный рынок
    new(stations[4], stations[5], 2), // Зелёный рынок -> Лиманный рынок
    new(stations[5], stations[6], 3), // Лиманный рынок -> Орион
    new(stations[6], stations[7], 4), // Орион -> Манго
    new(stations[7], stations[8], 7), // Манго -> Бородино
    
    // В обратную сторону, от последней к первой остановке
    new(stations[8], stations[7], 7), // Бородино -> Манго
    new(stations[7], stations[6], 4), // Манго -> Орион
    new(stations[6], stations[5], 3), // Орион -> Лиманный рынок
    new(stations[5], stations[4], 2), // Лиманный рынок -> Зелёный рынок
    new(stations[4], stations[3], 5), // Зелёный рынок -> Школа №9
    new(stations[3], stations[2], 2), // Школа №9 -> Городской Стадион
    new(stations[2], stations[1], 4), // Городской стадион -> Парк Победы
    new(stations[1], stations[0], 3) // Парк Победы -> Леч. Городок
];

// Конкретные пути глобальных маршрутов в определённые даты
List<Route> routes =
[
    new("Маршрут для троллейбуса №19А c 1 января 2024 года", DateTime.Parse("2024-1-1"), DateTime.Parse("2026-1-1"), globalRoutes[0]),
    new("Маршрут для троллейбуса №19А c 1 января 2026 года", DateTime.Parse("2026-1-1"), null, globalRoutes[0]) // Для примера будет использоваться этот
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
    new(7, routes[1], stationsEdges[7]), // Манго -> Бородино

    // Обратно от последней к первой остановке
    new(8, routes[1], stationsEdges[8]), // Бородино -> Манго
    new(9, routes[1], stationsEdges[9]), // Манго -> Орион
    new(10, routes[1], stationsEdges[10]), // Орион -> Лиманный рынок
    new(11, routes[1], stationsEdges[11]), // Лиманный рынок -> Зелёный рынок
    new(12, routes[1], stationsEdges[12]), // Зелёный рынок -> Школа №9
    new(13, routes[1], stationsEdges[13]), // Школа №9 -> Городской Стадион
    new(14, routes[1], stationsEdges[14]), // Городской стадион -> Парк Победы
    new(14, routes[1], stationsEdges[15]) // Парк Победы -> Леч. Городок
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
var actualRouteStationEdges = routeStationEdges.Where(e => actualRoutes.Any(r => r == e.Route)).ToList();

// Теперь мы знаем, через какие остановки должно проходить транспортное средство

// Вычислим время, необходимое для прохождения всего пути
var fullRouteTime = stationsEdges
    .Where(e => actualRouteStationEdges.Any(se => se.StationsEdge.From == e.From &&
                                                  se.StationsEdge.To == e.To))
    .Sum(e => e.Interval);

// Время на один рейс составляет 60 минут

// Какие остановки проезжало конкретное транспортное средство в определённое время
// Данные, присылаемые каждым транспортным средством при проезде каждой остановки
List<Checkpoint> checkpoints =
[
    // Нормальный пройденный рейс от первой остановки до последней и обратно
    new(vehicles[0], stations[0], DateTime.Parse("2026-1-1 8:00")),
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 8:03")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 8:07")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 8:09")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 8:14")),
    new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 8:16")),
    new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 8:19")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 8:23")),
    new(vehicles[0], stations[8], DateTime.Parse("2026-1-1 8:30")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 8:37")),
    new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 8:41")),
    new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 8:44")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 8:46")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 8:51")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 8:53")),
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 8:57")),
    new(vehicles[0], stations[0], DateTime.Parse("2026-1-1 9:00")),
    
    // Второй нормально пройденный рейс
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 9:03")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 9:07")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 9:09")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 9:14")),
    new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 9:16")),
    new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 9:19")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 9:23")),
    new(vehicles[0], stations[8], DateTime.Parse("2026-1-1 9:30")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 9:37")),
    new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 9:41")),
    new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 9:44")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 9:46")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 9:51")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 9:53")),
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 9:57")),
    new(vehicles[0], stations[0], DateTime.Parse("2026-1-1 10:00")),
    
    // Третий рейс - были пропущены 2 остановки, это допустимо
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 10:03")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 10:07")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 10:09")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 10:14")),
    // new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 10:16")),
    // new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 10:19")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 10:23")),
    new(vehicles[0], stations[8], DateTime.Parse("2026-1-1 10:30")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 10:37")),
    new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 10:41")),
    new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 10:44")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 10:46")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 10:51")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 10:53")),
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 10:57")),
    new(vehicles[0], stations[0], DateTime.Parse("2026-1-1 11:00")),
    
    // Четвёртый рейс - были пропущены 3 остановки, рейс не должен быть засчитан
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 11:03")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 11:07")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 11:09")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 11:14")),
    // new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 11:16")),
    // new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 11:19")),
    // new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 11:23")),
    new(vehicles[0], stations[8], DateTime.Parse("2026-1-1 11:30")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 11:37")),
    new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 11:41")),
    new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 11:44")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 11:46")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 11:51")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 11:53")),
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 11:57")),
    new(vehicles[0], stations[0], DateTime.Parse("2026-1-1 12:00")),
    
    // Пятый рейс - все остановки пройдены, одна заняла на 10 минут больше ожидаемого времени 
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 12:03")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 12:07")),
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 12:09")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 12:14")),
    new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 12:16")),
    new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 12:19")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 12:23")),
    new(vehicles[0], stations[8], DateTime.Parse("2026-1-1 12:30")),
    new(vehicles[0], stations[7], DateTime.Parse("2026-1-1 12:37")),
    new(vehicles[0], stations[6], DateTime.Parse("2026-1-1 12:41")),
    new(vehicles[0], stations[5], DateTime.Parse("2026-1-1 12:44")),
    new(vehicles[0], stations[4], DateTime.Parse("2026-1-1 12:56")), // вместо 46 минут - 56
    new(vehicles[0], stations[3], DateTime.Parse("2026-1-1 13:01")),
    new(vehicles[0], stations[2], DateTime.Parse("2026-1-1 13:03")),
    new(vehicles[0], stations[1], DateTime.Parse("2026-1-1 13:07")),
    new(vehicles[0], stations[0], DateTime.Parse("2026-1-1 13:10"))
];
// Итого, 5 рейсов, из которых должны быть засчитаны только 1, 2 и 3, а 4 и 5 - нет

// Теперь посчитаем засчитанные и незасчитанные рейсы

// Остановка, которая является конечной
var mainStation = actualRouteStationEdges.First().StationsEdge.From;

// Обрезаем остановки в начале и конце, чтобы первой и последней остановкой была конечная
checkpoints = checkpoints
    .SkipWhile(c => c.Station != mainStation)
    .Reverse()
    .SkipWhile(c => c.Station != mainStation)
    .Reverse()
    .ToList();

const int totalRouteDeviation = 5; // разрешаем потратить на весь рейс на 5 минут больше или меньше
const int minIntersect = 85; // какой процент остановок должен быть пройден

var creditedRoutes = 0; // количество зачтённых рейсов
var uncreditedRoutes = 0; // количество незачтённых рейсов

// Чекпоинты, когда транспортное средство проехало конечную
var mainStationCheckpoints = checkpoints.Where(c => c.Station == mainStation).ToList();

// Станции, которые должны быть пройдены за этот рейс
var routeStations = actualRouteStationEdges
    .Select(e => e.StationsEdge.To)
    .Prepend(actualRouteStationEdges.First().StationsEdge.From)
    .ToList();

// Идём по чекпоинтам с конечной остановкой
for (var i = 0; i < mainStationCheckpoints.Count - 1; i++)
{
    var routeFirstCheckpoint = mainStationCheckpoints[i];
    var routeLastCheckpoint = mainStationCheckpoints[i + 1];
    
    // Смотрим, какие станции проехало транспортное средство за этот рейс
    var routeCheckpointStations = checkpoints
        .SkipWhile(c => c != routeFirstCheckpoint)
        .Reverse()
        .SkipWhile(c => c != routeLastCheckpoint)
        .Reverse()
        .Select(c => c.Station)
        .ToList();
    
    var match = routeStations.Count(x => routeCheckpointStations.Remove(x));
    var percent = 100.0 * match / routeStations.Count; // процент пройденных станций от обязательных
    
    // Затраченное время на рейс
    var routeTime = (routeLastCheckpoint.DateTime - routeFirstCheckpoint.DateTime).TotalMinutes;

    // Если процент меньше допустимого или затраченного времени слишком мало/много, то рейс не засчитывается
    if (percent < minIntersect ||
        routeTime < fullRouteTime - totalRouteDeviation ||
        routeTime > fullRouteTime + totalRouteDeviation)
    {
        uncreditedRoutes++;
    }
    else
    {
        creditedRoutes++;
    }
}

// 1 рейс: percent = 100, routeTime = 60 -> зачситан
// 2 рейс: percent = 100, routeTime = 60 -> зачситан
// 3 рейс: percent = 88, routeTime = 60 -> засчитан, процент допустимый
// 4 рейс: percent = 82, routeTime = 60 -> не зачситан, процент меньше 85
// 5 рейс: percent = 100, routeTime = 70 -> не зачситан, время больше допустимого (60) + 5 минут

Console.WriteLine(creditedRoutes); // 3 (1, 2 и 3 рейсы)
Console.WriteLine(uncreditedRoutes); // 2 (4 и 5 рейсы)