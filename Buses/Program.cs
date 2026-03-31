using Buses.Entities;

// Глобальные маршруты
List<GlobalRoute> globalRoutes =
[
    new()
    {
        Id = Guid.Parse("7cbb0d8e-ce5d-47b6-937d-af85a15ff1da"),
        Name = "Троллейбус №19А"
    }
];

// Остановки
List<Station> stations =
[
    new()
    {
        Id = Guid.Parse("456de40d-76f3-44d2-b9d2-8270bbe9dd3b"),
        Name = "Леч. Городок"
    },
    new()
    {
        Id = Guid.Parse("98b0601e-fc23-496a-a8e6-8295f398f5d9"),
        Name = "Парк Победы"
    },
    new()
    {
        Id = Guid.Parse("49a67ebb-1cd1-49ac-a742-6bf4c4055345"),
        Name = "Городской Стадион"
    },
    new()
    {
        Id = Guid.Parse("4d09b32e-50f9-48a1-9711-451abf788c42"),
        Name = "Школа №9"
    },
    new()
    {
        Id = Guid.Parse("d5e6a69b-a260-468e-ac5b-2470efe45f86"),
        Name = "Зелёный рынок"
    },
    new()
    {
        Id = Guid.Parse("b9eaf31b-cd7a-4541-9373-19aeca4627df"),
        Name = "Лиманный рынок"
    },
    new()
    {
        Id = Guid.Parse("93740b9f-9680-47db-a84e-2ae12825883d"),
        Name = "Орион"
    },
    new()
    {
        Id = Guid.Parse("488da1ae-dec1-4cfa-91c2-03debcabe78c"),
        Name = "Манго"
    },
    new()
    {
        Id = Guid.Parse("2a03fa2a-40f4-4db1-ab01-213609596bba"),
        Name = "Бородино"
    }
];

// Время на путь от одной остановки до другой
List<StationsEdge> stationsEdges =
[
    // Леч. Городок -> Парк Победы
    new()
    {
        Id = Guid.Parse("fa541be6-895d-4ff1-92c1-08114b62da2e"),
        FromId = stations[0].Id,
        From = stations[0],
        ToId = stations[1].Id,
        To = stations[1],
        IntervalInMinutes = 3
    },
    // Парк Победы -> Городской Стадион
    new()
    {
        Id = Guid.Parse("85ac3e8a-7fb4-40c1-b123-ea098df97fd5"),
        FromId = stations[1].Id,
        From = stations[1],
        ToId = stations[2].Id,
        To = stations[2],
        IntervalInMinutes = 4
    },
    // Городской Стадион -> Школа №9
    new()
    {
        Id = Guid.Parse("66343e23-c287-4c9a-9046-0af39f7f4b5a"),
        FromId = stations[2].Id,
        From = stations[2],
        ToId = stations[3].Id,
        To = stations[3],
        IntervalInMinutes = 2
    },
    // Школа №9 -> Зелёный рынок
    new()
    {
        Id = Guid.Parse("bb97a613-6e01-4c21-8197-ee3572725436"),
        FromId = stations[3].Id,
        From = stations[3],
        ToId = stations[4].Id,
        To = stations[4],
        IntervalInMinutes = 5
    },
    // Зелёный рынок -> Лиманный рынок
    new()
    {
        Id = Guid.Parse("504129eb-290c-4621-b209-5a3bb3b6f1d4"),
        FromId = stations[4].Id,
        From = stations[4],
        ToId = stations[5].Id,
        To = stations[5],
        IntervalInMinutes = 3
    },
    // Лиманный рынок -> Орион
    new()
    {
        Id = Guid.Parse("b02f2e52-efb0-434e-865b-de181d161f20"),
        FromId = stations[5].Id,
        From = stations[5],
        ToId = stations[6].Id,
        To = stations[6],
        IntervalInMinutes = 3
    },
    // Орион -> Манго
    new()
    {
        Id = Guid.Parse("3d940dc8-9b67-4f4a-97f8-e4b768cee753"),
        FromId = stations[6].Id,
        From = stations[6],
        ToId = stations[7].Id,
        To = stations[7],
        IntervalInMinutes = 4
    },
    // Манго -> Бородино
    new()
    {
        Id = Guid.Parse("507af6c8-c705-4cb1-b808-049ff845bdb1"),
        FromId = stations[7].Id,
        From = stations[7],
        ToId = stations[8].Id,
        To = stations[8],
        IntervalInMinutes = 6
    }
];

// Конкретные пути глобальных маршрутов в определённые даты
List<Route> routes =
[
    new()
    {
        Id = Guid.Parse("0187c805-49e7-4a16-8198-d12cd41cee0f"),
        Name = "Маршрут для троллейбуса №19А c 1 января 2024 года",
        StartDate = DateTime.Parse("2024-1-1"),
        EndDate = DateTime.Parse("2026-1-1"),
        GlobalRouteId = globalRoutes[0].Id,
        GlobalRoute = globalRoutes[0]
    },
    new()
    {
        Id = Guid.Parse("7cd3700f-fb70-4d9b-8958-44216f888abe"),
        Name = "Маршрут для троллейбуса №19А c 1 января 2026 года",
        StartDate = DateTime.Parse("2026-1-1"),
        EndDate = null,
        GlobalRouteId = globalRoutes[0].Id,
        GlobalRoute = globalRoutes[0]
    }
];

// Пути между остановками, входящие в определённый маршрут по порядку
List<RouteStationEdge> routeStationEdges =
[
    new()
    {
        Index = 0,
        RouteId = routes[0].Id,
        Route = routes[0],
        StationsEdgeId = stationsEdges[0].Id, // Леч. Городок -> Парк Победы
        StationsEdge = stationsEdges[0]
    },
    new()
    {
        Index = 1,
        RouteId = routes[1].Id,
        Route = routes[1],
        StationsEdgeId = stationsEdges[1].Id, // Парк Победы -> Городской Стадион
        StationsEdge = stationsEdges[1]
    },
    new()
    {
        Index = 2,
        RouteId = routes[2].Id,
        Route = routes[2],
        StationsEdgeId = stationsEdges[2].Id, // Городской Стадион -> Школа №9
        StationsEdge = stationsEdges[2]
    },
    new()
    {
        Index = 3,
        RouteId = routes[3].Id,
        Route = routes[3],
        StationsEdgeId = stationsEdges[3].Id, // Школа №9 -> Зелёный рынок
        StationsEdge = stationsEdges[3]
    },
    new()
    {
        Index = 4,
        RouteId = routes[4].Id,
        Route = routes[4],
        StationsEdgeId = stationsEdges[4].Id, // Зелёный рынок -> Лиманный рынок
        StationsEdge = stationsEdges[4]
    },
    new()
    {
        Index = 5,
        RouteId = routes[5].Id,
        Route = routes[5],
        StationsEdgeId = stationsEdges[5].Id, // Лиманный рынок -> Орион
        StationsEdge = stationsEdges[5]
    },
    new()
    {
        Index = 6,
        RouteId = routes[6].Id,
        Route = routes[6],
        StationsEdgeId = stationsEdges[6].Id, // Орион -> Манго
        StationsEdge = stationsEdges[6]
    },
    new()
    {
        Index = 7,
        RouteId = routes[7].Id,
        Route = routes[7],
        StationsEdgeId = stationsEdges[7].Id, // Манго -> Бородино
        StationsEdge = stationsEdges[7]
    }
];

List<Vehicle> vehicles =
[
    new()
    {
        Id = Guid.Parse("35534322-012e-456c-a8da-093b0c2db5ce"),
        LicensePlate = "T 123 AA"
    }
];

// Какие пути должны проходить конкретные транспортные средства в определённый промежуток времени и дни недели
List<VehicleGlobalRoute> vehicleGlobalRoutes =
[
    new()
    {
        Id = Guid.Parse("b033d01f-156b-4922-9a25-1270a2c9219a"),
        GlobalRouteId = globalRoutes[0].Id,
        GlobalRoute = globalRoutes[0],
        VehicleId = vehicles[0].Id,
        Vehicle = vehicles[0],
        From = TimeOnly.Parse("8:00"),
        To = TimeOnly.Parse("13:00"),
        DayOfWeek = DayOfWeek.Monday,
        StartDate = DateTime.Parse("2020-1-1"),
        EndDate = null
    },
    new()
    {
        Id = Guid.Parse("2bc3a98e-fe5c-4a41-b3a0-73bdc43581b3"),
        GlobalRouteId = globalRoutes[0].Id,
        GlobalRoute = globalRoutes[0],
        VehicleId = vehicles[0].Id,
        Vehicle = vehicles[0],
        From = TimeOnly.Parse("14:00"),
        To = TimeOnly.Parse("20:00"),
        DayOfWeek = DayOfWeek.Monday,
        StartDate = DateTime.Parse("2020-1-1"),
        EndDate = null
    }
];