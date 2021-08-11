using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.Conductor
{
    public class GridModel : PageModel
    {
        private readonly IConductorService conductorService;

        public GridModel(IConductorService conductorService)
        {
            this.conductorService = conductorService;
        }


        public IEnumerable<ConductorEntity> GridList { get; set; } = new List<ConductorEntity>();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await conductorService.Get();


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
                var result = await conductorService.Delete(new()
                {
                   ConductorId = id
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
