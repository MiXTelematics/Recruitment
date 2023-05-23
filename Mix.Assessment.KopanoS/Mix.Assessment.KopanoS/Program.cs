using Mix.Assessment.Service.ComponentApi;
using Newtonsoft.Json;
using Mix.Assessment.KopanoS.Helpers;

const string FILE_PATH = "Data/VehiclePositions.dat";

var vehiclepositionApi = new VehiclePositionApi();
var coOrdinateApi = new CoOrdinatesApi();

var vehiclePositions = vehiclepositionApi.GetAll(FILE_PATH);
var co_ordinates = coOrdinateApi.GetAll();



var response = co_ordinates.Select(item =>
  vehiclePositions.OrderBy(x => item.DistanceTo(x.Latitude,x.Longitude))
  .Select(x => new { Position = item.Position,Vehicle = JsonConvert.SerializeObject(x) })
  .FirstOrDefault()).OrderBy(x => x.Position).ToList();


foreach(var item in response)
{
    Console.WriteLine($"Position {item.Position} {item.Vehicle}");
}



Console.ReadKey();

