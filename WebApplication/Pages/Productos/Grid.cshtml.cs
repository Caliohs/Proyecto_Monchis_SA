using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.Productos
{
    public class GridModel : PageModel
    {
        private readonly IProductosService productoService;

        public GridModel(IProductosService productoService)
        {
            this.productoService = productoService;
        }


        public IEnumerable<ProductosEntity> GridList { get; set; } = new List<ProductosEntity>();

        
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!this.SessionOnline()) return RedirectToPage("../Login");
                GridList = await productoService.Get();


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
                var result = await productoService.Delete(new()
                {
                   ProductoId = id
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
