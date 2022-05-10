using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovimentosManuais.InfraStruture.Data;
using MovimentosManuais.ApplicationCore.Interfaces.Services;

using MovimentosManuais.ApplicationCore.Interfaces.Repository;
using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.InfraStruture.Services;
using MovimentosManuais.InfraStruture.Repository;

namespace MovimentosManuais.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MovimentosManuaisContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(Configuration.GetConnectionString("DataBaseConnection"));
            });
            services.AddScoped<IMovimentosManuaisServices,MovimentosManuaisServices>();
            services.AddScoped<IProdutoService, ProdutosServices>();
            services.AddScoped<IProdutosCosifsServices, ProdutosCosifServices>();
            services.AddScoped<MovimentoManualRepository>();
            services.AddScoped<ProdutosRepository>();
            services.AddScoped<ProdutosCosifRepository>();
            services.AddCors();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors(x => { x.AllowCredentials().AllowAnyHeader().AllowAnyMethod(); });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); 
            });
        }
    }
}
