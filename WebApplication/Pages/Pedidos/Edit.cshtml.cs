using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.Pedidos
{
    public class EditModel : PageModel
    {
        private readonly IPedidoService pedidoService;
        private readonly IPedidoPorProductoService pedidoPorProductoService;
        private readonly IProductosService productosService;
        private readonly IClientesService clientesService;

        public EditModel(IPedidoService pedidoService, IPedidoPorProductoService pedidoPorProductoService, IProductosService productosService, IClientesService clientesService)
        {
            this.pedidoService = pedidoService;
            this.pedidoPorProductoService = pedidoPorProductoService;
            this.productosService = productosService;
            this.clientesService = clientesService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public PedidoEntity En { get; set; } = new PedidoEntity();

        [BindProperty]
        [FromBody]
        public PedidoPorProductoEntity Entity { get; set; } = new PedidoPorProductoEntity();

        public IEnumerable<ClientesEntity> ClientesLista { get; set; } = new List<ClientesEntity>();
        public IEnumerable<ProductosEntity> ProductosLista { get; set; } = new List<ProductosEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                Entity.PedidoId = id;
               // ClientesLista = await clientesService.GetLista();
                ProductosLista = await productosService.GetLista();
                    
                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }


        public async Task<IActionResult> OnPost()
        {
            try
            {

                var result = new DBEntity();

                //Nuevo
                    result = await pedidoPorProductoService.Create(Entity);

                

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

    }
}
