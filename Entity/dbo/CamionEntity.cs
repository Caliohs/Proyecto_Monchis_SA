using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CamionEntity : EN
    {
       
        public int? CamionId { get; set; }

        public string MarcaCamion { get; set; }
      
        public string Conductor { get; set; }
       
        public string Matricula { get; set; }

        public string Color { get; set; }

        public DateTime FechaModelo { get; set; } = DateTime.Now;

    }
}
