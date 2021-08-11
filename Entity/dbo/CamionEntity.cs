using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CamionEntity : EN
    {
        public CamionEntity()
        {
            MarcaCamionEntity = MarcaCamionEntity?? new MarcaCamionEntity();
            ConductorEntity = ConductorEntity ?? new ConductorEntity();
        }
        public int? CamionId { get; set; }

        public int? MarcaCamionId { get; set; }
        public virtual MarcaCamionEntity MarcaCamionEntity { get; set; }
        public int? ConductorId { get; set; }
        public virtual ConductorEntity ConductorEntity { get; set; }
        public string Matricula { get; set; }

        public string Color { get; set; }

        public DateTime FechaModelo { get; set; } = DateTime.Now;

    }
}
