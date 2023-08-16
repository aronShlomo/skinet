using API.Errors;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions
{
    public static class AplicationServicesExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services, 
        IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();

            Services.AddDbContext<StoreContext>(opt => {
            opt.UseSqlite(config.GetConnectionString("DefaultString"));
            });

            Services.AddScoped<iProductRepository, ProductRepository>();
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            Services.Configure<ApiBehaviorOptions>(options => 
            {
            options.InvalidModelStateResponseFactory = ActionContext => 
            {
                var errors = ActionContext.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors )
                .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse
                {
                    Error = errors
                };
                return new BadRequestObjectResult(errorResponse);
            };
});

          Services.AddCors(opt => 
          {
            opt.AddPolicy("CorsPolicy", policy =>
           {
             policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
           });
          });


            return Services;
        }
    }
}