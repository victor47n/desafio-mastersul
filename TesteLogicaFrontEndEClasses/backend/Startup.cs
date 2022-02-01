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
            // Definindo o cors para que requisi��es de qualquer dominio sejam aceitas
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });

            // Necess�rio para trabalhar com controllers
            services.AddControllers();

            // Adicionado a inje��o de dependencia dos reposit�rios
            // com o tempo de vida em escopo, ou seja, o mesmo � 
            // definido uma �nica vez por solicita��o
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

            // Utilizando Cors
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
