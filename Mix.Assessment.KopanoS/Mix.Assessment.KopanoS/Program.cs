using Mix.Assessment.Service.ComponentApi;
using Newtonsoft.Json;
using System.Linq;

const string FILE_PATH = "Data/VehiclePositions.dat";

var vehiclepositionApi = new VehiclePositionApi();
var coOrdinateApi = new CoOrdinatesApi();

var vehiclePositions = vehiclepositionApi.GetAll(FILE_PATH);
var co_ordinates = coOrdinateApi.GetAll();


foreach(var item in co_ordinates)
{
    var response = vehiclePositions.OrderBy(x => Math.Pow((item.Latitude - x.Latitude),2) + Math.Pow((item.Longitude - x.Longitude),2)).FirstOrDefault();

   Console.WriteLine($"Position {item.Position} {JsonConvert.SerializeObject(response)}");
        
}

Console.ReadKey();
