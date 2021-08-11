using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplication.Pages.MarcaCamion
{
    public class EditModel : PageModel
    {
        private readonly IMarcaCamionService marcaCamionService;

        public EditModel(IMarcaCamionService marcaCamionService)
        {
            this.marcaCamionService = marcaCamionService;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public MarcaCamionEntity Entity { get; set; } = new MarcaCamionEntity();


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await marcaCamionService.GetById(new() {MarcaCamionId = id });
                }

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
                if (Entity.MarcaCamionId.HasValue)
                {
                    //Actualizar
                    result = await marcaCamionService.Update(Entity);


                }
                else
                {
                    //Nuevo
                    result = await marcaCamionService.Create(Entity);


                }

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }



        }
    }
}
