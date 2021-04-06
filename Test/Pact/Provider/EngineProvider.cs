using Cds.Engine.Tests.ProviderPact;
using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Provider;
using Cds.OfferComparatorUpdatesReader.InMemoryRepository;
using Engine.Domain.Abstractions.Dtos.Handlers;
using EngineApi.Api.Bootstrap;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Cds.OfferComparatorUpdatesReader.Tests.Pact.Provider
{
    /// <summary>
    /// Defines the OfferComparatorUpdatesReader provider
    /// </summary>
    public class EngineProvider : BaseProvider
    {
        private static IWebHost _host;
        public static readonly Uri WebHostUri = new Uri(Constants.HooksBaseIp);
        public static InMemoryEngineRepository TestEngineRepo;
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineProvider"/> class
        /// </summary>
        public EngineProvider() : base()
        {
            TestEngineRepo = new InMemoryEngineRepository();

            _host = Program.ConfigureWebHostBuilder(WebHost.CreateDefaultBuilder())
                .UseEnvironment(Environments.Development)
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
                               .AddHttpClient("Engine")
                               .AddHttpMessageHandler(() => new GlobalServiceHandler());
                })

                .Build();
            _host.Start();
        }

        
    }
}