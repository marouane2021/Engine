using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Infrastructure.MongoRepository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using EngineApi.Api.Bootstrap;

namespace Cds.Engine.Tests.Bdd.Core
{
    [Binding]
    public sealed class Hooks
    {
        private static IWebHost _host;

        /// <summary>
        /// The web host Uri.
        /// </summary>
        public static readonly Uri WebHostUri = new Uri(Constants.HooksBaseIp);
        public static InMemoryEngineApi TestEngineApi;

        /// <summary>
        /// before feature method
        /// </summary>
        [BeforeFeature]
        public static void BeforeFeature()
        {
            TestEngineApi = new InMemoryEngineApi();


            _host = Program.ConfigureWebHostBuilder(WebHost.CreateDefaultBuilder())
                .UseEnvironment(Environments.Development)
                .UseUrls(WebHostUri.ToString())
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddJsonFile(Constants.TestConfigurationFile);
                 })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IEngineRepository>(TestEngineApi);
                })

                .Build();
            _host.Start();
        }

        /// <summary>
        /// after test run method
        /// </summary>
        [AfterFeature]
        public static async Task Afterfeature()
        {
            await _host.StopAsync().ConfigureAwait(false);
            _host.Dispose();
        }
    }
}
