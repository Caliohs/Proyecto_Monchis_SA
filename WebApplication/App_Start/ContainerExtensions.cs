using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;

namespace WebApplication
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IClientesService, ClientesService>();
            services.AddTransient<ICamionService, CamionService>();
            services.AddTransient<IMarcaCamionService, MarcaCamionService>();
            services.AddTransient<IConductorService, ConductorService>();
            services.AddTransient<ICatalogoProvinciaService, CatalogoProvinciaService>();
            services.AddTransient<ICatalogoCantonService, CatalogoCantonService>();
            services.AddTransient<ICatalogoDistritoService, CatalogoDistritoService>();
            services.AddTransient<IProductosService, ProductosService>();
            services.AddTransient<ICategoriasService, CategoriasService>();

            return services;
        }
    }
}
