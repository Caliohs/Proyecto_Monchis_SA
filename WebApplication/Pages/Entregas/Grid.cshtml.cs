using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.Entregas
{
    public class GridModel : PageModel
    {
        private readonly IEntregaService entregaService;
        private readonly IPedidoService pedidoService;
        private readonly ICamionService camionService;

        public GridModel(IEntregaService entregaService, IPedidoService pedidoService, ICamionService camionService)
        {
            this.entregaService = entregaService;
            this.pedidoService = pedidoService;
            this.camionService = camionService;
        }

        public IEnumerable<EntregaEntity> GridList { get; set; } = new List<EntregaEntity>();

        
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await entregaService.Get();


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
                var result = await entregaService.Delete(new()
                {
                   EntregaId  = id
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
