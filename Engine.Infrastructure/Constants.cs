
namespace Engine.Infrastructure
{
    class Constants
    { /// <summary>
      /// The competing offers collection
      /// </summary>
        internal const string CompetingOffersCollection = "competingOffer";

        /// <summary>
        /// The mongo database configuration section
        /// </summary>
        internal const string MongoDbConfigurationSection = "MongoDBConfiguration";

        /// <summary>
        /// The competing offer changes limit configuration section
        /// </summary>
        internal const string CompetingOfferChangesLimitConfigurationSection = "CompetingOfferChangesConfiguration:Limit";

        /// <summary>
        /// The seller end point feature client name
        /// </summary>
        internal const string SellerEndPointFeatureClientName = "SellerEndPointFeatureClient";

        /// <summary>
        /// The product catalog cache key configuration
        /// </summary>
        internal const string SellerEndPointCacheKey = "SellerEndPoint:CacheKeyConfiguration";

        /// <summary>
        /// The active sellers cache key
        /// </summary>
        internal const string ActiveSellersCacheKey = "SellerEndPoint:ActiveSellersCacheKeyConfiguration";
    }
}
