using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prueba2.Models
{
    public class contratos
    {

        public long? Id { get; set; }
        [DisplayName("Número Contrato")]
        public int numerocontrato { get; set; }
        [DisplayName("Nombre Entidad")]
        public string nombreentidad { get; set; }
        [DisplayName("Fecha Inicio")]
        public DateTime fechainicio { get; set; }
        [DisplayName("Fecha Fin")]

        public DateTime fechafin { get; set; }
    }
}



