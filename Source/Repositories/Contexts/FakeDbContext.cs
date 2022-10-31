using Source.Models;
using System.Collections.Generic;

namespace Source.Repositories.Contexts;

class FakeDbContext
{
    public static List<Car> Cars { get; set; } = new()
    {
        new Car { Id = 1, Make = "Kia", Model = "Cerato", Year = 2013 },
        new Car { Id = 2, Make = "Kia", Model = "Optima", Year = 2012 },
        new Car { Id = 3, Make = "Bmw", Model = "X6", Year = 2021 }
    };

    public static List<Car> GetCars()
    {
        var list = new List<Car>();

        // read from json

        return list;
    }
}