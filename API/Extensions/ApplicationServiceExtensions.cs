using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    /* 
       This class was created just to clean up the startup class. 
       It's just housekeeping to try and keep our starter classes tidy and as neat as possible.
    */
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            /* CORS Policy 
                |This cause is required when we're trying to access a resource from a different domain
                | Example: Our client-app is runing on port 3000 which is a different domain to our API server port 5000
            */
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    /* By adding a CORS Policy, what we're going to return is a header with our response that says 
                       we're allows you use any method, get posts, put options, etc. We're allow any header, but we're
                       going to make sure it's with origins from our client app */
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });

            services.AddMediatR(typeof(List.Handler).Assembly);
            // AutoMapper is a helper tool to help us map properties from one object to another object
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}