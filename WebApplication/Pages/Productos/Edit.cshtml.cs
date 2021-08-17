using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.Vehiculo
{
    public class EditModel : PageModel
    {
        private readonly IProductosService productosService;
        private readonly ICategoriasService categoriasService;

        public EditModel(IProductosService productosService, ICategoriasService categoriasService)
        {
            this.productosService = productosService;
            this.categoriasService = categoriasService;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public ProductosEntity Entity { get; set; } = new ProductosEntity();
        public IEnumerable<CategoriasEntity> CategoriaLista { get; set; } = new List<CategoriasEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await productosService.GetById(new() {ProductoId = id });
                }
                CategoriaLista = await categoriasService.GetLista();
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
                if (Entity.ProductoId.HasValue)
                {
                    //Actualizar
                    result = await productosService.Update(Entity);


                }
                else
                {
                    //Nuevo
                    result = await productosService.Create(Entity);


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
