using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prueba2.Models
{
    public class trabajadores
    {
        public long? trabajadorId { get; set; }
        [DisplayName("Identificación")]
        public int identificacion { get; set; }
        [DisplayName("Tipo de Identiifcación")]
        public int tipoindetificacion { get; set; }
        [DisplayName("Primer Nombre")]
        public string primernombre { get; set; }
        [DisplayName("Segundo Nombre")]
        public string segundonombre { get; set; }
        [DisplayName("Primer Apellido")]
        public string primerapellido { get; set; }
        [DisplayName("Segundo Apellido")]
        public string segundoapellido { get; set; }
        [DisplayName("Fecha de Nacimiento")]

        public DateTime fechadenacimineto { get; set; }

    
        public ICollection<contratos> contrato { get; set; }

        [ForeignKey("contratos")]
        public long Id { get; set; }
        public virtual contratos contratos { get; set; }
    }
}
