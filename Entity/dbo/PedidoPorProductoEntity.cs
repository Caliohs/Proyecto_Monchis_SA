using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class PedidoPorProductoEntity : EN
    {
        public PedidoPorProductoEntity()
        {
            Productos = Productos ?? new ProductosEntity();
            Pedido = Pedido ?? new PedidoEntity();

        }

        public int? PedidoPorProductoId { get; set; }
        public int? ProductoId { get; set; }
        public virtual ProductosEntity Productos { get; set; }

        public int? PedidoId { get; set; }
        public virtual PedidoEntity Pedido { get; set; }
       
        public int? Cantidad{ get; set; }

        public int? Acumulado { get; set; }






    }
}
