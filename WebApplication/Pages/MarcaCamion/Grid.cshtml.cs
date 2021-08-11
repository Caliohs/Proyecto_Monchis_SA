using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.MarcaCamion
{
    public class GridModel : PageModel
    {
        private readonly IMarcaCamionService marcaCamionService;

        public GridModel(IMarcaCamionService marcaCamionService)
        {
            this.marcaCamionService = marcaCamionService;
        }


        public IEnumerable<MarcaCamionEntity> GridList { get; set; } = new List<MarcaCamionEntity>();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await marcaCamionService.Get();


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
                var result = await marcaCamionService.Delete(new()
                {
                  MarcaCamionId = id
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
