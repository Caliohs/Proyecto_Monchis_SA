using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class PedidoEntity : EN
    {
       

        public int? PedidoId { get; set; }
      
        public string Cliente { get; set; }
        
        public DateTime FechaPedido { get; set; }

        public string Subtotal { get; set; }
        public string IVA { get; set; }
        public string Total { get; set; }



    }
}
