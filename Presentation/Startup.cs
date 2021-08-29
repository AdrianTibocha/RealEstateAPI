using Application.Business;
using Application.Business.Input;
using Application.Dto.ResponseObject;
using Application.Helper;
using Domain;
using Domain.Business;
using Domain.Business.Output;
using Infraestructure.Business.Input;
using Infraestructure.Business.SqlImplementation.Dao;
using Infraestructure.Business.SqlImplementation.DB;
using Infraestructure.Business.SqlImplementation.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Presentation.Business;
using System.Linq;
using System.Text.Json.Serialization;

namespace RealState
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureInfraestructure(services);
            ConfigureDomain(services);
            ConfigureApplication(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealState", Version = "v1" });
            });
            services.AddMvc().AddJsonOptions(op =>
            {
                op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            ConfigureModelBindingExceptionHandling(services);
        }
        private void ConfigureModelBindingExceptionHandling(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.InvalidModelStateResponseFactory = actionContext =>
                {
                    string errorMessages = string.Join(", ",actionContext.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                    return new BadRequestObjectResult(new Response
                    {
                        status = StatusResponse.UserError,
                        message = errorMessages
                    }); ;
                };
            });
        }

        public void ConfigureApplication(IServiceCollection services)
        {
            services.AddSingleton(ImageBusiness => new ImageBusiness(Configuration["PropertyImagesFolder"]));
            services.AddScoped<IPropertyBusiness, PropertyBusiness>();
            services.AddScoped<IPropertyMapper, PropertyMapper>();
            services.AddScoped<IPropertyCriteriaBusiness, PropertyCriteriaBusiness>();
        }

        public void ConfigureDomain(IServiceCollection services)
        {
            services.AddScoped<IFactoryProperty, FactoryProperty>();
            services.AddScoped<IPropertyRepository, SqlPropertyRepository>();
            services.AddScoped<IPropertyImageRepository, SqlPropertyImageRepository>();
        }

        public void ConfigureInfraestructure(IServiceCollection services)
        {
            services.AddSingleton<IDataHelper>(Data => new Data(Configuration["SqlDatabase:ConnectionString"]));
            services.AddScoped<IPropertyDao, PropertyDao>();
            services.AddScoped<IImagePropertyDao, ImagePropertyDao>();
            services.AddScoped<PropertyEntityMapper, PropertyEntityMapper>();
            services.AddScoped<PropertyImageEntityMapper, PropertyImageEntityMapper>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RealState v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
