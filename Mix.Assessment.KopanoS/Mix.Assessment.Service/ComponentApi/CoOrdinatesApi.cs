using Mix.Assessment.Service.Data;
using Mix.Assessment.Service.Model;

namespace Mix.Assessment.Service.ComponentApi;

public class CoOrdinatesApi
{
    private readonly CoOrdinateRepository coOrdernate;
    public CoOrdinatesApi()
    {
        this.coOrdernate = new CoOrdinateRepository();
    }

    public List<CoOrdernate> Get(int id) => this.coOrdernate.CoOrdernates.Where(x => x.Position == id).ToList();

    public List<CoOrdernate> Get(Func<CoOrdernate,bool> where) => this.coOrdernate.CoOrdernates.Where(where).ToList();

    public List<CoOrdernate> GetAll() => this.coOrdernate.CoOrdernates.ToList();
}
