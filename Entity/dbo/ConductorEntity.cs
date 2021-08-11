using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ConductorEntity:EN
    {
        public ConductorEntity()
        {
            
        }
        public int?  ConductorId { get; set; }
        public string CedulaConductor { get; set; }
        public string NombreCompleto { get; set; }
        public string  Telefono { get; set; }  
        public int? Edad { get; set; }
        
    }
}
