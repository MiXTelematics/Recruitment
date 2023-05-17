using Mix.Assessment.Service.Model;

namespace Mix.Assessment.Service.Data;

internal class CoOrdinateRepository
{
    internal CoOrdinateRepository()
    {
        CoOrdernates = new List<CoOrdernate>()
        {
            new CoOrdernate()
            {
                Latitude = 34.544909,
                Longitude = -102.100843,
                Position = 1
            },
            new CoOrdernate()
            {
                Latitude = 32.345544,
                Longitude = -99.123124,
                Position = 2
            },
            new CoOrdernate()
            {
                Latitude = 33.234235,
                Longitude = -100.214124,
                Position = 3
            },
            new CoOrdernate()
            {
                Latitude = 35.195739,
                Longitude = -95.348899,
                Position = 4
            },
            new CoOrdernate()
            {
                Latitude = 31.895839,
                Longitude = -97.789573,
                Position = 5
            },
            new CoOrdernate()
            {
                Latitude = 32.895839,
                Longitude = -101.789573,
                Position = 6
            },
            new CoOrdernate()
            {
                Latitude = 34.115839,
                Longitude = -100.225732,
                Position = 7
            },
            new CoOrdernate()
            {
                Latitude = 32.335839,
                Longitude = -99.992232,
                Position = 8
            },
            new CoOrdernate()
            {
                Latitude = 33.535339,
                Longitude = -94.792232,
                Position = 9
            },
            new CoOrdernate()
            {
                Latitude = 32.234235,
                Longitude = -100.222222,
                Position = 10
            }
        };
    }
    internal List<CoOrdernate> CoOrdernates { get; set; }
}

