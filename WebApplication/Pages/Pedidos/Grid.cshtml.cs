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
    public class GridModel : PageModel
    {
        private readonly IPedidoService pedidoService;

        public GridModel(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }


        public IEnumerable<PedidoEntity> GridList { get; set; } = new List<PedidoEntity>();

        
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!this.SessionOnline()) return RedirectToPage("../Login");

                GridList = await pedidoService.Get();


                return Page();


            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        public async Task<JsonResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await pedidoService.Delete(new()
                {
                    PedidoId = id
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
