using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class ProductosEntity : EN
    {
        public ProductosEntity()
        {
            Categorias = Categorias ?? new CategoriasEntity();
        }

        public int? ProductoId { get; set; }

        public int? CategoriaId { get; set; }

        public virtual CategoriasEntity Categorias { get; set; }

        public string Producto { get; set; }

        public string Color { get; set; }

        public string Material { get; set; }

        public int? Cantidad_Disponible { get; set; }

        public int? Precio { get; set; }






    }
}
