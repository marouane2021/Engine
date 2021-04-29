using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Abstractions.Dtos.Handlers.Groupes_Handlers;
using Engine.Domain.Abstractions.Dtos.Handlers.ScopesHandlers;
using Engine.Domain.Handlers;
using Engine.Infrastructure;
using Engine.Infrastructure.MongoRepository;
using Engine.Infrastructure.MongoRepository.GroupeRepository;
using Engine.Infrastructure.MongoRepository.ScopeRepository;
using EngineApi.Infrastructure.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EngineApi.Api.Bootstrap
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _environment;
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen()
                .AddHealthChecks();
            services
                // Registers MVC & Web API services.
                .AddMvcCore()
                    .AddDataAnnotations()
                    .AddAuthorization()
                    // Adds the JSON input and output formatter using Newtonsoft.JSON.
                    //.AddJsonFormatters()
                    // Registers services to generate OpenApi Specifications (via third party library).
                    .AddApiExplorer()
                    // Registers Cdiscount's services to handle field selection, paging, etc.
                    //.AddUnifiedRestApi()
                    // Adds the JSON serialization strategy
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });

            // Caching
            //services.ConfigureCacheServices(_configuration);

            services
                .Configure<Settings>(_configuration.GetSection("MongoDBConfiguration"));

            //Our dependency injections
            services.AddTransient<MetricReporter>();
            services.AddTransient<IEngineHandler, EngineHandler>();
            services.AddSingleton<IEngineRepository, EngineMongoDBRepository>();
            services.AddSingleton<IScopeRepository,ScopeMongoDBRepository>();
            services.AddSingleton<IScopeHandler, ScopeHandler>();
            services.AddSingleton<IGroupeHandler, GroupeHandler>();
            services.AddSingleton<IGroupeRepository, GroupeMongoDBRepository>();
            //services.AddSingleton<IEngineRepository, EPEngineRepo>();
            services.AddSingleton(_configuration.GetSection("BestOffersApi").Get<BestOfferApi>());
            //Cors
            services.AddCors(options =>
            {

                options.AddPolicy(name: "react",
                  builder =>
                  {
                      builder.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
                  });
            });
            

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("react");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app
               .UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
               });


            app.UseHttpsRedirection();

           

            app.UseAuthentication();


            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });


        }
    }
}
