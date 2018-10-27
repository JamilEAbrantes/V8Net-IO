using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using V8Net.IO.Application.Interfaces;
using V8Net.IO.Application.Services;
using V8Net.IO.Domain.Core.Bus;
using V8Net.IO.Domain.Core.Events;
using V8Net.IO.Domain.Core.Notification;
using V8Net.IO.Domain.NoticiasContext.Commands;
using V8Net.IO.Domain.NoticiasContext.Events;
using V8Net.IO.Domain.NoticiasContext.Repository;
using V8Net.IO.Infra.CrossCutting.Bus;
using V8Net.IO.Infra.Data.Context;
using V8Net.IO.Infra.Data.Repository;

namespace V8Net.IO.Services
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddAutoMapper();

            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // AUTO MAPPER
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddScoped<INoticiaAppService, NoticiaAppService>();

            // Domain - Commands
            services.AddScoped<IHandler<RegistrarNoticiaCommand>, NoticiaCommandHandler>();
            services.AddScoped<IHandler<AtualizarNoticiaCommand>, NoticiaCommandHandler>();
            services.AddScoped<IHandler<ExcluirNoticiaCommand>, NoticiaCommandHandler>();

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<NoticiaRegistradaEvent>, NoticiaEventHandler>();
            services.AddScoped<IHandler<NoticiaAtualizadaEvent>, NoticiaEventHandler>();
            services.AddScoped<IHandler<NoticiaExcluidaEvent>, NoticiaEventHandler>();

            // Infra - Data
            services.AddScoped<INoticiaRepository, NoticiaRepository>();
            services.AddScoped<V8NetContext>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }
        
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            IHttpContextAccessor acessor)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            
            InMemoryBus.ContainerAcessor = () => acessor.HttpContext.RequestServices;
        }
    }
}
