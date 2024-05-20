namespace RegistroAduaneroDeBarcos.Entidades;

public class Barco
{
    public int IdBarco { get; set; }

    public string Nombre { get; set; }

    public int Antiguedad { get; set; }

    public int TripulacionMaxima { get; set; }

    public decimal Tasa { get; set; }
}

