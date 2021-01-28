using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SmartScgoole.WebAPI.Data;

namespace SmartScgoole.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<SmartContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            //injeção da  Repository - nativamente
            //inversão de contexto INVERSION OF CONTROL - injeção de dependência

            //3 formas de fazer
            
            //pode ter problema pq cria uma instância qdo é solicitado pela primeira vez e reutiliza essa
            //instância em todos os locais q esse serviço é necessário
            //services.AddSingleton<IRepository, Repository>();

            //sempre gera uma nova instância pra cada item encontrado que possua tal dependência,
            //ou seja, se hover 5 dependências serão 5 instâncias diferentes
            //services.AddTransient<IRepository, Repository>();

            //sempre utiliza este
            
            //diferente da Transient q garante q em cada uma requisição seja criada uma instância de uma classe
            //onde houver outras dependências, seja utilizada essa única instância pra todas, renovando somente
            //nas requisições subsequentes mas, mantendo essa obrigatoriedade

            services.AddScoped<IRepository, Repository>();



                            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartScgoole.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartScgoole.WebAPI v1"));
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

           // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
