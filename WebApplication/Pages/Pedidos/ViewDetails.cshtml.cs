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
    public class ViewDetailsModel : PageModel
    {
        private readonly IPedidoService pedidoService;
        private readonly IPedidoPorProductoService pedidoPorProductoService;

        public ViewDetailsModel(IPedidoService pedidoService, IPedidoPorProductoService pedidoPorProductoService)
        {
            this.pedidoService = pedidoService;
            this.pedidoPorProductoService = pedidoPorProductoService;
             
        }
       

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }
       
        [BindProperty]
        [FromBody]

        public PedidoEntity Entity { get; set; } = new PedidoEntity();
        public IEnumerable<PedidoPorProductoEntity> GridList { get; set; } = new List<PedidoPorProductoEntity>();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await pedidoService.GetById(new() { PedidoId = id });             
                    GridList = await pedidoPorProductoService.GetByIdDetails(new() { PedidoId = id });
                }

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }


       


        //public async Task<JsonResult> OnDeleteEliminar(int id)
        //{
        //    try
        //    {
        //        var result = await productoService.Delete(new()
        //        {
        //           ProductoId = id
        //        });



        //        return new JsonResult(result);
        //    }
        //    catch (Exception ex)
        //    {

        //        return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
        //    }

        //}
    }
}
