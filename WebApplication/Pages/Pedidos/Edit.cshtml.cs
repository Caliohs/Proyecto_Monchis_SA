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
                if (!this.SessionOnline()) return RedirectToPage("../Login");

                Entity.PedidoId = id;

                // ClientesLista = await clientesService.GetLista();
                //  GridListProductos = await productosService.Get();
               
                ProductosLista = await productosService.GetLista();
                EntityP = await pedidoService.GetById(new() { PedidoId = id });
                GridList = await pedidoPorProductoService.GetByIdDetails(new() { PedidoId = id });

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public PedidoEntity EntityP { get; set; } = new PedidoEntity();
        public IEnumerable<PedidoPorProductoEntity> GridList { get; set; } = new List<PedidoPorProductoEntity>();

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

        public async Task<JsonResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await pedidoPorProductoService.Delete(new()
                {
                    PedidoPorProductoId = id
                });



                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

    }
}
