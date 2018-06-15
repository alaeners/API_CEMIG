using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_APP_CEMIG.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API_APP_CEMIG
{
    public class Startup
    {
        string conn = "Server=tcp:trabalhosandro.database.windows.net,1433;Initial Catalog=TrabalhoSandro;Persist Security Info=False;User ID=administrador;Password=Pe87016054;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IItemRepositorio, ItemRepositorio>();
            services.AddScoped<IItemPerfilRepositorio, ItemPerfilRepositorio>();
            services.AddDbContext<UsuarioContext>(options => options.UseSqlServer(conn));
            services.AddDbContext<ItemContext>(options => options.UseSqlServer(conn));
            services.AddDbContext<ItemPerfilContext>(options => options.UseSqlServer(conn));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
