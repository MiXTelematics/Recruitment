using Mix.Assessment.Service.Helpers;

namespace Mix.Assessment.Service.Data;

internal class VehiclePositionRepository
{
    internal List<Model.VehiclePosition> GetAll(string filename)
    {
        var response = new List<Model.VehiclePosition>();
        var reader = new FileHelper(filename);
        reader.Open();
        while(reader.Read())
        {
            response.Add(reader.Data);
        };

        return response;
    }   

    
}
