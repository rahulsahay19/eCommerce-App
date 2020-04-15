using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IEcommerceRepository<>), typeof(EcommerceRepository<>));
            services.AddScoped<IBasketRepository, BasketRepository>();
             services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = acttionContext =>
                {
                    var errors = acttionContext.ModelState
                                               .Where(e => e.Value.Errors.Count > 0)
                                               .SelectMany(x => x.Value.Errors)
                                               .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new APIValidationError
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}