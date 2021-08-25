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
            Provincia = Provincia ?? new CatalogoProvinciaEntity();
            Canton = Canton ?? new CatalogoCantonEntity();
            Distrito = Distrito ?? new CatalogoDistritoEntity();
        }

        public int? EntregaId { get; set; }

        public int? PedidoId { get; set; }

        public virtual PedidoEntity Pedidos { get; set; }

        public int? CamionId { get; set; }

        public virtual CamionEntity Camiones { get; set; }

        public int? ProvinciaId { get; set; }
        public virtual CatalogoProvinciaEntity Provincia { get; set; }

        public int? CantonId { get; set; }
        public virtual CatalogoCantonEntity Canton { get; set; }
        public int? DistritoId { get; set; }
        public virtual CatalogoDistritoEntity Distrito { get; set; }

        public DateTime FechaEntrega { get; set; }
    }
}
