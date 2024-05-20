using RegistroAduaneroDeBarcos.Entidades;

namespace RegistroAduaneroDeBarcos.Logica.Services;

public class BarcosService : IBarcosService
{
    const decimal CONSTANTE_ANTIGUEDAD = 0.10m;

    const decimal CONSTANTE_TRIPULACION = 2m;

    private static List<Barco> _barcosRegistrados = new List<Barco>();

    public List<Barco> ListarBarcos()
    {
        return _barcosRegistrados.OrderBy(b => b.IdBarco).ToList();
    }

    public void RegistrarBarco(Barco barco)
    {
        barco.Tasa = CalcularTasa(barco.Antiguedad, barco.TripulacionMaxima);

        barco.IdBarco = _barcosRegistrados.Count == 0 ? 1 : _barcosRegistrados.Max(b => b.IdBarco) + 1;

        _barcosRegistrados.Add(barco);
    }

    private decimal CalcularTasa(int antiguedad, int tripulacionMaxima)
    {
        return (Convert.ToDecimal(antiguedad) * CONSTANTE_ANTIGUEDAD) + (Convert.ToDecimal(tripulacionMaxima) / CONSTANTE_TRIPULACION);
    }
}

public interface IBarcosService
{
    void RegistrarBarco(Barco barco);
    List<Barco> ListarBarcos();
}