
using Cds.Engine.Tests.ProviderPact;
using Engine.Domain.Abstractions.Dtos.Handlers;
using EngineApi.Api.Bootstrap;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Cds.SearchEngineEditor.Tests.Bdd
{
    public class TestWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");

            builder.ConfigureTestServices(
                    services =>
                    {
                        services
                        .AddSingleton<IEngineRepository, InMemoryEngineRepository>();

                    });

            base.ConfigureWebHost(builder);
        }
    }
}
