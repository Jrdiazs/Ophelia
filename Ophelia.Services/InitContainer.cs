using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Ophelia.Data;
using Ophelia.Services.Profiles;

namespace Ophelia.Services
{
    /// <summary>
    /// Contenedor de repositorios y servicios
    /// </summary>
    public static class InitContainer
    {
        /// <summary>
        /// Contenedor de repositorios y servicios
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(IServiceCollection services)
        {
            //AutoMapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomersProfile());
                cfg.AddProfile(new InvoiceDetailProfile());
                cfg.AddProfile(new InvoiceProfile());
                cfg.AddProfile(new ProductsProfile());
                cfg.AddProfile(new TypeDocumentProfile());
            });

            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            ///Repositorios
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ITypeDocumentRepository, TypeDocumentRepository>();
            services.AddScoped<IParametersRepository, ParametersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Servicios
            services.AddScoped<ICustomersServices, CustomersServices>();
            services.AddScoped<IInvoiceDetailServices, InvoiceDetailServices>();
            services.AddScoped<IInvoiceServices, InvoiceServices>();
            services.AddScoped<IProductsServices, ProductsServices>();
            services.AddScoped<ITypeDocumentServices, TypeDocumentServices>();
        }
    }
}