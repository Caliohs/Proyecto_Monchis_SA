using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication.Pages.Pedidos
{
    public class BeginModel : PageModel
    {
        private readonly IPedidoService pedidoService;
        private readonly IClientesService clientesService;

        public BeginModel(IPedidoService pedidoService, IClientesService clientesService)
        {
            this.pedidoService = pedidoService;        
            this.clientesService = clientesService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }
        [BindProperty]
        [FromBody]

        public PedidoEntity Entity { get; set; } = new PedidoEntity();

       
        public IEnumerable<ClientesEntity> ClientesLista { get; set; } = new List<ClientesEntity>();
       
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (!this.SessionOnline()) return RedirectToPage("../Login");

                Entity.PedidoId =  await pedidoService.GetId();
                ClientesLista = await clientesService.GetLista();
              
                    
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

                //Nuevo
                    result = await pedidoService.Create(Entity);

                

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

    }
}
