using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplication.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly IClientesService clientesService;

        public EditModel(IClientesService clientesService)
        {
            this.clientesService = clientesService;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public ClientesEntity Entity { get; set; } = new ClientesEntity();


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await clientesService.GetById(new() {ClientesId = id });
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
                if (Entity.ClientesId.HasValue)
                {
                    //Actualizar
                    result = await clientesService.Update(Entity);


                }
                else
                {
                    //Nuevo
                    result = await clientesService.Create(Entity);


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
