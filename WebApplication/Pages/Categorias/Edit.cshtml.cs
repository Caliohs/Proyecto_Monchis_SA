using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.Categorias
{
    public class EditModel : PageModel
    {
        private readonly ICategoriasService categoriasService;

        public EditModel(ICategoriasService categoriasService)
        {
            this.categoriasService = categoriasService;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public CategoriasEntity Entity { get; set; } = new CategoriasEntity();


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!this.SessionOnline()) return RedirectToPage("../Login");
                if (id.HasValue)
                {
                    Entity = await categoriasService.GetById(new() { CategoriaId = id });
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
                if (Entity.CategoriaId.HasValue)
                {
                    //Actualizar
                    result = await categoriasService.Update(Entity);


                }
                else
                {
                    //Nuevo
                    result = await categoriasService.Create(Entity);


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
   