using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace WebApplication_PNT1.Models
{
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProyecto { get; set; }
        public required string Descripcion { get; set; }

        public double Ancho { get; set; }
        public double Alto { get; set; }
        public double Groso { get; set; }

        public int CantColores { get; set; } // VER FUNCIONALIDAD EN LA VISTA PARA AGREGAR COLORES CLIQUEANDO O MANDANDO VALOR NUMERICO

         public int Cantidad { get; set; }

        public DateTime FechaPedido { get; set; }
        [EnumDataType(typeof(TipoProyecto))]
        public TipoProyecto Tipo { get; set; }


        public double CalcularCosto()
        {
            // Obtiene el costo base según el tipo de proyecto
            double costoBase = Tipo.GetCostoBase();

            // Calcula el tamaño del proyecto
            double tamaño = Ancho * Alto * Groso;

            // Define un factor para el costo por color
            double costoPorColor = 20.0;

            // Calcula el costo total
            double costoUnitario = costoBase + (tamaño * 0.1) + (CantColores * costoPorColor);

            return costoUnitario;
        }

        public double CalcularCostoTotal()
        {
            double costoTotal = CalcularCosto() * Cantidad;

            return costoTotal;
        }

        public double getCostoTotal() {
            return CalcularCostoTotal();

        }
    }
}

