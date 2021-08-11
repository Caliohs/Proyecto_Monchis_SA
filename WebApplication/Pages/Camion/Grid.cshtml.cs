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
    public class GridModel : PageModel
    {


        private readonly ICamionService camionService;

        public GridModel(ICamionService camionService)
        {
            this.camionService = camionService;
        }

        public IEnumerable<CamionEntity> GridList { get; set; } = new List<CamionEntity>();


        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await camionService.Get();


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
                var result = await camionService.Delete(new()
                {
                    CamionId = id
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

