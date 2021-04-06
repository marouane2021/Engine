using Cds.Foundation.Test;
using Cds.Foundation.Test.Pact.Provider;
using Cds.OfferComparatorUpdatesReader.Infrastructure.CompetingOffer.Dtos;
using Cds.OfferComparatorUpdatesReader.Infrastructure.CompetingOffer.MongoRepository.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Cds.OfferComparatorUpdatesReader.Tests.Pact.Provider
{
    /// <summary>
    /// Defines the OfferComparatorUpdatesReader provider tests
    /// </summary>
    public class EngineProviderTests : BaseProviderTests<EngineProvider>
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineProviderTests"/> class
        /// </summary>
        /// <param name="output">The Xunit output</param>
        /// <param name="provider">The provider</param>
        public EngineProviderTests(ITestOutputHelper output, EngineProvider provider) : base(output, provider)
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json", true).Build();

            ProviderStates.Add("Get Competing Offers Changes success", async () => await MockSellerEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Get Competing Offers Changes TechnicalError", async () => await MockSellerEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Get Competing Offers Changes NoContent", async () => await MockSellerEpCallReturnSuccessAsync().ConfigureAwait(false));
            ProviderStates.Add("Get Competing Offers Changes Forbidden", async () => await MockSellerEpCallReturnSuccessAsync().ConfigureAwait(false));
        }

        [Fact]
        public Task Provider_OfferComparatorUpdatesReader() => EnsureProviderHonoursPactAsync();

        /// <summary>
        /// Mocks the seller ep call return success asynchronous.
        /// </summary>
        private async Task MockSellerEpCallReturnSuccessAsync()
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(ConstructFeatureSeller("OfferComparator.OfferUpdate")), Encoding.UTF8, "application/json");
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = content,
                RequestUri = new Uri($"{_configuration["SellerEndPoint:Host"]}{_configuration["SellerEndPoint:ActiveSellersRoute"]}"),
            };

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(@"Json/sellerEP_GetActiveSellers.json").ConfigureAwait(false))
        };

            GlobalServiceHandler.AddResponseMap(
                httpRequest,
                httpResponse);
        }

        #region private helpers
        /// <summary>
        /// Constructs the feature seller.
        /// </summary>
        /// <param name="featureMessage">The feature message.</param>
        /// <returns></returns>
        private static FeatureSellerDto ConstructFeatureSeller(string featureMessage)
        {
            return new FeatureSellerDto
            {
                FeatureName = featureMessage
            };
        }
        #endregion
    }
}
