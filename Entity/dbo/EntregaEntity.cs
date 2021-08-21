using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class EntregaEntity : EN
    {
        public EntregaEntity()
        {
            Pedidos = Pedidos ?? new PedidoEntity();
            Camiones = Camiones ?? new CamionEntity();
        }

        public int? EntregaId { get; set; }

        public int? PedidoId { get; set; }

        public virtual PedidoEntity Pedidos { get; set; }

        public int? CamionId { get; set; }

        public virtual CamionEntity Camiones { get; set; }

        public string Provincia { get; set; }

        public string Canton { get; set; }

        public string Distrito { get; set; }

        public DateTime FechaEntrega { get; set; }
    }
}
