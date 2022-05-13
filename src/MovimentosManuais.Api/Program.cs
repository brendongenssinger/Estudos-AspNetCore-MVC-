using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovimentosManuais.InfraStruture.Data;

namespace MovimentosManuais.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
<<<<<<< HEAD
            Console.ReadKey();
=======
>>>>>>> fbdacfb834b1711aa4135de4f176d0497be77dad
        }

        private static void CreateDbIfNotExists(IWebHost host)
        {
            using (var scop = host.Services.CreateScope())
            {
                var services = scop.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MovimentosManuaisContext>();
                    new DbInitializer(context).Initilialize();
                }
                catch (Exception eX)
                {

                    return;
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
