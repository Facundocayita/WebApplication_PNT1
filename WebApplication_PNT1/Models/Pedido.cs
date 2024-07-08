using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_PNT1.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Display(Name = "Persona que recibe el pedido")]
        public string? Cliente { get; set; }

   
        [EnumDataType(typeof(EstadoPedido))]
        public EstadoPedido Estado { get; set; }

        [Required]
        [Display(Name = "Dirección de entrega")]
        public string? DireccionEntrega { get; set; }

        [Display(Name = "Fecha de entrega estimada")]
        public DateTime? FechaEntrega { get; set; }
        public string? Observaciones { get; set; }

        public Proyecto? Proyecto { get; set; }
        public int? ProyectoId { get; set; }

        [EnumDataType(typeof(FormaEntrega))]
        public FormaEntrega TipoEntrega { get; set; }

        [Display(Name = "Precio Total")]
        [DataType(DataType.Currency)]
        public double CostoTotal { get; set; }


        // Método para calcular el costo total. (Costo proyecto + costo de envio)
        public void SetCostoTotal(Proyecto proyecto)
        {

            CostoTotal = proyecto.CalcularCosto() + TipoEntrega.GetCostoBase();

        }

        public void agregarPedido(Proyecto proyecto) 
        {
            Proyecto = proyecto;
        }

        public void SetFechaEntrega()
        {
            switch (TipoEntrega)
            {
                case FormaEntrega.RetirarCompra:
                    FechaEntrega = null; 
                    break;
                case FormaEntrega.EnvioInmediato:
                    FechaEntrega = FechaCreacion.AddDays(1); 
                    break;
                case FormaEntrega.EnvioComun:
                    FechaEntrega = SumarDiasHabiles(FechaCreacion, 4);
                    break;
                default:
                    throw new InvalidOperationException("Forma de entrega no válida");
            }
        }

        private DateTime SumarDiasHabiles(DateTime fechaInicial, int diasHabiles)
        {
            int diasSumados = 0;
            DateTime fechaActual = fechaInicial;

            while (diasSumados < diasHabiles)
            {
                fechaActual = fechaActual.AddDays(1);
                if (fechaActual.DayOfWeek != DayOfWeek.Saturday && fechaActual.DayOfWeek != DayOfWeek.Sunday)
                {
                    diasSumados++;
                }
            }

            return fechaActual;
        }

        public void SetEstado(EstadoPedido estado)
        {
            Estado = estado;
        }
    }
    
}
