using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaEventHub.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
//using SistemaEventHub.DAL.Interfaces;
//using SistemaEventHub.DAL.Implementacion;
//using SistemaEventHub.BLL.Interfaces;
//using SistemaEventHub.BLL.Implementacion;

namespace SistemaEventHub.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyectar DbContext
            services.AddDbContext<EventHubDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CadenaSQL")));
            
            
            // Inyectar Repositorios
            
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddScoped<IProductoRepository, ProductoRepository>();
            // Inyectar Servicios
            //services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<IProductoService, ProductoService>();
        }
    }
}
