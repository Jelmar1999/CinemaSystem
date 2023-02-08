using CinemaSystem.Domain.Interfaces;
using Newtonsoft.Json;

namespace CinemaSystem.Domain.Strategy;

public class JSONExport : IExportBehaviour
{
    public string Export(object exportObject)
    {
        return JsonConvert.SerializeObject(exportObject, Formatting.Indented);
    }
}