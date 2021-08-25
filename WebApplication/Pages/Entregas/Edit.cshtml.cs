using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplication.Pages.Entregas
{
    public class EditModel : PageModel
    {
        private readonly IEntregaService entregaService;
        private readonly ICamionService camionService;
        private readonly IPedidoService pedidoService;
        private readonly ICatalogoProvinciaService catalogoProvinciaService;
        private readonly ICatalogoCantonService catalogoCantonService;
        private readonly ICatalogoDistritoService catalogoDistritoService;

        public EditModel(IEntregaService entregaService, ICamionService camionService, IPedidoService pedidoService, ICatalogoProvinciaService catalogoProvinciaService, ICatalogoCantonService catalogoCantonService, ICatalogoDistritoService catalogoDistritoService)
        {
            this.entregaService = entregaService;
            this.camionService = camionService;
            this.pedidoService = pedidoService;
            this.catalogoProvinciaService = catalogoProvinciaService;
            this.catalogoCantonService = catalogoCantonService;
            this.catalogoDistritoService = catalogoDistritoService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public EntregaEntity Entity { get; set; } = new EntregaEntity();
        public IEnumerable<CatalogoProvinciaEntity> ProvinciaLista { get; set; } = new List<CatalogoProvinciaEntity>();
        public IEnumerable<PedidoEntity> PedidoLista { get; set; } = new List<PedidoEntity>();
        public IEnumerable<CamionEntity> CamionLista { get; set; } = new List<CamionEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!this.SessionOnline()) return RedirectToPage("../Login");
                if (id.HasValue)
                {
                    Entity = await entregaService.GetById(new() {EntregaId = id });
                }
                ProvinciaLista = await catalogoProvinciaService.GetLista();
                PedidoLista = await pedidoService.GetLista();
                CamionLista = await camionService.GetLista();

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
                if (Entity.EntregaId.HasValue)
                {
                    //Actualizar
                    result = await entregaService.Update(Entity);


                }
                else
                {
                    //Nuevo
                    result = await entregaService.Create(Entity);


                }

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }



        }

        public async Task<IActionResult> OnPostChangeProvincia()
        {
            try
            {
                var result = await catalogoCantonService.GetLista(

                    new CatalogoProvinciaEntity { IdCatalogoProvincia = Entity.ProvinciaId }

                    );

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }

        public async Task<IActionResult> OnPostChangeCanton()
        {
            try
            {
                var result = await catalogoDistritoService.GetLista(

                    new CatalogoCantonEntity { IdCatalogoCanton = Entity.CantonId }

                    );

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
