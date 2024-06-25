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

        public int? PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        public DateTime FechaPedido { get; set; }
        [EnumDataType(typeof(TipoProyecto))]
        public TipoProyecto Tipo { get; set; }

        public double CostoUnitario { get; set; }
        public double CostoTotal { get; set; }


        public double CalcularCosto()
        {
            
            double costoBase = Tipo.GetCostoBase();

           
            double tamaño = Ancho * Alto * Groso;

           
            double costoPorColor = 20.0;

            
            double costoUnitario = costoBase + (tamaño * 0.1) + (CantColores * costoPorColor);

            return costoUnitario;
        }

        public double CalcularCostoTotal()
        {
            double costoTotal = CalcularCosto() * Cantidad;

            return costoTotal;
        }


        public void SetCostos()
        {
            CostoUnitario = CalcularCosto();
            CostoTotal = CalcularCostoTotal();
        }

 
    }
}

