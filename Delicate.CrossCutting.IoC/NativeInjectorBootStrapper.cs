using Delicate.Application.Interfaces;
using Delicate.Application.Services;
using Delicate.CrossCutting.Bus;
using Delicate.Domain.Commands.Product;
using Delicate.Domain.CommandsHandler;
using Delicate.Domain.Core.Bus;
using Delicate.Domain.Core.Notifications;
using Delicate.Domain.EventHandler;
using Delicate.Domain.Events.Product;
using Delicate.Domain.Interfaces;
using Delicate.Infra.Data.SQLServer.Repository;
using Delicate.Infra.Data.SQLServer.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Delicate.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();
         
            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProductCommand, bool>, ProductCommandsHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, ProductCommandsHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, bool>, ProductCommandsHandler>();


            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}