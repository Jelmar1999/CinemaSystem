using CinemaSystem.Domain.Interfaces;

namespace CinemaSystem.Domain.Strategy;

public class PlaintextExport : IExportBehaviour
{
    public string Export(object exportObject)
    {
        return exportObject.ToString();
    }
}