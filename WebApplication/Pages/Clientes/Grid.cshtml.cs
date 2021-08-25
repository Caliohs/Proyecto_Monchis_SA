using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.Clientes
{ 
    public class GridModel : PageModel
    {
        private readonly IClientesService clientesService;

        public GridModel(IClientesService clientesService)
        {
            this.clientesService = clientesService;
        }


        public IEnumerable<ClientesEntity> GridList { get; set; } = new List<ClientesEntity>();
        public async Task<IActionResult> OnGet()
        {
            try
            {

                if (!this.SessionOnline()) return RedirectToPage("../Login");

                GridList = await clientesService.Get();


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
                var result = await clientesService.Delete(new()
                {
                ClientesId = id
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
