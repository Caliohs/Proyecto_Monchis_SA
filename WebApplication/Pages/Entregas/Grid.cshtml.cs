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
        private readonly ICamionService camionService;
        private readonly IPedidoService pedidoService;
        private readonly ICatalogoProvinciaService catalogoProvinciaService;
        private readonly ICatalogoCantonService catalogoCantonService;
        private readonly ICatalogoDistritoService catalogoDistritoService;

        public GridModel(IEntregaService entregaService, ICamionService camionService, IPedidoService pedidoService, ICatalogoProvinciaService catalogoProvinciaService, ICatalogoCantonService catalogoCantonService, ICatalogoDistritoService catalogoDistritoService)
        {
            this.entregaService = entregaService;
            this.camionService = camionService;
            this.pedidoService = pedidoService;
            this.catalogoProvinciaService = catalogoProvinciaService;
            this.catalogoCantonService = catalogoCantonService;
            this.catalogoDistritoService = catalogoDistritoService;
        }

        public IEnumerable<EntregaEntity> GridList { get; set; } = new List<EntregaEntity>();

        
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!this.SessionOnline()) return RedirectToPage("../Login");

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
