using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication
{
    public class ServiceApi
    {
        private readonly HttpClient client;

        public ServiceApi(HttpClient client )
        {
            this.client = client;
        }

        #region Usuarios

        #region Usuarios
        public async Task<UsuariosEntity> UsuarioLogin(UsuariosEntity entity)
        {
            var result = await client.ServicioPostAsync<UsuariosEntity>("api/Usuarios/Login", entity);

            return result;

        }

        #endregion

        #endregion




    }
}
