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
    public class GridModel : PageModel
    {
        private readonly ICategoriasService categoriasService;

        public GridModel(ICategoriasService categoriasService)
        {
            this.categoriasService = categoriasService;
        }


        public IEnumerable<CategoriasEntity> GridList { get; set; } = new List<CategoriasEntity>();

       
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!this.SessionOnline()) return RedirectToPage("../Login");

                GridList = await categoriasService.Get();


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
                var result = await categoriasService.Delete(new()
                {
                    CategoriaId = id
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
    
