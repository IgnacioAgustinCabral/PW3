using RegistroAduaneroDeBarcos.Entidades;
using System.ComponentModel.DataAnnotations;

namespace RegistroAduaneroDeBarcos.Web.Models;

public class BarcoModel
{
    private Barco b;

    public int IdBarco { get; set; }

    [Required(ErrorMessage = "El nombre del barco es requerido"), StringLength(20, ErrorMessage = "El nombre del barco no puede tener más de 20 caracteres")]
    public string Nombre { get; set; }
 

    [Required(ErrorMessage = "La antiguedad del barco es requerida"), Range(1, 199)]
    public int Antiguedad { get; set; }

    [Required(ErrorMessage = "La tripulación máxima del barco es requerida"), Range(1, 500)]
    public int TripulacionMaxima { get; set; }

    public decimal Tasa { get; set; }


    public BarcoModel()
    {
    }

    public BarcoModel(Barco barco)
    {
        IdBarco = barco.IdBarco;
        Nombre = barco.Nombre;
        Antiguedad = barco.Antiguedad;
        TripulacionMaxima = barco.TripulacionMaxima;
        Tasa = barco.Tasa;
    }

    public Barco MapToEntity()
    {
        return new Barco
        {
            IdBarco = IdBarco,
            Nombre = Nombre,
            Antiguedad = Antiguedad,
            TripulacionMaxima = TripulacionMaxima,
            Tasa = Tasa
        };
    }

    public static List<BarcoModel> MapToBarcoModelList(List<Barco> barcos)
    {
        return barcos.Select(b => new BarcoModel(b)).ToList();
    }
}

