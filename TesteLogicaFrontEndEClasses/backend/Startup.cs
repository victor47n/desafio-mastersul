using LogicaDeProgramacaoFrontEndWebEClasses.Interfaces;
using LogicaDeProgramacaoFrontEndWebEClasses.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LogicaDeProgramacaoFrontEndWebEClasses
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });

            services.AddControllers();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
