using Cds.Engine.Tests.ProviderPact;
using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Provider;
using Engine.Domain.Abstractions.Dtos.Handlers;
using EngineApi.Api.Bootstrap;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.Engine.Tests.ProviderPact.EngineEpProvider
{
    public class EngineEpProvider : BaseProvider
    {
        public static InMemoryEngineRepository TestEngineRepo;
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineProvider"/> class
        /// </summary>

        public EngineEpProvider() : base()
        {
            TestEngineRepo = new InMemoryEngineRepository();

            Host = Program.CreateHostBuilder(new string[0])
                .ConfigureWebHostDefaults(b =>
                b.UseEnvironment(Environments.Development)
                .UseUrls(WebHostUri.ToString())
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddJsonFile(Constants.TestConfigurationFile);
                 })
                .ConfigureServices(services =>
                {
                    services.
                    AddSingleton<IEngineRepository>(TestEngineRepo);
                    services
                               .AddHttpClient("EngineEP")
                               .AddHttpMessageHandler(() => new GlobalServiceHandler());
                }))

                .Build();
            Host.Start();

        }


    }
}
