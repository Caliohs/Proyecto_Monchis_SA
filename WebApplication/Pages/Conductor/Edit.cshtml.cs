using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplication.Pages.Conductor
{
    public class EditModel : PageModel
    {
        private readonly IConductorService conductorService;

        public EditModel(IConductorService conductorService)
        {
            this.conductorService = conductorService;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public ConductorEntity Entity { get; set; } = new ConductorEntity();


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!this.SessionOnline()) return RedirectToPage("../Login");

                if (id.HasValue)
                {
                    Entity = await conductorService.GetById(new() { ConductorId = id });
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
                if (Entity.ConductorId.HasValue)
                {
                    //Actualizar
                    result = await conductorService.Update(Entity);


                }
                else
                {
                    //Nuevo
                    result = await conductorService.Create(Entity);


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
