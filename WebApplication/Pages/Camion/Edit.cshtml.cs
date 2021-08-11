using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.Camion
{
    public class EditModel : PageModel
    {
        private readonly ICamionService camionService;
        private readonly IMarcaCamionService marcaCamionService;
        private readonly IConductorService conductorService;

        public EditModel(ICamionService camionService, IMarcaCamionService marcaCamionService, IConductorService conductorService)
        {
            this.camionService = camionService;
            this.marcaCamionService = marcaCamionService;
            this.conductorService = conductorService;
        }



        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public CamionEntity Entity { get; set; } = new CamionEntity();

        public IEnumerable<MarcaCamionEntity> MarcaCamionLista { get; set; } = new List<MarcaCamionEntity>();
        public IEnumerable<ConductorEntity> ConductorLista { get; set; } = new List<ConductorEntity>();


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await camionService.GetById(new() {CamionId = id });
                }

                MarcaCamionLista = await marcaCamionService.GetLista();
                ConductorLista = await conductorService.GetLista();

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
                if (Entity.CamionId.HasValue)
                {
                    //Actualizar
                    result = await camionService.Update(Entity);

                }
                else
                {
                    //Nuevo
                    result = await camionService.Create(Entity);

                }

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }



        }

        ////public async Task<IActionResult> OnPostChangeProvincia()
        ////{
        ////    try
        ////    {
        ////        var result = await catalogoCantonService.GetLista(
                    
        ////            new CatalogoProvinciaEntity { IdCatalogoProvincia= Entity.IdCatalogoProvincia}
                    
        ////            );

        ////        return new JsonResult(result);


        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
        ////    }
        ////}

        ////public async Task<IActionResult> OnPostChangeCanton()
        ////{
        ////    try
        ////    {
        ////        var result = await catalogoDistritoService.GetLista(

        ////            new CatalogoCantonEntity { IdCatalogoCanton = Entity.IdCatalogoCanton }

        ////            );

        ////        return new JsonResult(result);


        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
        ////    }
        ////}




    }
}
