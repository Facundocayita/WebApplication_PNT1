using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApplication_PNT1.Models
{
    public enum FormaEntrega
    {
        [Display(Name = "Envió común(3 a 4 días hábiles")]
        [CostoBase(1000.0)]
        EnvioComun,

        [Display(Name = "Envío inmediato (24hs)")]
        [CostoBase(1500.0)]
        EnvioInmediato,

        [Display(Name = "Retirar en nuestro local")]
        [CostoBase(0.0)]
        RetirarCompra
    }
    public static class FormaEntregaExtensions
    {
        public static double GetCostoBase(this FormaEntrega formaEntrega)
        {
            FieldInfo fi = formaEntrega.GetType().GetField(formaEntrega.ToString());
            CostoBaseAttribute[] attributes = (CostoBaseAttribute[])fi.GetCustomAttributes(typeof(CostoBaseAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].CostoBase;
            }
            else
            {
                throw new InvalidOperationException("Costo base no definido para el tipo de proyecto.");
            }
        }
    }
}
