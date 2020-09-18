using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POC.Employee.Worker.Contexts;

namespace POC.Employee.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var connString = hostContext.Configuration.GetConnectionString("SourceDB");
                    services.AddDbContext<EmployeeContext>(c =>
                    {
                        c.UseSqlServer(connString);
                    }, ServiceLifetime.Singleton);
                    services.AddHostedService<Worker>();
                });
    }
}
