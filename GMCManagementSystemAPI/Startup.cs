using GMCManagementSystemAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using GMCManagementSystemAPI.Services;
using GMCManagementSystemAPI.Services.Generic;
using GMCManagementSystemAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using GMCManagementSystemAPI.Configuration;

namespace GMCManagementSystemAPI
{
    public class Startup
    {
        // public IConfigurationRoot Configuration { get; }
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            configurationRoot = builder.Build();
        }

       

        public IConfigurationRoot configurationRoot { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddCors(option => option.AddPolicy("APIPolicy", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

            services.AddHttpClient();
            services.AddDbContext<GmcManagementSystemContext>(options =>
            options.UseSqlServer(configurationRoot["DbConnection"]));

          //  services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           // services.AddScoped<IGenericService<MunicipalCorporationDetailViewModel>, MunicipalCorporationDetailService<MunicipalCorporationDetailViewModel>>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "GMCManagementSystemAPI",
                    Version = "v1",
                    Description = "Municipal Corporation",
                });
            });
            services.AddAutoMapper(typeof(Startup));
            IocContainerConfiguration.ConfigureService(services, configurationRoot);

          //  services.AddMvc().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceloopHandling = ReferenceLoopHandling.Ignore;}); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("APIPolicy");
            //var option = new RewriteOptions();
            //option.AddRedirect("^$","swagger");
            //app.UseRewriter(option);

            //// Enable middleware to serve generated Swagger as a JSON endpoint.  
            //// Enable middleware to serve generated Swagger as a JSON endpoint.  
            ////app.UseSwagger(c =>
            ////{
            ////    c.SerializeAsV2 = true;
            ////});
            //app.UseSwagger();
            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
            //// specifying the Swagger JSON endpoint.  
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //   // c.RoutePrefix = string.Empty;
            //});

           

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "GMCManagementSystemAPI"));
        }
    }
}
