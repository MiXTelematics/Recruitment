using Mix.Assessment.Service.Data;

namespace Mix.Assessment.Service.ComponentApi;

public class VehiclePositionApi
{
    private readonly VehiclePositionRepository vehiclePositionRepository;
    public VehiclePositionApi()
    {
        vehiclePositionRepository = new VehiclePositionRepository();
    }

    public List<Model.VehiclePosition> GetAll(string filename) => this.vehiclePositionRepository.GetAll(filename);
}
