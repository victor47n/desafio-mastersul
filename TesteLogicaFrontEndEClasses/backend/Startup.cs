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
            // Definindo o cors para que requisições de qualquer dominio sejam aceitas
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });

            // Necessário para trabalhar com controllers
            services.AddControllers();

            // Adicionado a injeção de dependencia dos repositórios
            // com o tempo de vida em escopo, ou seja, o mesmo é 
            // definido uma única vez por solicitação
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
