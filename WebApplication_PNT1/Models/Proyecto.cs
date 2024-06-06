using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication_PNT1.Models
{
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProyecto { get; set; }
        public required string Descripcion { get; set; }
        
        public double Ancho { get; set; }
        public double Alto {  get; set; }
        public double Groso { get; set; }   

        public DateTime FechaPedido { get; set; }
        [EnumDataType(typeof(TipoProyecto))]
        public TipoProyecto Tipo { get; set; }
    }

}

