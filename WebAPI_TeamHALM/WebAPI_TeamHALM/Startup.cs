using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI_TeamHALM_Domain;
using Microsoft.EntityFrameworkCore;
using WebAPI_TeamHALM.Data;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomersService, CustomersService>();
            services.AddSingleton<ICustomersRepository>(c => new CustomersRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IDepartmentsService, DepartmentsService>();
            services.AddSingleton<IDepartmentsRepository>(c => new DepartmentsRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IOrderHistoryService, OrderHistoryService>();
            services.AddSingleton<IOrderHistoryRepository>(c => new OrderHistoryRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IOrderStatusesService, OrderStatusesService>();
            services.AddSingleton<IOrderStatusesRepository>(c => new OrderStatusesRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IStaffService, StaffService>();
            services.AddSingleton<IStaffRepository>(c => new StaffRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IWorkOrdersService, WorkOrdersService>();
            services.AddSingleton<IWorkOrdersRepository>(c => new WorkOrdersRepository(Configuration["ConnectionString"]));

            services.AddSingleton<IFullOrderDetailsService, FullOrderDetailsService>();
            services.AddSingleton<IFullOrderDetailsRepository>(c => new FullOrderDetailsRepository(Configuration["ConnectionString"]));

            services.AddControllers();

            //services.AddDbContext<WebAPIContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("WebAPIContext")));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); //Os�ker p� vad dessa g�r

            app.UseRouting();

            app.UseAuthorization(); //Os�ker p� vad dessa g�r

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
